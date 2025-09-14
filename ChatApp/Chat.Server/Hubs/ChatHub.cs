using Chat.Contracts;
using Chat.Domain;
using Chat.Infrastructure;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

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

        public async Task JoinRoom(Guid userId, Guid roomId)
        {
            var exists = await _db.Rooms.AnyAsync(r => r.Id == roomId && r.IsActive);
            if (!exists)
            {
                await Clients.Caller.SendAsync("SystemInfo", "Oda bulunamadı veya aktif değil.");
                return;
            }

            // Kullanıcı adı
            var name = await _db.Users
                .Where(u => u.Id == userId)
                .Select(u => u.UserName)
                .FirstOrDefaultAsync();

            if (string.IsNullOrEmpty(name))
            {
                await Clients.Caller.SendAsync("SystemInfo", "Kullanıcı bulunamadı.");
                return;
            }

            // varsa eski oda/gruptan çıkar
            if (InMemoryState.Connections.TryGetValue(Context.ConnectionId, out var prev))
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, prev.RoomId.ToString());
                if (InMemoryState.RoomOnlineUsers.TryGetValue(prev.RoomId, out var prevSet))
                {
                    prevSet.TryRemove(prev.UserId, out _);
                    await SendUserList(prev.RoomId);
                    // Ayrılanın adını da göstermek istersen DB'den çekebilirsin
                    await Clients.Group(prev.RoomId.ToString()).SendAsync("SystemInfo", $"Kullanıcı {name} ayrıldı");
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

        public async Task SendMessage(Guid userId, Guid roomIdIgnored, string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return;

            // Bağlantıdan user/room’u al
            if (!InMemoryState.Connections.TryGetValue(Context.ConnectionId, out var info))
                return;

            var boundUserId = info.UserId;
            var boundRoomId = info.RoomId;

            // Güvenlik: client’tan gelen userId eşleşmeli
            if (boundUserId != userId) return;

            // Oda ve kullanıcı gerçekten var mı?
            var roomExists = await _db.Rooms.AnyAsync(r => r.Id == boundRoomId && r.IsActive);
            if (!roomExists) { await Clients.Caller.SendAsync("SystemInfo", "Oda bulunamadı."); return; }

            var user = await _db.Users
                                .Where(u => u.Id == boundUserId)
                                .Select(u => new { u.Id, u.UserName })
                                .FirstOrDefaultAsync();
            if (user is null) { await Clients.Caller.SendAsync("SystemInfo", "Kullanıcı bulunamadı."); return; }

            try
            {
                // 🔴 Önemli: Id/CreatedAt NULL kalmasın
                _db.Messages.Add(new Chat.Domain.Message
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.UtcNow,
                    RoomId = boundRoomId,
                    UserId = boundUserId,
                    Text = text
                });
                await _db.SaveChangesAsync();

                var dto = new MessageDto(boundRoomId, boundUserId, user.UserName, text, DateTime.UtcNow);
                await Clients.Group(boundRoomId.ToString()).SendAsync("Message", dto);
            }
            catch (Exception ex)
            {
                // Hata nedenini client’a bildir (geçici tanılama)
                await Clients.Caller.SendAsync("SystemInfo", $"Mesaj kaydı başarısız: {ex.Message}");
                throw; // SignalR, client’ta "Failed to invoke..." görür; log için kalsın
            }
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