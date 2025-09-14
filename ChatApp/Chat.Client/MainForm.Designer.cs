using System.Drawing;
using System.Windows.Forms;

namespace Chat.Client
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        // ---- UI kontrolleri (kod-behind'da kullandıklarınla birebir aynı isimler) ----
        private Button btnRandom;
        private Button btnJoinSelected;
        private Button btnSend;
        private ComboBox cmbRooms;
        private ListBox lstMessages;
        private ListBox lstUsers;
        private TextBox txtInput;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            btnRandom = new Button();
            cmbRooms = new ComboBox();
            btnJoinSelected = new Button();
            lstMessages = new ListBox();
            lstUsers = new ListBox();
            txtInput = new TextBox();
            btnSend = new Button();
            SuspendLayout();
            // 
            // btnRandom
            // 
            btnRandom.Location = new Point(846, 295);
            btnRandom.Margin = new Padding(3, 4, 3, 4);
            btnRandom.Name = "btnRandom";
            btnRandom.Size = new Size(223, 52);
            btnRandom.TabIndex = 0;
            btnRandom.Text = "Rastgele Katıl";
            // 
            // cmbRooms
            // 
            cmbRooms.Location = new Point(846, 387);
            cmbRooms.Margin = new Padding(3, 4, 3, 4);
            cmbRooms.Name = "cmbRooms";
            cmbRooms.Size = new Size(223, 28);
            cmbRooms.TabIndex = 1;
            // 
            // btnJoinSelected
            // 
            btnJoinSelected.Location = new Point(846, 435);
            btnJoinSelected.Margin = new Padding(3, 4, 3, 4);
            btnJoinSelected.Name = "btnJoinSelected";
            btnJoinSelected.Size = new Size(223, 41);
            btnJoinSelected.TabIndex = 2;
            btnJoinSelected.Text = "Seçili Odaya Katıl";
            // 
            // lstMessages
            // 
            lstMessages.Location = new Point(12, 13);
            lstMessages.Margin = new Padding(3, 4, 3, 4);
            lstMessages.Name = "lstMessages";
            lstMessages.Size = new Size(828, 384);
            lstMessages.TabIndex = 3;
            // 
            // lstUsers
            // 
            lstUsers.Location = new Point(846, 13);
            lstUsers.Margin = new Padding(3, 4, 3, 4);
            lstUsers.Name = "lstUsers";
            lstUsers.Size = new Size(223, 264);
            lstUsers.TabIndex = 4;
            // 
            // txtInput
            // 
            txtInput.Location = new Point(12, 435);
            txtInput.Margin = new Padding(3, 4, 3, 4);
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(700, 27);
            txtInput.TabIndex = 5;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(718, 435);
            btnSend.Margin = new Padding(3, 4, 3, 4);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(122, 27);
            btnSend.TabIndex = 6;
            btnSend.Text = "Gönder";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1081, 555);
            Controls.Add(btnRandom);
            Controls.Add(cmbRooms);
            Controls.Add(btnJoinSelected);
            Controls.Add(lstMessages);
            Controls.Add(lstUsers);
            Controls.Add(txtInput);
            Controls.Add(btnSend);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chat.Client - MainForm";
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
    }
}
