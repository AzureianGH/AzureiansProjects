namespace AzuriCore
{
    partial class AzuriCoreMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AzuriCoreMain));
            panel1 = new Panel();
            panel3 = new Panel();
            minimizemaxbutton = new Button();
            closebutton = new Button();
            loadtxt = new Label();
            progressBar1 = new ProgressBar();
            panel2 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(32, 32, 32);
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(minimizemaxbutton);
            panel1.Controls.Add(closebutton);
            panel1.Location = new Point(1, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(791, 49);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            panel1.MouseDown += mouseDown_Event;
            panel1.MouseMove += mouseMove_Event;
            panel1.MouseUp += mouseUp_Event;
            // 
            // panel3
            // 
            panel3.BackgroundImage = (Image)resources.GetObject("panel3.BackgroundImage");
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(231, 44);
            panel3.TabIndex = 2;
            // 
            // minimizemaxbutton
            // 
            minimizemaxbutton.Cursor = Cursors.Hand;
            minimizemaxbutton.FlatAppearance.BorderSize = 0;
            minimizemaxbutton.FlatStyle = FlatStyle.Flat;
            minimizemaxbutton.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point);
            minimizemaxbutton.ForeColor = Color.RosyBrown;
            minimizemaxbutton.Location = new Point(712, 3);
            minimizemaxbutton.Name = "minimizemaxbutton";
            minimizemaxbutton.Size = new Size(34, 37);
            minimizemaxbutton.TabIndex = 1;
            minimizemaxbutton.Text = "⎯";
            minimizemaxbutton.UseVisualStyleBackColor = true;
            minimizemaxbutton.Click += minimizemaxbutton_Click;
            // 
            // closebutton
            // 
            closebutton.Cursor = Cursors.Hand;
            closebutton.FlatAppearance.BorderSize = 0;
            closebutton.FlatStyle = FlatStyle.Flat;
            closebutton.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point);
            closebutton.ForeColor = Color.Red;
            closebutton.Location = new Point(752, 3);
            closebutton.Name = "closebutton";
            closebutton.Size = new Size(34, 37);
            closebutton.TabIndex = 0;
            closebutton.Text = "✕";
            closebutton.UseVisualStyleBackColor = true;
            closebutton.Click += closebutton_Click;
            // 
            // loadtxt
            // 
            loadtxt.AutoSize = true;
            loadtxt.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            loadtxt.ForeColor = Color.White;
            loadtxt.Location = new Point(430, 598);
            loadtxt.Name = "loadtxt";
            loadtxt.Size = new Size(0, 21);
            loadtxt.TabIndex = 1;
            loadtxt.TextAlign = ContentAlignment.TopCenter;
            loadtxt.ParentChanged += loadtxt_ParentChanged;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(430, 620);
            progressBar1.Maximum = 50;
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(360, 19);
            progressBar1.Step = 50;
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.TabIndex = 0;
            progressBar1.UseWaitCursor = true;
            progressBar1.Click += progressBar1_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(24, 24, 24);
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(loadtxt);
            panel2.Controls.Add(progressBar1);
            panel2.Location = new Point(1, 44);
            panel2.Name = "panel2";
            panel2.Size = new Size(791, 644);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
            // 
            // AzuriCoreMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 24);
            ClientSize = new Size(793, 688);
            ControlBox = false;
            Controls.Add(panel2);
            Controls.Add(panel1);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AzuriCoreMain";
            Text = "AzuriCore";
            Load += AzuriCoreMain_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button closebutton;
        private Button minimizemaxbutton;
        private Panel panel3;
        private ProgressBar progressBar1;
        private Label loadtxt;
    }
}