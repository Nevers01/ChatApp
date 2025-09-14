using System.Drawing;
using System.Windows.Forms;

namespace Chat.Client
{
    partial class AuthForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private Label lblUser;
        private TextBox txtUser;
        private Label lblPass;
        private TextBox txtPass;
        private Button btnLogin;
        private Button btnRegister;
        private Label lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblUser = new Label();
            txtUser = new TextBox();
            lblPass = new Label();
            txtPass = new TextBox();
            btnLogin = new Button();
            btnRegister = new Button();
            lblStatus = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Location = new Point(100, 38);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(48, 23);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Login";
            // 
            // lblUser
            // 
            lblUser.Location = new Point(49, 101);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(156, 23);
            lblUser.TabIndex = 3;
            lblUser.Text = "Kullanıcı Adı";
            // 
            // txtUser
            // 
            txtUser.Location = new Point(49, 127);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(156, 27);
            txtUser.TabIndex = 4;
            // 
            // lblPass
            // 
            lblPass.Location = new Point(49, 187);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(150, 21);
            lblPass.TabIndex = 5;
            lblPass.Text = "Şifre";
            // 
            // txtPass
            // 
            txtPass.Location = new Point(49, 211);
            txtPass.Name = "txtPass";
            txtPass.Size = new Size(150, 27);
            txtPass.TabIndex = 6;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(49, 258);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 37);
            btnLogin.TabIndex = 7;
            btnLogin.Text = "Giriş Yap";
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(130, 258);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(75, 37);
            btnRegister.TabIndex = 8;
            btnRegister.Text = "Kayıt Ol";
            // 
            // lblStatus
            // 
            lblStatus.Location = new Point(78, 309);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(100, 23);
            lblStatus.TabIndex = 9;
            // 
            // AuthForm
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(257, 386);
            Controls.Add(lblTitle);
            Controls.Add(lblUser);
            Controls.Add(txtUser);
            Controls.Add(lblPass);
            Controls.Add(txtPass);
            Controls.Add(btnLogin);
            Controls.Add(btnRegister);
            Controls.Add(lblStatus);
            Name = "AuthForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login / Register";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
