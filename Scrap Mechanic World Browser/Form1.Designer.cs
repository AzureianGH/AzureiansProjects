namespace Scrap_Mechanic_World_Browser
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openSMFileToolStripMenuItem = new ToolStripMenuItem();
            closeToolStripMenuItem = new ToolStripMenuItem();
            openSMFileToolStripMenuItem1 = new ToolStripMenuItem();
            panel1 = new Panel();
            groupBox1 = new GroupBox();
            worldnamelabel = new Label();
            flagslabel = new Label();
            timeinlabel = new Label();
            gticklabel = new Label();
            ismoddedlabel = new Label();
            seedlabel = new Label();
            saveverlabel = new Label();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1219, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openSMFileToolStripMenuItem, closeToolStripMenuItem, openSMFileToolStripMenuItem1 });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // openSMFileToolStripMenuItem
            // 
            openSMFileToolStripMenuItem.Name = "openSMFileToolStripMenuItem";
            openSMFileToolStripMenuItem.Size = new Size(203, 22);
            openSMFileToolStripMenuItem.Text = "Open DB File";
            openSMFileToolStripMenuItem.Click += openSMFileToolStripMenuItem_Click;
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(203, 22);
            closeToolStripMenuItem.Text = "Save DB File";
            // 
            // openSMFileToolStripMenuItem1
            // 
            openSMFileToolStripMenuItem1.Name = "openSMFileToolStripMenuItem1";
            openSMFileToolStripMenuItem1.Size = new Size(203, 22);
            openSMFileToolStripMenuItem1.Text = "Close SM World Browser";
            openSMFileToolStripMenuItem1.Click += openSMFileToolStripMenuItem1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonHighlight;
            panel1.Controls.Add(groupBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(1219, 739);
            panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(worldnamelabel);
            groupBox1.Controls.Add(flagslabel);
            groupBox1.Controls.Add(timeinlabel);
            groupBox1.Controls.Add(gticklabel);
            groupBox1.Controls.Add(ismoddedlabel);
            groupBox1.Controls.Add(seedlabel);
            groupBox1.Controls.Add(saveverlabel);
            groupBox1.Location = new Point(12, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(299, 139);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Basic Data";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // worldnamelabel
            // 
            worldnamelabel.AutoSize = true;
            worldnamelabel.ForeColor = Color.Purple;
            worldnamelabel.Location = new Point(6, 19);
            worldnamelabel.Name = "worldnamelabel";
            worldnamelabel.Size = new Size(102, 15);
            worldnamelabel.TabIndex = 6;
            worldnamelabel.Text = "World Name: N/A";
            // 
            // flagslabel
            // 
            flagslabel.AutoSize = true;
            flagslabel.Location = new Point(6, 116);
            flagslabel.Name = "flagslabel";
            flagslabel.Size = new Size(62, 15);
            flagslabel.TabIndex = 5;
            flagslabel.Text = "Flags: N/A";
            // 
            // timeinlabel
            // 
            timeinlabel.AutoSize = true;
            timeinlabel.Location = new Point(6, 86);
            timeinlabel.Name = "timeinlabel";
            timeinlabel.Size = new Size(109, 15);
            timeinlabel.TabIndex = 4;
            timeinlabel.Text = "Time in World: N/A";
            // 
            // gticklabel
            // 
            gticklabel.AutoSize = true;
            gticklabel.Location = new Point(6, 71);
            gticklabel.Name = "gticklabel";
            gticklabel.Size = new Size(90, 15);
            gticklabel.TabIndex = 3;
            gticklabel.Text = "Game Tick: N/A";
            // 
            // ismoddedlabel
            // 
            ismoddedlabel.AutoSize = true;
            ismoddedlabel.Location = new Point(6, 101);
            ismoddedlabel.Name = "ismoddedlabel";
            ismoddedlabel.Size = new Size(91, 15);
            ismoddedlabel.TabIndex = 2;
            ismoddedlabel.Text = "Is Modded: N/A";
            ismoddedlabel.Click += label3_Click;
            // 
            // seedlabel
            // 
            seedlabel.AutoSize = true;
            seedlabel.Location = new Point(6, 56);
            seedlabel.Name = "seedlabel";
            seedlabel.Size = new Size(60, 15);
            seedlabel.TabIndex = 1;
            seedlabel.Text = "Seed: N/A";
            seedlabel.Click += label2_Click;
            // 
            // saveverlabel
            // 
            saveverlabel.AutoSize = true;
            saveverlabel.Location = new Point(6, 41);
            saveverlabel.Name = "saveverlabel";
            saveverlabel.Size = new Size(100, 15);
            saveverlabel.TabIndex = 0;
            saveverlabel.Text = "Save Version: N/A";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1219, 763);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "SM World Browser";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openSMFileToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripMenuItem openSMFileToolStripMenuItem1;
        private Panel panel1;
        private GroupBox groupBox1;
        private Label seedlabel;
        private Label saveverlabel;
        private Label gticklabel;
        private Label ismoddedlabel;
        private Label worldnamelabel;
        private Label flagslabel;
        private Label timeinlabel;
    }
}