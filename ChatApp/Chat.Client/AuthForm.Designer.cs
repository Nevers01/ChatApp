using System.Drawing;
using System.Windows.Forms;

namespace Chat.Client
{
    partial class AuthForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblStatus = new Label();
            btnLogin = new ReaLTaiizor.Controls.MaterialButton();
            btnRegister = new ReaLTaiizor.Controls.MaterialButton();
            txtPass = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            lblPass = new ReaLTaiizor.Controls.MaterialLabel();
            txtUser = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            lblUser = new ReaLTaiizor.Controls.MaterialLabel();
            SuspendLayout();
            // 
            // lblStatus
            // 
            lblStatus.Location = new Point(178, 416);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(144, 25);
            lblStatus.TabIndex = 9;
            // 
            // btnLogin
            // 
            btnLogin.AutoSize = false;
            btnLogin.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnLogin.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnLogin.Depth = 0;
            btnLogin.HighEmphasis = true;
            btnLogin.Icon = null;
            btnLogin.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            btnLogin.Location = new Point(122, 287);
            btnLogin.Margin = new Padding(4, 6, 4, 6);
            btnLogin.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnLogin.Name = "btnLogin";
            btnLogin.NoAccentTextColor = Color.Empty;
            btnLogin.Size = new Size(251, 51);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Giriş Yap";
            btnLogin.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            btnLogin.UseAccentColor = false;
            btnLogin.UseVisualStyleBackColor = true;
            // 
            // btnRegister
            // 
            btnRegister.AutoSize = false;
            btnRegister.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRegister.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnRegister.Depth = 0;
            btnRegister.HighEmphasis = true;
            btnRegister.Icon = null;
            btnRegister.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            btnRegister.Location = new Point(153, 350);
            btnRegister.Margin = new Padding(4, 6, 4, 6);
            btnRegister.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnRegister.Name = "btnRegister";
            btnRegister.NoAccentTextColor = Color.Empty;
            btnRegister.Size = new Size(193, 45);
            btnRegister.TabIndex = 11;
            btnRegister.Text = "Kayıt Ol";
            btnRegister.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            btnRegister.UseAccentColor = false;
            btnRegister.UseVisualStyleBackColor = true;
            // 
            // txtPass
            // 
            txtPass.AnimateReadOnly = false;
            txtPass.AutoCompleteMode = AutoCompleteMode.None;
            txtPass.AutoCompleteSource = AutoCompleteSource.None;
            txtPass.BackgroundImageLayout = ImageLayout.None;
            txtPass.CharacterCasing = CharacterCasing.Normal;
            txtPass.Depth = 0;
            txtPass.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtPass.HideSelection = true;
            txtPass.LeadingIcon = null;
            txtPass.Location = new Point(122, 210);
            txtPass.MaxLength = 32767;
            txtPass.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            txtPass.Name = "txtPass";
            txtPass.PasswordChar = '\0';
            txtPass.PrefixSuffixText = null;
            txtPass.ReadOnly = false;
            txtPass.RightToLeft = RightToLeft.No;
            txtPass.SelectedText = "";
            txtPass.SelectionLength = 0;
            txtPass.SelectionStart = 0;
            txtPass.ShortcutsEnabled = true;
            txtPass.Size = new Size(251, 48);
            txtPass.TabIndex = 1;
            txtPass.TabStop = false;
            txtPass.TextAlign = HorizontalAlignment.Left;
            txtPass.TrailingIcon = null;
            txtPass.UseSystemPasswordChar = false;
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Depth = 0;
            lblPass.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblPass.Location = new Point(122, 188);
            lblPass.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(34, 19);
            lblPass.TabIndex = 13;
            lblPass.Text = "Şifre";
            // 
            // txtUser
            // 
            txtUser.AnimateReadOnly = false;
            txtUser.AutoCompleteMode = AutoCompleteMode.None;
            txtUser.AutoCompleteSource = AutoCompleteSource.None;
            txtUser.BackgroundImageLayout = ImageLayout.None;
            txtUser.CharacterCasing = CharacterCasing.Normal;
            txtUser.Depth = 0;
            txtUser.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtUser.HideSelection = true;
            txtUser.LeadingIcon = null;
            txtUser.Location = new Point(122, 120);
            txtUser.MaxLength = 32767;
            txtUser.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            txtUser.Name = "txtUser";
            txtUser.PasswordChar = '\0';
            txtUser.PrefixSuffixText = null;
            txtUser.ReadOnly = false;
            txtUser.RightToLeft = RightToLeft.No;
            txtUser.SelectedText = "";
            txtUser.SelectionLength = 0;
            txtUser.SelectionStart = 0;
            txtUser.ShortcutsEnabled = true;
            txtUser.Size = new Size(251, 48);
            txtUser.TabIndex = 0;
            txtUser.TabStop = false;
            txtUser.TextAlign = HorizontalAlignment.Left;
            txtUser.TrailingIcon = null;
            txtUser.UseSystemPasswordChar = false;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Depth = 0;
            lblUser.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblUser.Location = new Point(122, 98);
            lblUser.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(89, 19);
            lblUser.TabIndex = 15;
            lblUser.Text = "Kullanıcı Adı";
            // 
            // AuthForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(501, 474);
            Controls.Add(lblUser);
            Controls.Add(txtUser);
            Controls.Add(lblPass);
            Controls.Add(txtPass);
            Controls.Add(btnRegister);
            Controls.Add(btnLogin);
            Controls.Add(lblStatus);
            Name = "AuthForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chatliyo | Login";
            ResumeLayout(false);
            PerformLayout();
        }
        private ReaLTaiizor.Controls.MaterialButton btnLogin;
        private ReaLTaiizor.Controls.MaterialButton btnRegister;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit txtPass;
        private ReaLTaiizor.Controls.MaterialLabel lblPass;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit txtUser;
        private ReaLTaiizor.Controls.MaterialLabel lblUser;
    }
}
