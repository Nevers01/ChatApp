using System.Collections.Concurrent;

namespace Chat.Domain
{
    // SignalR’da online/presence bilgisini hızlı tutarız
    public static class InMemoryState
    {
        // connectionId -> (userId, roomId)
        public static ConcurrentDictionary<string, (Guid UserId, Guid RoomId)> Connections { get; } = new();

        // roomId -> userId set (aktif bağlantılar)
        public static ConcurrentDictionary<Guid, ConcurrentDictionary<Guid, byte>> RoomOnlineUsers { get; } = new();
    }
}