using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Contracts
{
    public record RegisterRequest(string UserName, string Password);
    public record LoginRequest(string UserName, string Password);
    public record AuthResponse(Guid UserId, string UserName, string Token);
}