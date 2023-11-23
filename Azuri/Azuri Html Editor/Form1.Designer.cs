namespace Azuri_Html_Editor
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
            TreeNode treeNode2 = new TreeNode("Node0");
            TreeNode treeNode1 = new TreeNode("Node0");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            BGPanel = new Panel();
            TabPanels = new TabControl();
            Files = new TabPage();
            Toolbox = new TabPage();
            ToolBoxTools = new TreeView();
            TopMenuBar = new MenuStrip();
            Menu_File = new ToolStripMenuItem();
            File_New = new ToolStripMenuItem();
            New_Project = new ToolStripMenuItem();
            Project_HtmlProject = new ToolStripMenuItem();
            NewProjMenu = new Panel();
            BrowseFlder = new Button();
            ProjLocationTB = new TextBox();
            ProjLocation = new Label();
            ProjNameTB = new TextBox();
            ProjNameLabel = new Label();
            CreateNewHTMLLabel = new Label();
            CreateProjButton = new Button();
            MainHTML = new TheArtOfDev.HtmlRenderer.WinForms.HtmlPanel();
            FBDialog = new FolderBrowserDialog();
            StatStrip = new StatusStrip();
            StatProg = new ToolStripProgressBar();
            CurrentEventStat = new ToolStripStatusLabel();
            FileExplorer = new TreeView();
            BGPanel.SuspendLayout();
            TabPanels.SuspendLayout();
            Files.SuspendLayout();
            Toolbox.SuspendLayout();
            TopMenuBar.SuspendLayout();
            NewProjMenu.SuspendLayout();
            StatStrip.SuspendLayout();
            SuspendLayout();
            // 
            // BGPanel
            // 
            BGPanel.BackColor = Color.FromArgb(243, 243, 243);
            BGPanel.Controls.Add(TabPanels);
            BGPanel.Dock = DockStyle.Left;
            BGPanel.Location = new Point(0, 24);
            BGPanel.Name = "BGPanel";
            BGPanel.Size = new Size(243, 837);
            BGPanel.TabIndex = 0;
            // 
            // TabPanels
            // 
            TabPanels.Alignment = TabAlignment.Bottom;
            TabPanels.Controls.Add(Files);
            TabPanels.Controls.Add(Toolbox);
            TabPanels.Dock = DockStyle.Left;
            TabPanels.Location = new Point(0, 0);
            TabPanels.Multiline = true;
            TabPanels.Name = "TabPanels";
            TabPanels.RightToLeft = RightToLeft.No;
            TabPanels.SelectedIndex = 0;
            TabPanels.Size = new Size(245, 837);
            TabPanels.TabIndex = 0;
            // 
            // Files
            // 
            Files.BackColor = Color.FromArgb(42, 42, 42);
            Files.Controls.Add(FileExplorer);
            Files.ForeColor = SystemColors.ControlLightLight;
            Files.Location = new Point(4, 4);
            Files.Name = "Files";
            Files.Padding = new Padding(3);
            Files.Size = new Size(237, 809);
            Files.TabIndex = 0;
            Files.Text = "Files";
            Files.ToolTipText = "File Explorer";
            // 
            // Toolbox
            // 
            Toolbox.BackColor = Color.FromArgb(42, 42, 42);
            Toolbox.Controls.Add(ToolBoxTools);
            Toolbox.Location = new Point(4, 4);
            Toolbox.Name = "Toolbox";
            Toolbox.Padding = new Padding(3);
            Toolbox.Size = new Size(237, 809);
            Toolbox.TabIndex = 1;
            Toolbox.Text = "Toolbox";
            Toolbox.ToolTipText = "Editor's Toolbox";
            // 
            // ToolBoxTools
            // 
            ToolBoxTools.BackColor = Color.FromArgb(53, 53, 53);
            ToolBoxTools.BorderStyle = BorderStyle.None;
            ToolBoxTools.ForeColor = SystemColors.Info;
            ToolBoxTools.Location = new Point(0, -1);
            ToolBoxTools.Name = "ToolBoxTools";
            treeNode2.BackColor = Color.FromArgb(53, 53, 53);
            treeNode2.ForeColor = Color.FromArgb(42, 130, 218);
            treeNode2.Name = "Proj";
            treeNode2.Text = "Node0";
            ToolBoxTools.Nodes.AddRange(new TreeNode[] { treeNode2 });
            ToolBoxTools.Size = new Size(239, 810);
            ToolBoxTools.TabIndex = 0;
            // 
            // TopMenuBar
            // 
            TopMenuBar.Items.AddRange(new ToolStripItem[] { Menu_File });
            TopMenuBar.Location = new Point(0, 0);
            TopMenuBar.Name = "TopMenuBar";
            TopMenuBar.Size = new Size(1584, 24);
            TopMenuBar.TabIndex = 1;
            TopMenuBar.Text = "Top Menu Bar";
            // 
            // Menu_File
            // 
            Menu_File.DropDownItems.AddRange(new ToolStripItem[] { File_New });
            Menu_File.Name = "Menu_File";
            Menu_File.Size = new Size(37, 20);
            Menu_File.Text = "File";
            // 
            // File_New
            // 
            File_New.DropDownItems.AddRange(new ToolStripItem[] { New_Project });
            File_New.Name = "File_New";
            File_New.Size = new Size(98, 22);
            File_New.Text = "New";
            // 
            // New_Project
            // 
            New_Project.DropDownItems.AddRange(new ToolStripItem[] { Project_HtmlProject });
            New_Project.Name = "New_Project";
            New_Project.Size = new Size(111, 22);
            New_Project.Text = "Project";
            New_Project.Click += htmlToolStripMenuItem_Click;
            // 
            // Project_HtmlProject
            // 
            Project_HtmlProject.Name = "Project_HtmlProject";
            Project_HtmlProject.Size = new Size(141, 22);
            Project_HtmlProject.Text = "Html Project";
            Project_HtmlProject.Click += Project_HtmlProject_Click;
            // 
            // NewProjMenu
            // 
            NewProjMenu.Controls.Add(BrowseFlder);
            NewProjMenu.Controls.Add(ProjLocationTB);
            NewProjMenu.Controls.Add(ProjLocation);
            NewProjMenu.Controls.Add(ProjNameTB);
            NewProjMenu.Controls.Add(ProjNameLabel);
            NewProjMenu.Controls.Add(CreateNewHTMLLabel);
            NewProjMenu.Controls.Add(CreateProjButton);
            NewProjMenu.Controls.Add(MainHTML);
            NewProjMenu.Location = new Point(242, 24);
            NewProjMenu.Name = "NewProjMenu";
            NewProjMenu.Size = new Size(1343, 837);
            NewProjMenu.TabIndex = 2;
            NewProjMenu.Visible = false;
            // 
            // BrowseFlder
            // 
            BrowseFlder.FlatStyle = FlatStyle.Flat;
            BrowseFlder.ForeColor = Color.FromArgb(42, 130, 218);
            BrowseFlder.Location = new Point(285, 294);
            BrowseFlder.Name = "BrowseFlder";
            BrowseFlder.Size = new Size(56, 23);
            BrowseFlder.TabIndex = 7;
            BrowseFlder.Text = "Browse";
            BrowseFlder.UseVisualStyleBackColor = true;
            BrowseFlder.Visible = false;
            BrowseFlder.Click += BrowseFlder_Click;
            // 
            // ProjLocationTB
            // 
            ProjLocationTB.BackColor = Color.FromArgb(23, 23, 23);
            ProjLocationTB.ForeColor = SystemColors.Window;
            ProjLocationTB.Location = new Point(27, 294);
            ProjLocationTB.Name = "ProjLocationTB";
            ProjLocationTB.ReadOnly = true;
            ProjLocationTB.Size = new Size(241, 23);
            ProjLocationTB.TabIndex = 6;
            ProjLocationTB.Visible = false;
            // 
            // ProjLocation
            // 
            ProjLocation.AutoSize = true;
            ProjLocation.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            ProjLocation.ForeColor = SystemColors.ButtonHighlight;
            ProjLocation.Location = new Point(21, 253);
            ProjLocation.Name = "ProjLocation";
            ProjLocation.Size = new Size(162, 30);
            ProjLocation.TabIndex = 5;
            ProjLocation.Text = "Project Location";
            ProjLocation.Visible = false;
            // 
            // ProjNameTB
            // 
            ProjNameTB.BackColor = Color.FromArgb(23, 23, 23);
            ProjNameTB.ForeColor = SystemColors.Window;
            ProjNameTB.Location = new Point(27, 152);
            ProjNameTB.Name = "ProjNameTB";
            ProjNameTB.Size = new Size(241, 23);
            ProjNameTB.TabIndex = 4;
            ProjNameTB.Visible = false;
            // 
            // ProjNameLabel
            // 
            ProjNameLabel.AutoSize = true;
            ProjNameLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            ProjNameLabel.ForeColor = SystemColors.ButtonHighlight;
            ProjNameLabel.Location = new Point(21, 111);
            ProjNameLabel.Name = "ProjNameLabel";
            ProjNameLabel.Size = new Size(139, 30);
            ProjNameLabel.TabIndex = 3;
            ProjNameLabel.Text = "Project Name";
            ProjNameLabel.Visible = false;
            // 
            // CreateNewHTMLLabel
            // 
            CreateNewHTMLLabel.AutoSize = true;
            CreateNewHTMLLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            CreateNewHTMLLabel.ForeColor = SystemColors.ControlLightLight;
            CreateNewHTMLLabel.Location = new Point(21, 17);
            CreateNewHTMLLabel.Name = "CreateNewHTMLLabel";
            CreateNewHTMLLabel.Size = new Size(288, 32);
            CreateNewHTMLLabel.TabIndex = 2;
            CreateNewHTMLLabel.Text = "Create New HTML Project";
            CreateNewHTMLLabel.Visible = false;
            // 
            // CreateProjButton
            // 
            CreateProjButton.FlatStyle = FlatStyle.Flat;
            CreateProjButton.ForeColor = Color.FromArgb(42, 130, 218);
            CreateProjButton.Location = new Point(21, 759);
            CreateProjButton.Name = "CreateProjButton";
            CreateProjButton.Size = new Size(168, 54);
            CreateProjButton.TabIndex = 1;
            CreateProjButton.Text = "Create Project";
            CreateProjButton.UseVisualStyleBackColor = true;
            CreateProjButton.Visible = false;
            CreateProjButton.Click += CreateProjButton_Click;
            // 
            // MainHTML
            // 
            MainHTML.AutoScroll = true;
            MainHTML.BackColor = SystemColors.Window;
            MainHTML.BaseStylesheet = null;
            MainHTML.Location = new Point(0, 0);
            MainHTML.Name = "MainHTML";
            MainHTML.Size = new Size(1343, 837);
            MainHTML.TabIndex = 0;
            MainHTML.Text = null;
            MainHTML.Visible = false;
            // 
            // FBDialog
            // 
            FBDialog.HelpRequest += FBDialog_HelpRequest;
            // 
            // StatStrip
            // 
            StatStrip.AllowMerge = false;
            StatStrip.Items.AddRange(new ToolStripItem[] { StatProg, CurrentEventStat });
            StatStrip.Location = new Point(243, 839);
            StatStrip.Name = "StatStrip";
            StatStrip.Size = new Size(1341, 22);
            StatStrip.TabIndex = 9;
            StatStrip.Text = "statusStrip1";
            // 
            // StatProg
            // 
            StatProg.MarqueeAnimationSpeed = 25;
            StatProg.Name = "StatProg";
            StatProg.Size = new Size(100, 16);
            StatProg.Step = 1;
            StatProg.Style = ProgressBarStyle.Marquee;
            StatProg.Visible = false;
            // 
            // CurrentEventStat
            // 
            CurrentEventStat.BackColor = Color.White;
            CurrentEventStat.Name = "CurrentEventStat";
            CurrentEventStat.Size = new Size(0, 17);
            // 
            // FileExplorer
            // 
            FileExplorer.BackColor = Color.FromArgb(53, 53, 53);
            FileExplorer.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FileExplorer.ForeColor = SystemColors.Highlight;
            FileExplorer.LineColor = Color.FromArgb(128, 255, 255);
            FileExplorer.Location = new Point(6, 6);
            FileExplorer.Name = "FileExplorer";
            treeNode1.Name = "Node0";
            treeNode1.Text = "Node0";
            FileExplorer.Nodes.AddRange(new TreeNode[] { treeNode1 });
            FileExplorer.Size = new Size(225, 799);
            FileExplorer.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(23, 23, 23);
            ClientSize = new Size(1584, 861);
            Controls.Add(StatStrip);
            Controls.Add(NewProjMenu);
            Controls.Add(BGPanel);
            Controls.Add(TopMenuBar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = TopMenuBar;
            Name = "Form1";
            Text = "Azuri HTML Editor";
            BGPanel.ResumeLayout(false);
            TabPanels.ResumeLayout(false);
            Files.ResumeLayout(false);
            Toolbox.ResumeLayout(false);
            TopMenuBar.ResumeLayout(false);
            TopMenuBar.PerformLayout();
            NewProjMenu.ResumeLayout(false);
            NewProjMenu.PerformLayout();
            StatStrip.ResumeLayout(false);
            StatStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel BGPanel;
        private MenuStrip TopMenuBar;
        private ToolStripMenuItem Menu_File;
        private ToolStripMenuItem File_New;
        private ToolStripMenuItem New_Project;
        private ToolStripMenuItem Project_HtmlProject;
        private TabControl TabPanels;
        private TabPage Files;
        private TabPage Toolbox;
        private TreeView ToolBoxTools;
        private Panel NewProjMenu;
        private TheArtOfDev.HtmlRenderer.WinForms.HtmlPanel MainHTML;
        private Button CreateProjButton;
        private Label CreateNewHTMLLabel;
        private Label ProjNameLabel;
        private TextBox ProjNameTB;
        private TextBox ProjLocationTB;
        private Label ProjLocation;
        private Button BrowseFlder;
        private FolderBrowserDialog FBDialog;
        private StatusStrip StatStrip;
        private ToolStripProgressBar StatProg;
        private ToolStripStatusLabel CurrentEventStat;
        private TreeView FileExplorer;
    }
}