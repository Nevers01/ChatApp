using System.Drawing;
using System.Windows.Forms;

namespace Chat.Client
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;

        // ReaLTaiizor
        private ReaLTaiizor.Controls.MaterialButton btnRegister;
        private ReaLTaiizor.Controls.MaterialButton btnClose;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit txtUser;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit txtEmail;

        // WinForms
        private Panel topBar;
        private Label lblTitle;
        private Label lblUser;
        private Label lblEmail;
        private Label lblPass;
        private Label lblPass2;
        private TextBox txtPass;
        private TextBox txtPass2;
        private CheckBox chkShowPass;
        private Label lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            topBar = new Panel();
            lblTitle = new Label();
            btnClose = new ReaLTaiizor.Controls.MaterialButton();
            lblUser = new Label();
            lblEmail = new Label();
            lblPass = new Label();
            lblPass2 = new Label();
            txtUser = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            txtEmail = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            txtPass = new TextBox();
            txtPass2 = new TextBox();
            chkShowPass = new CheckBox();
            lblStatus = new Label();
            btnRegister = new ReaLTaiizor.Controls.MaterialButton();
            topBar.SuspendLayout();
            SuspendLayout();
            // 
            // topBar
            // 
            topBar.BackColor = Color.FromArgb(245, 245, 245);
            topBar.Controls.Add(lblTitle);
            topBar.Controls.Add(btnClose);
            topBar.Dock = DockStyle.Top;
            topBar.Location = new Point(0, 0);
            topBar.Name = "topBar";
            topBar.Size = new Size(520, 64);
            topBar.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(16, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(203, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Chatliyo — Kayıt";
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnClose.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnClose.Depth = 0;
            btnClose.HighEmphasis = true;
            btnClose.Icon = null;
            btnClose.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            btnClose.Location = new Point(609, 14);
            btnClose.Margin = new Padding(4, 6, 4, 6);
            btnClose.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnClose.Name = "btnClose";
            btnClose.NoAccentTextColor = Color.Empty;
            btnClose.Size = new Size(68, 36);
            btnClose.TabIndex = 1;
            btnClose.Text = "Kapat";
            btnClose.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            btnClose.UseAccentColor = false;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Location = new Point(40, 90);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(90, 20);
            lblUser.TabIndex = 1;
            lblUser.Text = "Kullanıcı adı";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(40, 170);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(60, 20);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "E-posta";
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Location = new Point(40, 250);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(39, 20);
            lblPass.TabIndex = 3;
            lblPass.Text = "Şifre";
            // 
            // lblPass2
            // 
            lblPass2.AutoSize = true;
            lblPass2.Location = new Point(40, 330);
            lblPass2.Name = "lblPass2";
            lblPass2.Size = new Size(91, 20);
            lblPass2.TabIndex = 4;
            lblPass2.Text = "Şifre (tekrar)";
            // 
            // txtUser
            // 
            txtUser.AnimateReadOnly = false;
            txtUser.AutoCompleteMode = AutoCompleteMode.None;
            txtUser.AutoCompleteSource = AutoCompleteSource.None;
            txtUser.BackgroundImageLayout = ImageLayout.None;
            txtUser.CharacterCasing = CharacterCasing.Normal;
            txtUser.Depth = 0;
            txtUser.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtUser.HideSelection = true;
            txtUser.Hint = "Kullanıcı adınız";
            txtUser.LeadingIcon = null;
            txtUser.Location = new Point(40, 115);
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
            txtUser.Size = new Size(440, 48);
            txtUser.TabIndex = 0;
            txtUser.TabStop = false;
            txtUser.TextAlign = HorizontalAlignment.Left;
            txtUser.TrailingIcon = null;
            txtUser.UseSystemPasswordChar = false;
            // 
            // txtEmail
            // 
            txtEmail.AnimateReadOnly = false;
            txtEmail.AutoCompleteMode = AutoCompleteMode.None;
            txtEmail.AutoCompleteSource = AutoCompleteSource.None;
            txtEmail.BackgroundImageLayout = ImageLayout.None;
            txtEmail.CharacterCasing = CharacterCasing.Normal;
            txtEmail.Depth = 0;
            txtEmail.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtEmail.HideSelection = true;
            txtEmail.Hint = "ornek@eposta.com";
            txtEmail.LeadingIcon = null;
            txtEmail.Location = new Point(40, 195);
            txtEmail.MaxLength = 32767;
            txtEmail.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            txtEmail.Name = "txtEmail";
            txtEmail.PasswordChar = '\0';
            txtEmail.PrefixSuffixText = null;
            txtEmail.ReadOnly = false;
            txtEmail.RightToLeft = RightToLeft.No;
            txtEmail.SelectedText = "";
            txtEmail.SelectionLength = 0;
            txtEmail.SelectionStart = 0;
            txtEmail.ShortcutsEnabled = true;
            txtEmail.Size = new Size(440, 48);
            txtEmail.TabIndex = 1;
            txtEmail.TabStop = false;
            txtEmail.TextAlign = HorizontalAlignment.Left;
            txtEmail.TrailingIcon = null;
            txtEmail.UseSystemPasswordChar = false;
            // 
            // txtPass
            // 
            txtPass.Location = new Point(40, 275);
            txtPass.Name = "txtPass";
            txtPass.Size = new Size(440, 27);
            txtPass.TabIndex = 2;
            txtPass.UseSystemPasswordChar = true;
            // 
            // txtPass2
            // 
            txtPass2.Location = new Point(40, 355);
            txtPass2.Name = "txtPass2";
            txtPass2.Size = new Size(440, 27);
            txtPass2.TabIndex = 3;
            txtPass2.UseSystemPasswordChar = true;
            // 
            // chkShowPass
            // 
            chkShowPass.AutoSize = true;
            chkShowPass.Location = new Point(40, 390);
            chkShowPass.Name = "chkShowPass";
            chkShowPass.Size = new Size(118, 24);
            chkShowPass.TabIndex = 4;
            chkShowPass.Text = "Şifreyi göster";
            // 
            // lblStatus
            // 
            lblStatus.ForeColor = Color.FromArgb(200, 40, 40);
            lblStatus.Location = new Point(40, 420);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(440, 24);
            lblStatus.TabIndex = 5;
            // 
            // btnRegister
            // 
            btnRegister.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRegister.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnRegister.Depth = 0;
            btnRegister.HighEmphasis = true;
            btnRegister.Icon = null;
            btnRegister.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            btnRegister.Location = new Point(40, 452);
            btnRegister.Margin = new Padding(4, 6, 4, 6);
            btnRegister.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnRegister.Name = "btnRegister";
            btnRegister.NoAccentTextColor = Color.Empty;
            btnRegister.Size = new Size(84, 36);
            btnRegister.TabIndex = 5;
            btnRegister.Text = "Kayıt Ol";
            btnRegister.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            btnRegister.UseAccentColor = false;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(520, 520);
            Controls.Add(topBar);
            Controls.Add(lblUser);
            Controls.Add(lblEmail);
            Controls.Add(lblPass);
            Controls.Add(lblPass2);
            Controls.Add(txtUser);
            Controls.Add(txtEmail);
            Controls.Add(txtPass);
            Controls.Add(txtPass2);
            Controls.Add(chkShowPass);
            Controls.Add(lblStatus);
            Controls.Add(btnRegister);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimumSize = new Size(520, 520);
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kayıt Ol";
            topBar.ResumeLayout(false);
            topBar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
