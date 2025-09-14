using Chat.Contracts;
using Chat.Domain;
using Chat.Infrastructure;
using Chat.Server.Hubs;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://0.0.0.0:5000");

// MSSQL
var conn = builder.Configuration.GetConnectionString("Default") ??
           "Server=141.98.112.152;Database=ChatDb;User Id=Nevers;Password=Nevers231_;TrustServerCertificate=True;";
builder.Services.AddInfrastructure(conn);

// SignalR
builder.Services.AddSignalR();

var app = builder.Build();

// CORS YOK (WinForms için gerekmez)

// --- Migration & seed ---
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();

    if (!db.Rooms.Any())
    {
        db.Rooms.AddRange(
            new Room { Name = "Lobi" },
            new Room { Name = "Sohbet-1" },
            new Room { Name = "Sohbet-2" }
        );
        await db.SaveChangesAsync();
    }
}

// --- AUTH ---
app.MapPost("/auth/register", async (AppDbContext db, RegisterRequest req) =>
{
    var exists = await db.Users.AnyAsync(u => u.UserName == req.UserName);
    if (exists) return Results.BadRequest("Kullanýcý adý mevcut");

    var user = new User
    {
        Id = Guid.NewGuid(),
        UserName = req.UserName.Trim(),
        PasswordHash = BCrypt.Net.BCrypt.HashPassword(req.Password)
    };
    db.Users.Add(user);
    await db.SaveChangesAsync();

    return Results.Ok(new AuthResponse(user.Id, user.UserName, user.Id.ToString()));
});

app.MapPost("/auth/login", async (AppDbContext db, LoginRequest req) =>
{
    var user = await db.Users.FirstOrDefaultAsync(u => u.UserName == req.UserName);
    if (user == null || !BCrypt.Net.BCrypt.Verify(req.Password, user.PasswordHash))
        return Results.Unauthorized();

    return Results.Ok(new AuthResponse(user.Id, user.UserName, user.Id.ToString()));
});

// --- ROOMS & MATCH ---
app.MapGet("/rooms", async (AppDbContext db) =>
{
    var rooms = await db.Rooms.Where(r => r.IsActive).ToListAsync();
    var list = rooms.Select(r =>
    {
        var online = InMemoryState.RoomOnlineUsers.TryGetValue(r.Id, out var set) ? set.Count : 0;
        return new RoomDto(r.Id, r.Name, online);
    });
    return Results.Ok(list);
});

app.MapPost("/rooms", async (AppDbContext db, string name) =>
{
    var room = new Room { Id = Guid.NewGuid(), Name = string.IsNullOrWhiteSpace(name) ? "Yeni Oda" : name.Trim() };
    db.Rooms.Add(room);
    await db.SaveChangesAsync();
    return Results.Ok(new RoomDto(room.Id, room.Name, 0));
});

app.MapPost("/match/random", async (AppDbContext db) =>
{
    var activeRooms = await db.Rooms.Where(r => r.IsActive)
                                    .Select(r => new { r.Id, r.Name })
                                    .ToListAsync();
    if (!activeRooms.Any()) return Results.NotFound("Aktif oda yok");

    var pick = activeRooms[Random.Shared.Next(activeRooms.Count)];
    return Results.Ok(new RandomJoinResponse(pick.Id, pick.Name));
});

app.MapHub<ChatHub>("/hub/chat");

app.Run();