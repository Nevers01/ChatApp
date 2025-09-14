using Chat.Contracts;
using Chat.Domain;
using Chat.Infrastructure;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;

namespace Chat.Server.Hubs
{
    public class ChatHub : Hub
    {
        private readonly AppDbContext _db;

        public ChatHub(AppDbContext db) => _db = db;

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            if (InMemoryState.Connections.TryRemove(Context.ConnectionId, out var info))
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, info.RoomId.ToString());
                if (InMemoryState.RoomOnlineUsers.TryGetValue(info.RoomId, out var set))
                {
                    set.TryRemove(info.UserId, out _);
                    await SendUserList(info.RoomId);
                    await Clients.Group(info.RoomId.ToString()).SendAsync("SystemInfo", $"Kullanıcı {info.UserId} ayrıldı");
                }
            }
            await base.OnDisconnectedAsync(exception);
        }

        public async Task JoinRoom(Guid userId, Guid roomId, string name)
        {
            var exists = await _db.Rooms.AnyAsync(r => r.Id == roomId && r.IsActive);
            if (!exists)
            {
                await Clients.Caller.SendAsync("SystemInfo", "Oda bulunamadı veya aktif değil.");
                return;
            }

            // varsa eski oda/gruptan çıkar
            if (InMemoryState.Connections.TryGetValue(Context.ConnectionId, out var prev))
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, prev.RoomId.ToString());
                if (InMemoryState.RoomOnlineUsers.TryGetValue(prev.RoomId, out var prevSet))
                {
                    prevSet.TryRemove(prev.UserId, out _);
                    await SendUserList(prev.RoomId); // eski odaya güncel listeyi yolla
                    await Clients.Group(prev.RoomId.ToString()).SendAsync("SystemInfo", $"Kullanıcı {prev.UserId} ayrıldı");
                }
            }

            // yeni odaya ekle
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId.ToString());
            InMemoryState.Connections[Context.ConnectionId] = (userId, roomId);

            var set = InMemoryState.RoomOnlineUsers.GetOrAdd(roomId, _ => new());
            set[userId] = 1;

            await SendUserList(roomId);
            await Clients.Group(roomId.ToString()).SendAsync("SystemInfo", $"Kullanıcı {name} katıldı");
        }

        public async Task SendMessage(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return;
            if (!InMemoryState.Connections.TryGetValue(Context.ConnectionId, out var info)) return;

            var boundUserId = info.UserId;
            var boundRoomId = info.RoomId;

            var user = await _db.Users
                .Where(u => u.Id == boundUserId)
                .Select(u => new { u.Id, u.UserName })
                .FirstOrDefaultAsync();
            if (user is null) return;

            _db.Messages.Add(new Chat.Domain.Message { RoomId = boundRoomId, UserId = boundUserId, Text = text });
            await _db.SaveChangesAsync();

            var dto = new MessageDto(boundRoomId, boundUserId, user.UserName, text, DateTime.UtcNow);
            await Clients.Group(boundRoomId.ToString()).SendAsync("Message", dto);
        }

        // odadaki online kullanıcı listesini yayınlar
        public async Task SendUserList(Guid roomId)
        {
            if (InMemoryState.RoomOnlineUsers.TryGetValue(roomId, out var set))
            {
                var ids = set.Keys.ToList();
                var users = await _db.Users
                    .Where(u => ids.Contains(u.Id))
                    .Select(u => new UserDto(u.Id, u.UserName))
                    .ToListAsync();

                await Clients.Group(roomId.ToString()).SendAsync("UserList", users);
            }
        }
    }
}