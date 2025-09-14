using Chat.Contracts;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace Chat.Client
{
    public partial class AuthForm : Form
    {
        public Guid AuthenticatedUserId { get; private set; }
        public string BaseUrl => "http://141.98.112.152:5000";

        public AuthForm()
        {
            InitializeComponent();

            btnLogin.Click += async (_, __) => await DoAuthAsync(isRegister: false);
            btnRegister.Click += async (_, __) => await DoAuthAsync(isRegister: true);
        }

        private async Task DoAuthAsync(bool isRegister)
        {
            lblStatus.Text = "";
            var baseUrl = BaseUrl;
            var user = txtUser.Text.Trim();
            var pass = txtPass.Text;

            if (string.IsNullOrWhiteSpace(baseUrl) || string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
            {
                lblStatus.Text = "Lütfen tüm alanları doldur.";
                return;
            }

            try
            {
                using var http = new HttpClient { BaseAddress = new Uri(baseUrl) };

                AuthResponse? auth = null;

                if (isRegister)
                {
                    var regResp = await http.PostAsJsonAsync("/auth/register", new RegisterRequest(user, pass));
                    if (!regResp.IsSuccessStatusCode)
                    {
                        lblStatus.Text = $"Kayıt başarısız: {(int)regResp.StatusCode}";
                        return;
                    }
                    auth = await regResp.Content.ReadFromJsonAsync<AuthResponse>();
                }
                else
                {
                    var loginResp = await http.PostAsJsonAsync("/auth/login", new LoginRequest(user, pass));
                    if (!loginResp.IsSuccessStatusCode)
                    {
                        lblStatus.Text = "Giriş başarısız (kullanıcı/şifre?).";
                        return;
                    }
                    auth = await loginResp.Content.ReadFromJsonAsync<AuthResponse>();
                }

                if (auth == null)
                {
                    lblStatus.Text = "Sunucudan geçerli yanıt alınamadı.";
                    return;
                }

                AuthenticatedUserId = auth.UserId;

                // Başarılı → MainForm’a geç
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Hata: {ex.Message}";
            }
        }
    }
}