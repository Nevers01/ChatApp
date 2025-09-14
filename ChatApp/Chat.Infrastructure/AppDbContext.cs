using Chat.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Room> Rooms => Set<Room>();
        public DbSet<RoomMember> RoomMembers => Set<RoomMember>();
        public DbSet<Message> Messages => Set<Message>();

        protected override void OnModelCreating(ModelBuilder b)
        {
            b.Entity<User>()
                .HasIndex(x => x.UserName)
                .IsUnique();

            b.Entity<RoomMember>()
                .HasOne(rm => rm.Room).WithMany(r => r.RoomMembers).HasForeignKey(rm => rm.RoomId);
            b.Entity<RoomMember>()
                .HasOne(rm => rm.User).WithMany(u => u.RoomMembers).HasForeignKey(rm => rm.UserId);
        }
    }
}