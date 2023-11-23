namespace Hydrix_Editor
{
    partial class NewProj
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewProj));
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            siticoneButton3 = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            siticoneButton1 = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            panel1 = new Panel();
            Browse = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            createproj = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            label3 = new Label();
            languagecombo = new Siticone.Desktop.UI.WinForms.SiticoneComboBox();
            label2 = new Label();
            label1 = new Label();
            projdirectory = new Siticone.Desktop.UI.WinForms.SiticoneTextBox();
            projname = new Siticone.Desktop.UI.WinForms.SiticoneTextBox();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(33, 0, 92);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(siticoneButton3);
            panel2.Controls.Add(siticoneButton1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(560, 30);
            panel2.TabIndex = 3;
            panel2.MouseDown += panel2_MouseDown;
            panel2.MouseMove += panel2_MouseMove;
            panel2.MouseUp += panel2_MouseUp;
            // 
            // pictureBox1
            // 
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(30, 30);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
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
            siticoneButton3.Location = new Point(494, 0);
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
            siticoneButton1.Location = new Point(527, 0);
            siticoneButton1.Name = "siticoneButton1";
            siticoneButton1.Size = new Size(33, 30);
            siticoneButton1.TabIndex = 2;
            siticoneButton1.Text = "✕";
            siticoneButton1.Click += siticoneButton1_Click_1;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(Browse);
            panel1.Controls.Add(createproj);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(languagecombo);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(projdirectory);
            panel1.Controls.Add(projname);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(560, 405);
            panel1.TabIndex = 4;
            // 
            // Browse
            // 
            Browse.BorderColor = Color.White;
            Browse.BorderThickness = 1;
            Browse.CustomBorderColor = Color.Pink;
            Browse.DisabledState.BorderColor = Color.DarkGray;
            Browse.DisabledState.CustomBorderColor = Color.DarkGray;
            Browse.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            Browse.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            Browse.FillColor = Color.Transparent;
            Browse.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Browse.ForeColor = Color.Pink;
            Browse.Location = new Point(326, 174);
            Browse.Name = "Browse";
            Browse.Size = new Size(105, 22);
            Browse.TabIndex = 7;
            Browse.Text = "Browse";
            Browse.Click += Browse_Click;
            // 
            // createproj
            // 
            createproj.BorderColor = Color.White;
            createproj.BorderThickness = 1;
            createproj.CustomBorderColor = Color.Pink;
            createproj.DisabledState.BorderColor = Color.DarkGray;
            createproj.DisabledState.CustomBorderColor = Color.DarkGray;
            createproj.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            createproj.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            createproj.FillColor = Color.Transparent;
            createproj.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            createproj.ForeColor = Color.Pink;
            createproj.Location = new Point(380, 336);
            createproj.Name = "createproj";
            createproj.Size = new Size(167, 56);
            createproj.TabIndex = 6;
            createproj.Text = "Create Project";
            createproj.Click += createproj_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Press Start 2P", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.Pink;
            label3.Location = new Point(11, 250);
            label3.Name = "label3";
            label3.Size = new Size(122, 12);
            label3.TabIndex = 5;
            label3.Text = "Language:";
            // 
            // languagecombo
            // 
            languagecombo.BackColor = Color.Transparent;
            languagecombo.DrawMode = DrawMode.OwnerDrawFixed;
            languagecombo.DropDownStyle = ComboBoxStyle.DropDownList;
            languagecombo.FillColor = Color.FromArgb(25, 17, 65);
            languagecombo.FocusedColor = Color.FromArgb(94, 148, 255);
            languagecombo.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            languagecombo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            languagecombo.ForeColor = Color.Pink;
            languagecombo.ItemHeight = 30;
            languagecombo.Items.AddRange(new object[] { "Assembly x86" });
            languagecombo.Location = new Point(11, 265);
            languagecombo.Name = "languagecombo";
            languagecombo.Size = new Size(174, 36);
            languagecombo.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Press Start 2P", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.Pink;
            label2.Location = new Point(11, 159);
            label2.Name = "label2";
            label2.Size = new Size(239, 12);
            label2.TabIndex = 3;
            label2.Text = "Project Directory:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Press Start 2P", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Pink;
            label1.Location = new Point(11, 69);
            label1.Name = "label1";
            label1.Size = new Size(174, 12);
            label1.TabIndex = 2;
            label1.Text = "Project Name:";
            // 
            // projdirectory
            // 
            projdirectory.DefaultText = "";
            projdirectory.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            projdirectory.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            projdirectory.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            projdirectory.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            projdirectory.FillColor = Color.FromArgb(25, 17, 65);
            projdirectory.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            projdirectory.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            projdirectory.ForeColor = Color.FromArgb(255, 192, 255);
            projdirectory.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            projdirectory.Location = new Point(11, 174);
            projdirectory.Name = "projdirectory";
            projdirectory.PasswordChar = '\0';
            projdirectory.PlaceholderText = "";
            projdirectory.SelectedText = "";
            projdirectory.Size = new Size(299, 22);
            projdirectory.TabIndex = 1;
            // 
            // projname
            // 
            projname.DefaultText = "";
            projname.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            projname.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            projname.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            projname.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            projname.FillColor = Color.FromArgb(25, 17, 65);
            projname.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            projname.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            projname.ForeColor = Color.FromArgb(255, 192, 255);
            projname.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            projname.Location = new Point(11, 84);
            projname.Name = "projname";
            projname.PasswordChar = '\0';
            projname.PlaceholderText = "";
            projname.SelectedText = "";
            projname.Size = new Size(299, 22);
            projname.TabIndex = 0;
            // 
            // NewProj
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 17, 65);
            ClientSize = new Size(560, 405);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "NewProj";
            Text = "Hydrix Studio";
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Siticone.Desktop.UI.WinForms.SiticoneButton siticoneButton3;
        private Siticone.Desktop.UI.WinForms.SiticoneButton siticoneButton1;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Siticone.Desktop.UI.WinForms.SiticoneTextBox projdirectory;
        private Siticone.Desktop.UI.WinForms.SiticoneTextBox projname;
        private Label label1;
        private Label label2;
        private Siticone.Desktop.UI.WinForms.SiticoneComboBox languagecombo;
        private Label label3;
        private Siticone.Desktop.UI.WinForms.SiticoneButton createproj;
        private Siticone.Desktop.UI.WinForms.SiticoneButton Browse;
    }
}