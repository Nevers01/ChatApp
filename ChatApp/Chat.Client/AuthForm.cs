using Chat.Contracts;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat.Client
{
    public partial class AuthForm : Form
    {
        public Guid AuthenticatedUserId { get; private set; }
        public string BaseUrl => "http://141.98.112.152:5000";

        public AuthForm()
        {
            InitializeComponent();

            // Şifre gizli
            txtPass.UseSystemPasswordChar = true;

            // Enter = Login
            this.AcceptButton = btnLogin;
            txtPass.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    btnLogin.PerformClick();
                }
            };

            btnLogin.Click += async (_, __) => await DoLoginAsync();

            // "Kayıt Ol" → RegisterForm'u aç
            btnRegister.Click += (_, __) =>
            {
                using var rf = new RegisterForm(BaseUrl);  // BaseUrl’ini AuthForm’da zaten tutuyorsun
                var r = rf.ShowDialog(this);               // modal (splash gibi)
                if (r == DialogResult.OK && rf.RegisteredAuth is not null)
                {
                    // Kayıt başarılı → istersen direkt login kabul edip ana forma geç
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                // else: kullanıcı pencereyi kapatmıştır; AuthForm açık kalır
            };
        }

        private async Task DoLoginAsync()
        {
            lblStatus.Text = "";
            var user = txtUser.Text.Trim();
            var pass = txtPass.Text;

            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
            {
                lblStatus.Text = "Kullanıcı ve şifre zorunlu.";
                return;
            }

            try
            {
                using var http = new HttpClient { BaseAddress = new Uri(BaseUrl) };
                var resp = await http.PostAsJsonAsync("/auth/login", new LoginRequest(user, pass));
                if (!resp.IsSuccessStatusCode)
                {
                    lblStatus.Text = "Giriş başarısız (kullanıcı/şifre?).";
                    return;
                }

                var auth = await resp.Content.ReadFromJsonAsync<AuthResponse>();
                if (auth is null)
                {
                    lblStatus.Text = "Sunucu yanıtı okunamadı.";
                    return;
                }

                AuthenticatedUserId = auth.UserId;
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