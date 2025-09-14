using Chat.Contracts;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat.Client
{
    public partial class MainForm : Form
    {
        private readonly Guid _userId;
        private readonly string _baseUrl;
        private HubConnection? _conn;
        private Guid? _roomId;

        // HTTP JSON deserialize için ortak ayar (camelCase uyumsuzluğu çözülür)
        private static readonly JsonSerializerOptions JsonOpts =
            new() { PropertyNameCaseInsensitive = true };

        public MainForm(Guid userId, string baseUrl)
        {
            _userId = userId;
            _baseUrl = baseUrl;
            InitializeComponent();

            btnSend.Enabled = false; // Join olmadan kapalı

            Load += async (_, __) =>
            {
                await ConnectHub();
                await LoadRooms();
            };

            btnRandom.Click += async (_, __) =>
            {
                try
                {
                    btnSend.Enabled = false;
                    using var http = new HttpClient();
                    var res = await http.PostAsync($"{_baseUrl}/match/random", null);
                    res.EnsureSuccessStatusCode();
                    var json = await res.Content.ReadAsStringAsync();
                    var rnd = JsonSerializer.Deserialize<RandomJoinResponse>(json, JsonOpts)!;
                    await JoinRoom(rnd.RoomId, rnd.RoomName);
                    btnSend.Enabled = true;
                }
                catch (Exception ex)
                {
                    lstMessages.Items.Add($"[Hata] {ex.Message}");
                }
            };

            btnJoinSelected.Click += async (_, __) =>
            {
                try
                {
                    if (cmbRooms.SelectedItem is ComboItem item)
                    {
                        btnSend.Enabled = false;
                        await JoinRoom(item.Id, item.Text);
                        btnSend.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    lstMessages.Items.Add($"[Hata] {ex.Message}");
                }
            };

            btnSend.Click += async (_, __) =>
            {
                try
                {
                    if (_conn is null || _roomId is null || string.IsNullOrWhiteSpace(txtInput.Text))
                        return;

                    // Server şu an (userId, roomId, text) alıyor; sadeleştirirsen "text" tek parametreye geçeriz
                    await _conn.InvokeAsync("SendMessage", _userId, _roomId.Value, txtInput.Text);
                    txtInput.Clear();
                }
                catch (Exception ex)
                {
                    lstMessages.Items.Add($"[Hata] {ex.Message}");
                }
            };
        }

        private async Task ConnectHub()
        {
            _conn = new HubConnectionBuilder()
                .WithUrl($"{_baseUrl}/hub/chat")
                .AddJsonProtocol(o =>
                {
                    // SignalR mesajlarında da camelCase <-> PascalCase farkını tolere et
                    o.PayloadSerializerOptions.PropertyNameCaseInsensitive = true;
                    // İstersen: o.PayloadSerializerOptions.PropertyNamingPolicy = null;
                })
                .WithAutomaticReconnect()
                .Build();

            _conn.On<MessageDto>("Message", msg =>
            {
                BeginInvoke(() => lstMessages.Items.Add($"{msg.UserName}: {msg.Text}"));
            });

            _conn.On<string>("SystemInfo", s =>
            {
                BeginInvoke(() => lstMessages.Items.Add($"[Sistem] {s}"));
            });

            _conn.On<System.Collections.Generic.List<UserDto>>("UserList", users =>
            {
                BeginInvoke(() =>
                {
                    lstUsers.Items.Clear();
                    foreach (var u in users) lstUsers.Items.Add(u.UserName);
                });
            });

            await _conn.StartAsync();
            lstMessages.Items.Add("[Sistem] Hub bağlantısı kuruldu.");
        }

        private async Task LoadRooms()
        {
            using var http = new HttpClient();
            var json = await http.GetStringAsync($"{_baseUrl}/rooms");
            var rooms = JsonSerializer.Deserialize<System.Collections.Generic.List<RoomDto>>(json, JsonOpts)!;

            var items = rooms.Select(r => new ComboItem(r.Id, $"{r.Name} ({r.OnlineCount})")).ToList();
            cmbRooms.DisplayMember = "Text";
            cmbRooms.ValueMember = "Id";
            cmbRooms.DataSource = items;
        }

        private async Task JoinRoom(Guid roomId, string roomName)
        {
            _roomId = roomId;
            lstMessages.Items.Clear(); // odayı değiştirince sohbet penceresini temizle (opsiyonel)
            await _conn!.InvokeAsync("JoinRoom", _userId, roomId);
            lstMessages.Items.Add($"[Sistem] Odaya katıldın: {roomName}");
        }

        private record ComboItem(Guid Id, string Text)
        {
            public override string ToString() => Text;
        }
    }
}