namespace Hydrix_Editor
{
    partial class Mainwindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainwindow));
            statusStrip1 = new StatusStrip();
            updatebar = new ToolStripProgressBar();
            updatetext = new ToolStripStatusLabel();
            panel1 = new Panel();
            MainWindowContainer = new SplitContainer();
            panel4 = new Panel();
            treeView1 = new TreeView();
            CodeEditorHolder = new SplitContainer();
            siticoneTabControl2 = new Siticone.Desktop.UI.WinForms.SiticoneTabControl();
            label2 = new Label();
            siticoneTabControl1 = new Siticone.Desktop.UI.WinForms.SiticoneTabControl();
            errors = new TabPage();
            output = new TabPage();
            outputtxt = new RichTextBox();
            panel3 = new Panel();
            toolsidebar = new ToolStrip();
            NewProjTool = new ToolStripButton();
            loadprojbuttontool = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            toolsavebutton = new ToolStripButton();
            toolrecursivesave = new ToolStripButton();
            toolnewfile = new ToolStripButton();
            toolopenfile = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            maintoolbar = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            openProjectToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MainWindowContainer).BeginInit();
            MainWindowContainer.Panel1.SuspendLayout();
            MainWindowContainer.Panel2.SuspendLayout();
            MainWindowContainer.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CodeEditorHolder).BeginInit();
            CodeEditorHolder.Panel1.SuspendLayout();
            CodeEditorHolder.Panel2.SuspendLayout();
            CodeEditorHolder.SuspendLayout();
            siticoneTabControl1.SuspendLayout();
            output.SuspendLayout();
            toolsidebar.SuspendLayout();
            maintoolbar.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = Color.FromArgb(39, 39, 115);
            statusStrip1.Items.AddRange(new ToolStripItem[] { updatebar, updatetext });
            statusStrip1.Location = new Point(0, 698);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1280, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // updatebar
            // 
            updatebar.MarqueeAnimationSpeed = 20;
            updatebar.Maximum = 50;
            updatebar.Name = "updatebar";
            updatebar.Size = new Size(50, 16);
            updatebar.Step = 1;
            updatebar.Visible = false;
            // 
            // updatetext
            // 
            updatetext.ForeColor = Color.FromArgb(184, 115, 213);
            updatetext.Name = "updatetext";
            updatetext.Size = new Size(26, 17);
            updatetext.Text = "Idle";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(25, 17, 65);
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(MainWindowContainer);
            panel1.Controls.Add(toolsidebar);
            panel1.Controls.Add(maintoolbar);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1280, 720);
            panel1.TabIndex = 1;
            // 
            // MainWindowContainer
            // 
            MainWindowContainer.Dock = DockStyle.Fill;
            MainWindowContainer.Location = new Point(0, 49);
            MainWindowContainer.Name = "MainWindowContainer";
            // 
            // MainWindowContainer.Panel1
            // 
            MainWindowContainer.Panel1.Controls.Add(panel4);
            MainWindowContainer.Panel1.ForeColor = Color.Pink;
            // 
            // MainWindowContainer.Panel2
            // 
            MainWindowContainer.Panel2.Controls.Add(CodeEditorHolder);
            MainWindowContainer.Size = new Size(1278, 669);
            MainWindowContainer.SplitterDistance = 277;
            MainWindowContainer.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(27, 27, 63);
            panel4.Controls.Add(treeView1);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(277, 669);
            panel4.TabIndex = 0;
            // 
            // treeView1
            // 
            treeView1.BackColor = Color.FromArgb(27, 27, 63);
            treeView1.BorderStyle = BorderStyle.None;
            treeView1.Dock = DockStyle.Fill;
            treeView1.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            treeView1.ForeColor = Color.Pink;
            treeView1.FullRowSelect = true;
            treeView1.HotTracking = true;
            treeView1.Indent = 50;
            treeView1.LabelEdit = true;
            treeView1.LineColor = Color.Pink;
            treeView1.Location = new Point(0, 0);
            treeView1.Name = "treeView1";
            treeView1.RightToLeft = RightToLeft.No;
            treeView1.ShowLines = false;
            treeView1.ShowPlusMinus = false;
            treeView1.Size = new Size(277, 669);
            treeView1.TabIndex = 0;
            treeView1.AfterLabelEdit += treeView1_AfterLabelEdit;
            treeView1.Click += treeView1_Click;
            treeView1.DoubleClick += treeView1_DoubleClick;
            treeView1.Enter += treeView1_Enter;
            // 
            // CodeEditorHolder
            // 
            CodeEditorHolder.Dock = DockStyle.Fill;
            CodeEditorHolder.Location = new Point(0, 0);
            CodeEditorHolder.Name = "CodeEditorHolder";
            CodeEditorHolder.Orientation = Orientation.Horizontal;
            // 
            // CodeEditorHolder.Panel1
            // 
            CodeEditorHolder.Panel1.Controls.Add(siticoneTabControl2);
            CodeEditorHolder.Panel1.Controls.Add(label2);
            CodeEditorHolder.Panel1.ForeColor = Color.Pink;
            CodeEditorHolder.Panel1.Paint += splitContainer2_Panel1_Paint;
            // 
            // CodeEditorHolder.Panel2
            // 
            CodeEditorHolder.Panel2.Controls.Add(siticoneTabControl1);
            CodeEditorHolder.Panel2.Controls.Add(panel3);
            CodeEditorHolder.Panel2.ForeColor = Color.Pink;
            CodeEditorHolder.Size = new Size(997, 669);
            CodeEditorHolder.SplitterDistance = 510;
            CodeEditorHolder.TabIndex = 2;
            // 
            // siticoneTabControl2
            // 
            siticoneTabControl2.Dock = DockStyle.Fill;
            siticoneTabControl2.ItemSize = new Size(100, 20);
            siticoneTabControl2.Location = new Point(0, 0);
            siticoneTabControl2.Name = "siticoneTabControl2";
            siticoneTabControl2.SelectedIndex = 0;
            siticoneTabControl2.Size = new Size(997, 510);
            siticoneTabControl2.TabButtonHoverState.BorderColor = Color.Empty;
            siticoneTabControl2.TabButtonHoverState.FillColor = Color.FromArgb(25, 17, 80);
            siticoneTabControl2.TabButtonHoverState.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            siticoneTabControl2.TabButtonHoverState.ForeColor = Color.Pink;
            siticoneTabControl2.TabButtonHoverState.InnerColor = Color.FromArgb(25, 17, 80);
            siticoneTabControl2.TabButtonIdleState.BorderColor = Color.Pink;
            siticoneTabControl2.TabButtonIdleState.FillColor = Color.FromArgb(25, 17, 65);
            siticoneTabControl2.TabButtonIdleState.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            siticoneTabControl2.TabButtonIdleState.ForeColor = Color.Pink;
            siticoneTabControl2.TabButtonIdleState.InnerColor = Color.FromArgb(25, 17, 65);
            siticoneTabControl2.TabButtonImageAlign = HorizontalAlignment.Left;
            siticoneTabControl2.TabButtonSelectedState.BorderColor = Color.Pink;
            siticoneTabControl2.TabButtonSelectedState.FillColor = Color.FromArgb(55, 24, 109);
            siticoneTabControl2.TabButtonSelectedState.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            siticoneTabControl2.TabButtonSelectedState.ForeColor = Color.Pink;
            siticoneTabControl2.TabButtonSelectedState.InnerColor = Color.FromArgb(55, 24, 109);
            siticoneTabControl2.TabButtonSize = new Size(100, 20);
            siticoneTabControl2.TabIndex = 0;
            siticoneTabControl2.TabMenuBackColor = Color.FromArgb(25, 17, 65);
            siticoneTabControl2.TabMenuOrientation = Siticone.Desktop.UI.WinForms.TabMenuOrientation.HorizontalTop;
            siticoneTabControl2.Visible = false;
            siticoneTabControl2.TabIndexChanged += siticoneTabControl2_TabIndexChanged;
            siticoneTabControl2.Click += siticoneTabControl2_Click;
            siticoneTabControl2.DoubleClick += siticoneTabControl2_DoubleClick;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Press Start 2P", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(25, 17, 125);
            label2.Location = new Point(100, 234);
            label2.Name = "label2";
            label2.Size = new Size(810, 24);
            label2.TabIndex = 0;
            label2.Text = "Hydrix Editor - Version 23Y9M22D";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // siticoneTabControl1
            // 
            siticoneTabControl1.Controls.Add(errors);
            siticoneTabControl1.Controls.Add(output);
            siticoneTabControl1.Dock = DockStyle.Fill;
            siticoneTabControl1.ItemSize = new Size(180, 40);
            siticoneTabControl1.Location = new Point(0, 0);
            siticoneTabControl1.Name = "siticoneTabControl1";
            siticoneTabControl1.SelectedIndex = 0;
            siticoneTabControl1.Size = new Size(997, 134);
            siticoneTabControl1.TabButtonHoverState.BorderColor = Color.Empty;
            siticoneTabControl1.TabButtonHoverState.FillColor = Color.FromArgb(33, 0, 92);
            siticoneTabControl1.TabButtonHoverState.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            siticoneTabControl1.TabButtonHoverState.ForeColor = Color.Pink;
            siticoneTabControl1.TabButtonHoverState.InnerColor = Color.FromArgb(33, 0, 92);
            siticoneTabControl1.TabButtonIdleState.BorderColor = Color.Empty;
            siticoneTabControl1.TabButtonIdleState.FillColor = Color.FromArgb(33, 0, 92);
            siticoneTabControl1.TabButtonIdleState.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            siticoneTabControl1.TabButtonIdleState.ForeColor = Color.Pink;
            siticoneTabControl1.TabButtonIdleState.InnerColor = Color.FromArgb(33, 42, 57);
            siticoneTabControl1.TabButtonSelectedState.BorderColor = Color.Empty;
            siticoneTabControl1.TabButtonSelectedState.FillColor = Color.FromArgb(33, 0, 92);
            siticoneTabControl1.TabButtonSelectedState.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            siticoneTabControl1.TabButtonSelectedState.ForeColor = Color.Pink;
            siticoneTabControl1.TabButtonSelectedState.InnerColor = Color.Pink;
            siticoneTabControl1.TabButtonSize = new Size(180, 40);
            siticoneTabControl1.TabIndex = 2;
            siticoneTabControl1.TabMenuBackColor = Color.FromArgb(33, 0, 92);
            siticoneTabControl1.TabMenuOrientation = Siticone.Desktop.UI.WinForms.TabMenuOrientation.HorizontalTop;
            // 
            // errors
            // 
            errors.BackColor = Color.FromArgb(37, 27, 63);
            errors.Location = new Point(4, 44);
            errors.Name = "errors";
            errors.Padding = new Padding(3);
            errors.Size = new Size(989, 86);
            errors.TabIndex = 0;
            errors.Text = "Error List";
            // 
            // output
            // 
            output.BackColor = Color.FromArgb(33, 0, 92);
            output.Controls.Add(outputtxt);
            output.Location = new Point(4, 44);
            output.Name = "output";
            output.Padding = new Padding(3);
            output.Size = new Size(989, 86);
            output.TabIndex = 1;
            output.Text = "Output";
            // 
            // outputtxt
            // 
            outputtxt.BackColor = Color.FromArgb(37, 27, 63);
            outputtxt.BorderStyle = BorderStyle.None;
            outputtxt.Dock = DockStyle.Fill;
            outputtxt.Font = new Font("Press Start 2P", 7F, FontStyle.Bold, GraphicsUnit.Point);
            outputtxt.ForeColor = Color.Pink;
            outputtxt.Location = new Point(3, 3);
            outputtxt.Name = "outputtxt";
            outputtxt.ReadOnly = true;
            outputtxt.Size = new Size(983, 80);
            outputtxt.TabIndex = 0;
            outputtxt.Text = "";
            outputtxt.TextChanged += outputtxt_TextChanged;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 134);
            panel3.Name = "panel3";
            panel3.Size = new Size(997, 21);
            panel3.TabIndex = 1;
            // 
            // toolsidebar
            // 
            toolsidebar.GripStyle = ToolStripGripStyle.Hidden;
            toolsidebar.Items.AddRange(new ToolStripItem[] { NewProjTool, loadprojbuttontool, toolStripSeparator2, toolsavebutton, toolrecursivesave, toolnewfile, toolopenfile, toolStripSeparator1 });
            toolsidebar.Location = new Point(0, 24);
            toolsidebar.Name = "toolsidebar";
            toolsidebar.RenderMode = ToolStripRenderMode.System;
            toolsidebar.Size = new Size(1278, 25);
            toolsidebar.Stretch = true;
            toolsidebar.TabIndex = 3;
            toolsidebar.Text = "toolStrip1";
            // 
            // NewProjTool
            // 
            NewProjTool.DisplayStyle = ToolStripItemDisplayStyle.Image;
            NewProjTool.Image = (Image)resources.GetObject("NewProjTool.Image");
            NewProjTool.ImageTransparentColor = Color.Magenta;
            NewProjTool.Name = "NewProjTool";
            NewProjTool.Size = new Size(23, 22);
            NewProjTool.Text = "New Project";
            NewProjTool.Click += NewProjTool_Click;
            // 
            // loadprojbuttontool
            // 
            loadprojbuttontool.DisplayStyle = ToolStripItemDisplayStyle.Image;
            loadprojbuttontool.Image = (Image)resources.GetObject("loadprojbuttontool.Image");
            loadprojbuttontool.ImageTransparentColor = Color.Magenta;
            loadprojbuttontool.Name = "loadprojbuttontool";
            loadprojbuttontool.Size = new Size(23, 22);
            loadprojbuttontool.Text = "Load Project";
            loadprojbuttontool.Click += loadprojbuttontool_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.ForeColor = Color.Pink;
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // toolsavebutton
            // 
            toolsavebutton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolsavebutton.Image = (Image)resources.GetObject("toolsavebutton.Image");
            toolsavebutton.ImageTransparentColor = Color.Magenta;
            toolsavebutton.Name = "toolsavebutton";
            toolsavebutton.Size = new Size(23, 22);
            toolsavebutton.Text = "Save";
            toolsavebutton.Click += toolsavebutton_Click;
            // 
            // toolrecursivesave
            // 
            toolrecursivesave.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolrecursivesave.Image = (Image)resources.GetObject("toolrecursivesave.Image");
            toolrecursivesave.ImageTransparentColor = Color.Magenta;
            toolrecursivesave.Name = "toolrecursivesave";
            toolrecursivesave.Size = new Size(23, 22);
            toolrecursivesave.Text = "Save All";
            // 
            // toolnewfile
            // 
            toolnewfile.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolnewfile.Image = (Image)resources.GetObject("toolnewfile.Image");
            toolnewfile.ImageTransparentColor = Color.Magenta;
            toolnewfile.Name = "toolnewfile";
            toolnewfile.Size = new Size(23, 22);
            toolnewfile.Text = "New File";
            // 
            // toolopenfile
            // 
            toolopenfile.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolopenfile.Image = (Image)resources.GetObject("toolopenfile.Image");
            toolopenfile.ImageTransparentColor = Color.Magenta;
            toolopenfile.Name = "toolopenfile";
            toolopenfile.Size = new Size(23, 22);
            toolopenfile.Text = "Open File";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.ForeColor = Color.Pink;
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // maintoolbar
            // 
            maintoolbar.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            maintoolbar.Location = new Point(0, 0);
            maintoolbar.Name = "maintoolbar";
            maintoolbar.Size = new Size(1278, 24);
            maintoolbar.TabIndex = 4;
            maintoolbar.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem1, openProjectToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(143, 22);
            toolStripMenuItem1.Text = "New Project";
            toolStripMenuItem1.Click += NewProjTool_Click;
            // 
            // openProjectToolStripMenuItem
            // 
            openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
            openProjectToolStripMenuItem.Size = new Size(143, 22);
            openProjectToolStripMenuItem.Text = "Open Project";
            openProjectToolStripMenuItem.Click += loadprojbuttontool_Click;
            // 
            // Mainwindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 17, 65);
            ClientSize = new Size(1280, 720);
            Controls.Add(statusStrip1);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Mainwindow";
            Text = "Hydrix Studio";
            Load += mainwindow_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            MainWindowContainer.Panel1.ResumeLayout(false);
            MainWindowContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MainWindowContainer).EndInit();
            MainWindowContainer.ResumeLayout(false);
            panel4.ResumeLayout(false);
            CodeEditorHolder.Panel1.ResumeLayout(false);
            CodeEditorHolder.Panel1.PerformLayout();
            CodeEditorHolder.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)CodeEditorHolder).EndInit();
            CodeEditorHolder.ResumeLayout(false);
            siticoneTabControl1.ResumeLayout(false);
            output.ResumeLayout(false);
            toolsidebar.ResumeLayout(false);
            toolsidebar.PerformLayout();
            maintoolbar.ResumeLayout(false);
            maintoolbar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        public ToolStripStatusLabel updatetext;
        public ToolStripProgressBar updatebar;
        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Siticone.Desktop.UI.WinForms.SiticoneButton siticoneButton2;
        private Siticone.Desktop.UI.WinForms.SiticoneButton siticoneButton1;
        private Siticone.Desktop.UI.WinForms.SiticoneButton siticoneButton3;
        private Label label1;
        private SplitContainer MainWindowContainer;
        private SplitContainer CodeEditorHolder;
        private Siticone.Desktop.UI.WinForms.SiticoneTabControl siticoneTabControl1;
        private TabPage errors;
        private TabPage output;
        private Panel panel3;
        private Panel panel4;
        private Siticone.Desktop.UI.WinForms.SiticoneTabControl siticoneTabControl2;
        private TreeView treeView1;
        private Label label2;
        private ToolStrip toolsidebar;
        private MenuStrip maintoolbar;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripButton NewProjTool;
        public RichTextBox outputtxt;
        private ToolStripButton loadprojbuttontool;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem openProjectToolStripMenuItem;
        private ToolStripButton toolsavebutton;
        private ToolStripButton toolnewfile;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton toolopenfile;
        private ToolStripButton toolrecursivesave;
    }
}