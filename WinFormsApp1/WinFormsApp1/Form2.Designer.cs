namespace WinFormsApp1
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            thunderForm1 = new ReaLTaiizor.Forms.ThunderForm();
            SuspendLayout();
            // 
            // thunderForm1
            // 
            thunderForm1.BackColor = SystemColors.Highlight;
            thunderForm1.BodyColorA = Color.White;
            thunderForm1.BodyColorB = Color.FromArgb(255, 128, 128);
            thunderForm1.BodyColorC = Color.FromArgb(192, 64, 0);
            thunderForm1.BodyColorD = Color.FromArgb(0, 192, 0);
            thunderForm1.Dock = DockStyle.Fill;
            thunderForm1.ForeColor = Color.RosyBrown;
            thunderForm1.Image = null;
            thunderForm1.Location = new Point(0, 0);
            thunderForm1.MinimumSize = new Size(270, 50);
            thunderForm1.Name = "thunderForm1";
            thunderForm1.Padding = new Padding(11, 29, 11, 6);
            thunderForm1.Size = new Size(800, 450);
            thunderForm1.TabIndex = 0;
            thunderForm1.Text = "thunderForm1";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(thunderForm1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form2";
            Text = "Form2";
            TransparencyKey = Color.Fuchsia;
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Forms.ThunderForm thunderForm1;
    }
}