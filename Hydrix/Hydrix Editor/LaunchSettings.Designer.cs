namespace Hydrix_Editor
{
    partial class LaunchSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LaunchSettings));
            panel2 = new Panel();
            siticoneButton3 = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            siticoneButton1 = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            panel1 = new Panel();
            siticoneSeparator1 = new Siticone.Desktop.UI.WinForms.SiticoneSeparator();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            panel3 = new Panel();
            siticoneButton5 = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            siticoneButton4 = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            siticoneSeparator2 = new Siticone.Desktop.UI.WinForms.SiticoneSeparator();
            label4 = new Label();
            siticoneButton2 = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(33, 0, 92);
            panel2.Controls.Add(siticoneButton3);
            panel2.Controls.Add(siticoneButton1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(822, 30);
            panel2.TabIndex = 1;
            panel2.MouseDown += panel2_MouseDown;
            panel2.MouseMove += panel2_MouseMove;
            panel2.MouseUp += panel2_MouseUp;
            // 
            // siticoneButton3
            // 
            siticoneButton3.DisabledState.BorderColor = Color.DarkGray;
            siticoneButton3.DisabledState.CustomBorderColor = Color.DarkGray;
            siticoneButton3.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            siticoneButton3.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            siticoneButton3.Dock = DockStyle.Right;
            siticoneButton3.FillColor = Color.Transparent;
            siticoneButton3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            siticoneButton3.ForeColor = Color.White;
            siticoneButton3.Location = new Point(756, 0);
            siticoneButton3.Name = "siticoneButton3";
            siticoneButton3.Size = new Size(33, 30);
            siticoneButton3.TabIndex = 4;
            siticoneButton3.Text = "―";
            siticoneButton3.Click += siticoneButton3_Click;
            // 
            // siticoneButton1
            // 
            siticoneButton1.DisabledState.BorderColor = Color.DarkGray;
            siticoneButton1.DisabledState.CustomBorderColor = Color.DarkGray;
            siticoneButton1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            siticoneButton1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            siticoneButton1.Dock = DockStyle.Right;
            siticoneButton1.FillColor = Color.Transparent;
            siticoneButton1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            siticoneButton1.ForeColor = Color.White;
            siticoneButton1.Location = new Point(789, 0);
            siticoneButton1.Name = "siticoneButton1";
            siticoneButton1.Size = new Size(33, 30);
            siticoneButton1.TabIndex = 2;
            siticoneButton1.Text = "✕";
            siticoneButton1.Click += siticoneButton1_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(siticoneSeparator1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(822, 525);
            panel1.TabIndex = 2;
            panel1.Paint += panel1_Paint;
            // 
            // siticoneSeparator1
            // 
            siticoneSeparator1.Location = new Point(61, 305);
            siticoneSeparator1.Name = "siticoneSeparator1";
            siticoneSeparator1.Size = new Size(321, 9);
            siticoneSeparator1.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Press Start 2P", 12.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.Orchid;
            label3.Location = new Point(73, 338);
            label3.Name = "label3";
            label3.Size = new Size(314, 17);
            label3.TabIndex = 4;
            label3.Text = "Version 23Y11M20D";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI Light", 9F, FontStyle.Italic, GraphicsUnit.Point);
            label2.ForeColor = Color.LightPink;
            label2.Location = new Point(-2, 508);
            label2.Name = "label2";
            label2.Size = new Size(96, 15);
            label2.TabIndex = 3;
            label2.Text = "Created by Hydrix";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Press Start 2P", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Pink;
            label1.Location = new Point(90, 260);
            label1.Name = "label1";
            label1.Size = new Size(269, 19);
            label1.TabIndex = 2;
            label1.Text = "Hydrix Studio";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.HydrixLogoCutout;
            pictureBox2.InitialImage = Properties.Resources.HydrixLogoCutout;
            pictureBox2.Location = new Point(148, 61);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(148, 148);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(33, 0, 100);
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(siticoneButton5);
            panel3.Controls.Add(siticoneButton4);
            panel3.Controls.Add(siticoneSeparator2);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(siticoneButton2);
            panel3.Location = new Point(449, 30);
            panel3.Name = "panel3";
            panel3.Size = new Size(372, 494);
            panel3.TabIndex = 0;
            panel3.Paint += panel3_Paint;
            // 
            // siticoneButton5
            // 
            siticoneButton5.BorderColor = Color.Pink;
            siticoneButton5.BorderThickness = 1;
            siticoneButton5.DisabledState.BorderColor = Color.DarkGray;
            siticoneButton5.DisabledState.CustomBorderColor = Color.DarkGray;
            siticoneButton5.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            siticoneButton5.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            siticoneButton5.FillColor = Color.Transparent;
            siticoneButton5.Font = new Font("Press Start 2P", 12F, FontStyle.Bold, GraphicsUnit.Point);
            siticoneButton5.ForeColor = Color.White;
            siticoneButton5.Location = new Point(46, 176);
            siticoneButton5.Name = "siticoneButton5";
            siticoneButton5.PressedColor = Color.DimGray;
            siticoneButton5.Size = new Size(281, 35);
            siticoneButton5.TabIndex = 9;
            siticoneButton5.Text = "Open Project 📁";
            siticoneButton5.TextAlign = HorizontalAlignment.Left;
            siticoneButton5.Click += siticoneButton5_Click;
            // 
            // siticoneButton4
            // 
            siticoneButton4.BorderColor = Color.Pink;
            siticoneButton4.BorderRadius = 1;
            siticoneButton4.BorderThickness = 1;
            siticoneButton4.CustomBorderColor = Color.Pink;
            siticoneButton4.DisabledState.BorderColor = Color.DarkGray;
            siticoneButton4.DisabledState.CustomBorderColor = Color.DarkGray;
            siticoneButton4.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            siticoneButton4.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            siticoneButton4.FillColor = Color.FromArgb(33, 0, 100);
            siticoneButton4.Font = new Font("Press Start 2P", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            siticoneButton4.ForeColor = Color.White;
            siticoneButton4.Location = new Point(-1, 431);
            siticoneButton4.Name = "siticoneButton4";
            siticoneButton4.Size = new Size(372, 62);
            siticoneButton4.TabIndex = 8;
            siticoneButton4.Text = "Continue Without Project -";
            siticoneButton4.Click += siticoneButton4_Click;
            // 
            // siticoneSeparator2
            // 
            siticoneSeparator2.Location = new Point(46, 65);
            siticoneSeparator2.Name = "siticoneSeparator2";
            siticoneSeparator2.Size = new Size(281, 8);
            siticoneSeparator2.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Press Start 2P", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.Pink;
            label4.Location = new Point(72, 13);
            label4.Name = "label4";
            label4.Size = new Size(229, 19);
            label4.TabIndex = 6;
            label4.Text = "Get Started";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // siticoneButton2
            // 
            siticoneButton2.BorderColor = Color.Pink;
            siticoneButton2.BorderThickness = 1;
            siticoneButton2.DisabledState.BorderColor = Color.DarkGray;
            siticoneButton2.DisabledState.CustomBorderColor = Color.DarkGray;
            siticoneButton2.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            siticoneButton2.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            siticoneButton2.FillColor = Color.Transparent;
            siticoneButton2.Font = new Font("Press Start 2P", 12F, FontStyle.Bold, GraphicsUnit.Point);
            siticoneButton2.ForeColor = Color.White;
            siticoneButton2.Location = new Point(46, 113);
            siticoneButton2.Name = "siticoneButton2";
            siticoneButton2.PressedColor = Color.DimGray;
            siticoneButton2.Size = new Size(281, 35);
            siticoneButton2.TabIndex = 0;
            siticoneButton2.Text = "New Project  +";
            siticoneButton2.TextAlign = HorizontalAlignment.Left;
            siticoneButton2.Click += siticoneButton2_Click;
            // 
            // LaunchSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 17, 65);
            ClientSize = new Size(822, 525);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LaunchSettings";
            Text = "Hydrix Studio";
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Siticone.Desktop.UI.WinForms.SiticoneButton siticoneButton3;
        private Siticone.Desktop.UI.WinForms.SiticoneButton siticoneButton1;
        private Panel panel1;
        private Panel panel3;
        private PictureBox pictureBox2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Siticone.Desktop.UI.WinForms.SiticoneSeparator siticoneSeparator1;
        private Siticone.Desktop.UI.WinForms.SiticoneButton siticoneButton2;
        private Label label4;
        private Siticone.Desktop.UI.WinForms.SiticoneSeparator siticoneSeparator2;
        private Siticone.Desktop.UI.WinForms.SiticoneButton siticoneButton4;
        private Siticone.Desktop.UI.WinForms.SiticoneButton siticoneButton5;
    }
}