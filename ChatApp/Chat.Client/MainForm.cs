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

        // HTTP JSON deserialize için ortak ayar (camelCase)
        private static readonly JsonSerializerOptions JsonOpts =
            new() { PropertyNameCaseInsensitive = true };

        public MainForm(Guid userId, string baseUrl)
        {
            _userId = userId;
            _baseUrl = baseUrl;
            InitializeComponent();

            // enter ile gönderme
            txtInput.KeyDown += TxtInput_KeyDown;

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
                    AddSystem($"Hata: {ex.Message}");
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
                    AddSystem($"Hata: {ex.Message}");
                }
            };

            btnSend.Click += async (_, __) => await SendFromInputAsync();
        }

        // ENTER = gönder, CTRL+ENTER = yeni satır
        private async void TxtInput_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Control)
            {
                e.SuppressKeyPress = true; // ding sesini engelle
                await SendFromInputAsync();
            }
            else if (e.KeyCode == Keys.Enter && e.Control)
            {
                // çok satırlı ise yeni satır ekleyebilirsin; tek satırlı textbox'ta gerek yok
            }
        }

        private async Task SendFromInputAsync()
        {
            try
            {
                if (_conn is null || _conn.State != HubConnectionState.Connected)
                {
                    AddSystem("Hub bağlı değil.");
                    return;
                }
                if (_roomId is null || string.IsNullOrWhiteSpace(txtInput.Text))
                    return;

                await _conn.InvokeAsync("SendMessage", _userId, _roomId.Value, txtInput.Text);
                txtInput.Clear();
            }
            catch (Exception ex)
            {
                AddSystem($"Hata: {ex.Message}");
            }
        }

        private async Task ConnectHub()
        {
            _conn = new HubConnectionBuilder()
                .WithUrl($"{_baseUrl}/hub/chat")
                .AddJsonProtocol(o =>
                {
                    o.PayloadSerializerOptions.PropertyNameCaseInsensitive = true;
                })
                .WithAutomaticReconnect()
                .Build();

            _conn.On<MessageDto>("Message", msg =>
            {
                BeginInvoke(() => AddChat(msg.UserName, msg.Text));
            });

            _conn.On<string>("SystemInfo", s =>
            {
                BeginInvoke(() => AddSystem(s));
            });

            _conn.On<System.Collections.Generic.List<UserDto>>("UserList", users =>
            {
                BeginInvoke(() =>
                {
                    lstUsers.Items.Clear();
                    foreach (var u in users) lstUsers.Items.Add(u.UserName);
                });
            });

            _conn.Closed += async (ex) =>
            {
                BeginInvoke(() =>
                {
                    btnSend.Enabled = false;
                    AddSystem("Hub bağlantısı kapandı, yeniden deneniyor...");
                });
            };

            _conn.Reconnected += (id) =>
            {
                BeginInvoke(() =>
                {
                    AddSystem("Hub yeniden bağlandı.");
                    if (_roomId != null) btnSend.Enabled = true;
                });
                return Task.CompletedTask;
            };

            await _conn.StartAsync();
            AddSystem("Hub bağlantısı kuruldu.");
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
            if (_conn is null || _conn.State != HubConnectionState.Connected)
            {
                AddSystem("Hub bağlı değil (join).");
                return;
            }

            _roomId = roomId;
            lstMessages.Items.Clear();
            await _conn.InvokeAsync("JoinRoom", _userId, roomId);
            AddSystem($"Odaya katıldın: {roomName}");
            btnSend.Enabled = true;
            txtInput.Focus(); // odak inputa
        }

        // === UI yardımcıları ===
        private void AddChat(string user, string text)
        {
            lstMessages.Items.Add($"{user}: {text}");
            ScrollMessagesToBottom();
        }

        private void AddSystem(string text)
        {
            lstMessages.Items.Add($"[Sistem] {text}");
            ScrollMessagesToBottom();
        }

        private void ScrollMessagesToBottom()
        {
            // otomatik en alta kaydır
            var count = lstMessages.Items.Count;
            if (count > 0)
                lstMessages.TopIndex = count - 1;
        }

        private record ComboItem(Guid Id, string Text)
        {
            public override string ToString() => Text;
        }
    }
}