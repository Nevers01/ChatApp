using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Contracts
{
    public record RoomDto(Guid Id, string Name, int OnlineCount);
    public record JoinRoomRequest(Guid RoomId);
    public record RandomJoinResponse(Guid RoomId, string RoomName);
    public record MessageDto(Guid RoomId, Guid UserId, string UserName, string Text, DateTime Ts);
    public record UserDto(Guid Id, string UserName);
}