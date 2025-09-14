using System.Drawing;
using System.Windows.Forms;

namespace Chat.Client
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            btnSend = new ReaLTaiizor.Controls.MaterialButton();
            txtInput = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            lstMessages = new ReaLTaiizor.Controls.MaterialListBox();
            lstUsers = new ReaLTaiizor.Controls.MaterialListBox();
            btnJoinSelected = new ReaLTaiizor.Controls.MaterialButton();
            cmbRooms = new ReaLTaiizor.Controls.MaterialComboBox();
            btnRandom = new ReaLTaiizor.Controls.MaterialButton();
            SuspendLayout();
            // 
            // btnSend
            // 
            btnSend.AutoSize = false;
            btnSend.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSend.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSend.Depth = 0;
            btnSend.HighEmphasis = true;
            btnSend.Icon = null;
            btnSend.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            btnSend.Location = new Point(722, 492);
            btnSend.Margin = new Padding(4, 6, 4, 6);
            btnSend.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnSend.Name = "btnSend";
            btnSend.NoAccentTextColor = Color.Empty;
            btnSend.Size = new Size(118, 48);
            btnSend.TabIndex = 7;
            btnSend.Text = "Gönder";
            btnSend.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSend.UseAccentColor = false;
            btnSend.UseVisualStyleBackColor = true;
            // 
            // txtInput
            // 
            txtInput.AnimateReadOnly = false;
            txtInput.AutoCompleteMode = AutoCompleteMode.None;
            txtInput.AutoCompleteSource = AutoCompleteSource.None;
            txtInput.BackgroundImageLayout = ImageLayout.None;
            txtInput.CharacterCasing = CharacterCasing.Normal;
            txtInput.Depth = 0;
            txtInput.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtInput.HideSelection = true;
            txtInput.LeadingIcon = null;
            txtInput.Location = new Point(12, 492);
            txtInput.MaxLength = 32767;
            txtInput.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            txtInput.Name = "txtInput";
            txtInput.PasswordChar = '\0';
            txtInput.PrefixSuffixText = null;
            txtInput.ReadOnly = false;
            txtInput.RightToLeft = RightToLeft.No;
            txtInput.SelectedText = "";
            txtInput.SelectionLength = 0;
            txtInput.SelectionStart = 0;
            txtInput.ShortcutsEnabled = true;
            txtInput.Size = new Size(703, 48);
            txtInput.TabIndex = 8;
            txtInput.TabStop = false;
            txtInput.TextAlign = HorizontalAlignment.Left;
            txtInput.TrailingIcon = null;
            txtInput.UseSystemPasswordChar = false;
            // 
            // lstMessages
            // 
            lstMessages.BackColor = Color.White;
            lstMessages.BorderColor = Color.LightGray;
            lstMessages.Depth = 0;
            lstMessages.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            lstMessages.Location = new Point(12, 12);
            lstMessages.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lstMessages.Name = "lstMessages";
            lstMessages.SelectedIndex = -1;
            lstMessages.SelectedItem = null;
            lstMessages.Size = new Size(828, 471);
            lstMessages.TabIndex = 9;
            // 
            // lstUsers
            // 
            lstUsers.BackColor = Color.White;
            lstUsers.BorderColor = Color.LightGray;
            lstUsers.Depth = 0;
            lstUsers.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            lstUsers.Location = new Point(846, 12);
            lstUsers.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lstUsers.Name = "lstUsers";
            lstUsers.SelectedIndex = -1;
            lstUsers.SelectedItem = null;
            lstUsers.Size = new Size(223, 359);
            lstUsers.TabIndex = 10;
            // 
            // btnJoinSelected
            // 
            btnJoinSelected.AutoSize = false;
            btnJoinSelected.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnJoinSelected.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnJoinSelected.Depth = 0;
            btnJoinSelected.HighEmphasis = true;
            btnJoinSelected.Icon = null;
            btnJoinSelected.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            btnJoinSelected.Location = new Point(846, 492);
            btnJoinSelected.Margin = new Padding(4, 6, 4, 6);
            btnJoinSelected.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnJoinSelected.Name = "btnJoinSelected";
            btnJoinSelected.NoAccentTextColor = Color.Empty;
            btnJoinSelected.Size = new Size(223, 48);
            btnJoinSelected.TabIndex = 11;
            btnJoinSelected.Text = "Seçili Odaya Katıl";
            btnJoinSelected.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            btnJoinSelected.UseAccentColor = false;
            btnJoinSelected.UseVisualStyleBackColor = true;
            // 
            // cmbRooms
            // 
            cmbRooms.AutoResize = false;
            cmbRooms.BackColor = Color.FromArgb(255, 255, 255);
            cmbRooms.Depth = 0;
            cmbRooms.DrawMode = DrawMode.OwnerDrawVariable;
            cmbRooms.DropDownHeight = 174;
            cmbRooms.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRooms.DropDownWidth = 121;
            cmbRooms.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbRooms.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbRooms.FormattingEnabled = true;
            cmbRooms.IntegralHeight = false;
            cmbRooms.ItemHeight = 43;
            cmbRooms.Location = new Point(846, 434);
            cmbRooms.MaxDropDownItems = 4;
            cmbRooms.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            cmbRooms.Name = "cmbRooms";
            cmbRooms.Size = new Size(221, 49);
            cmbRooms.StartIndex = 0;
            cmbRooms.TabIndex = 12;
            // 
            // btnRandom
            // 
            btnRandom.AutoSize = false;
            btnRandom.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRandom.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnRandom.Depth = 0;
            btnRandom.HighEmphasis = true;
            btnRandom.Icon = null;
            btnRandom.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            btnRandom.Location = new Point(846, 380);
            btnRandom.Margin = new Padding(4, 6, 4, 6);
            btnRandom.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnRandom.Name = "btnRandom";
            btnRandom.NoAccentTextColor = Color.Empty;
            btnRandom.Size = new Size(223, 45);
            btnRandom.TabIndex = 13;
            btnRandom.Text = "Rastgele Odaya Katıl";
            btnRandom.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            btnRandom.UseAccentColor = false;
            btnRandom.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1081, 555);
            Controls.Add(btnRandom);
            Controls.Add(cmbRooms);
            Controls.Add(btnJoinSelected);
            Controls.Add(lstUsers);
            Controls.Add(lstMessages);
            Controls.Add(txtInput);
            Controls.Add(btnSend);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chaliyo";
            ResumeLayout(false);
        }
        #endregion

        private ReaLTaiizor.Controls.MaterialButton btnSend;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit txtInput;
        private ReaLTaiizor.Controls.MaterialListBox lstMessages;
        private ReaLTaiizor.Controls.MaterialListBox lstUsers;
        private ReaLTaiizor.Controls.MaterialButton btnJoinSelected;
        private ReaLTaiizor.Controls.MaterialComboBox cmbRooms;
        private ReaLTaiizor.Controls.MaterialButton btnRandom;
    }
}
