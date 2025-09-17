using Chat.Contracts;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat.Client
{
    public partial class RegisterForm : Form
    {
        public string BaseUrl { get; }
        public AuthResponse? RegisteredAuth { get; private set; }

        public RegisterForm(string baseUrl)
        {
            BaseUrl = baseUrl;
            InitializeComponent();

            // Splash görünüm
            FormBorderStyle = FormBorderStyle.None;    // kenarlık yok
            StartPosition = FormStartPosition.CenterParent;
            TopMost = true;
            Width = 420;
            Height = 360;
            BackColor = System.Drawing.Color.White;

            // ESC kapatsın
            KeyPreview = true;
            this.KeyDown += (_, e) => { if (e.KeyCode == Keys.Escape) Close(); };

            // Şifre gizli / göster
            txtPass.UseSystemPasswordChar = true;
            txtPass2.UseSystemPasswordChar = true;
            chkShowPass.CheckedChanged += (_, __) =>
            {
                bool show = chkShowPass.Checked;
                txtPass.UseSystemPasswordChar = !show;
                txtPass2.UseSystemPasswordChar = !show;
            };

            // Enter = Kayıt
            this.AcceptButton = btnRegister;
            txtPass2.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    btnRegister.PerformClick();
                }
            };

            // Butonlar
            btnClose.Click += (_, __) => Close();
            btnRegister.Click += async (_, __) => await DoRegisterAsync();
        }

        private async Task DoRegisterAsync()
        {
            lblStatus.Text = "";
            var user = txtUser.Text.Trim();
            var email = txtEmail.Text.Trim();
            var pass1 = txtPass.Text;
            var pass2 = txtPass2.Text;

            if (string.IsNullOrWhiteSpace(user) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(pass1) ||
                string.IsNullOrWhiteSpace(pass2))
            {
                lblStatus.Text = "Tüm alanlar zorunlu.";
                return;
            }

            if (pass1 != pass2)
            {
                lblStatus.Text = "Şifreler eşleşmiyor.";
                return;
            }

            try
            {
                btnRegister.Enabled = false;
                using var http = new HttpClient { BaseAddress = new Uri(BaseUrl) };
                var req = new RegisterRequest(user, email, pass1);
                var resp = await http.PostAsJsonAsync("/auth/register", req);
                if (!resp.IsSuccessStatusCode)
                {
                    lblStatus.Text = $"Kayıt başarısız: {(int)resp.StatusCode}";
                    return;
                }

                var auth = await resp.Content.ReadFromJsonAsync<AuthResponse>();
                if (auth is null)
                {
                    lblStatus.Text = "Sunucu yanıtı okunamadı.";
                    return;
                }

                RegisteredAuth = auth;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Hata: {ex.Message}";
            }
            finally
            {
                btnRegister.Enabled = true;
            }
        }
    }
}