using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = default!;
        public string PasswordHash { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsBanned { get; set; }
        public ICollection<RoomMember> RoomMembers { get; set; } = new List<RoomMember>();
    }

    public class Room
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<RoomMember> RoomMembers { get; set; } = new List<RoomMember>();
        public ICollection<Message> Messages { get; set; } = new List<Message>();
    }

    public class RoomMember
    {
        public Guid Id { get; set; }
        public Guid RoomId { get; set; }
        public Room Room { get; set; } = default!;
        public Guid UserId { get; set; }
        public User User { get; set; } = default!;
        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LeftAt { get; set; }
        public bool IsActive => LeftAt == null;
    }

    public class Message
    {
        public Guid Id { get; set; }
        public Guid RoomId { get; set; }
        public Room Room { get; set; } = default!;
        public Guid UserId { get; set; }
        public User User { get; set; } = default!;
        public string Text { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}