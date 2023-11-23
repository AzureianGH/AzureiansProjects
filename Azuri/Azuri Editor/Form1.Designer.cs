namespace Azuri_Editor
{
    partial class AzuriEditor
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AzuriEditor));
            TopMenuBar = new MenuStrip();
            File = new ToolStripMenuItem();
            File_New = new ToolStripMenuItem();
            New_Project = new ToolStripMenuItem();
            File_Open = new ToolStripMenuItem();
            Open_File = new ToolStripMenuItem();
            Open_Folder = new ToolStripMenuItem();
            File_Save = new ToolStripMenuItem();
            File_SaveAs = new ToolStripMenuItem();
            File_Exit = new ToolStripMenuItem();
            Edit = new ToolStripMenuItem();
            Edit_Undo = new ToolStripMenuItem();
            Edit_Redo = new ToolStripMenuItem();
            Edit_Cut = new ToolStripMenuItem();
            Edit_Copy = new ToolStripMenuItem();
            Edit_Paste = new ToolStripMenuItem();
            Edit_Delete = new ToolStripMenuItem();
            View = new ToolStripMenuItem();
            View_Fullscreen = new ToolStripMenuItem();
            TerminalBtn = new ToolStripMenuItem();
            Terminal_StartNew = new ToolStripMenuItem();
            Terminal_Close = new ToolStripMenuItem();
            Terminal_Reopen = new ToolStripMenuItem();
            Terminal_EndTerminal = new ToolStripMenuItem();
            TopQuickMenu = new Panel();
            button1 = new Button();
            label2 = new Label();
            label1 = new Label();
            RedoBtn = new Button();
            UndoBtn = new Button();
            panel1 = new Panel();
            Terminal = new ConsoleControl.ConsoleControl();
            CodeBox = new FastColoredTextBoxNS.FastColoredTextBox();
            TopMenuBar.SuspendLayout();
            TopQuickMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CodeBox).BeginInit();
            SuspendLayout();
            // 
            // TopMenuBar
            // 
            TopMenuBar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            TopMenuBar.Items.AddRange(new ToolStripItem[] { File, Edit, View, TerminalBtn });
            TopMenuBar.Location = new Point(0, 0);
            TopMenuBar.Name = "TopMenuBar";
            TopMenuBar.Size = new Size(1108, 24);
            TopMenuBar.TabIndex = 0;
            TopMenuBar.Text = "menuStrip1";
            TopMenuBar.ItemClicked += TopMenuBar_ItemClicked;
            // 
            // File
            // 
            File.DropDownItems.AddRange(new ToolStripItem[] { File_New, File_Open, File_Save, File_SaveAs, File_Exit });
            File.ForeColor = Color.FromArgb(170, 212, 236);
            File.Name = "File";
            File.Size = new Size(37, 20);
            File.Text = "File";
            // 
            // File_New
            // 
            File_New.BackColor = Color.FromArgb(82, 8, 167);
            File_New.DropDownItems.AddRange(new ToolStripItem[] { New_Project });
            File_New.Name = "File_New";
            File_New.Size = new Size(114, 22);
            File_New.Text = "New";
            // 
            // New_Project
            // 
            New_Project.BackColor = Color.FromArgb(82, 8, 167);
            New_Project.Name = "New_Project";
            New_Project.Size = new Size(111, 22);
            New_Project.Text = "Project";
            // 
            // File_Open
            // 
            File_Open.DropDownItems.AddRange(new ToolStripItem[] { Open_File, Open_Folder });
            File_Open.Name = "File_Open";
            File_Open.Size = new Size(114, 22);
            File_Open.Text = "Open";
            // 
            // Open_File
            // 
            Open_File.Name = "Open_File";
            Open_File.Size = new Size(107, 22);
            Open_File.Text = "File";
            // 
            // Open_Folder
            // 
            Open_Folder.Name = "Open_Folder";
            Open_Folder.Size = new Size(107, 22);
            Open_Folder.Text = "Folder";
            // 
            // File_Save
            // 
            File_Save.Name = "File_Save";
            File_Save.Size = new Size(114, 22);
            File_Save.Text = "Save";
            // 
            // File_SaveAs
            // 
            File_SaveAs.Name = "File_SaveAs";
            File_SaveAs.Size = new Size(114, 22);
            File_SaveAs.Text = "Save As";
            // 
            // File_Exit
            // 
            File_Exit.Name = "File_Exit";
            File_Exit.Size = new Size(114, 22);
            File_Exit.Text = "Exit";
            // 
            // Edit
            // 
            Edit.DropDownItems.AddRange(new ToolStripItem[] { Edit_Undo, Edit_Redo, Edit_Cut, Edit_Copy, Edit_Paste, Edit_Delete });
            Edit.ForeColor = Color.FromArgb(170, 212, 236);
            Edit.Name = "Edit";
            Edit.Size = new Size(39, 20);
            Edit.Text = "Edit";
            // 
            // Edit_Undo
            // 
            Edit_Undo.Name = "Edit_Undo";
            Edit_Undo.Size = new Size(107, 22);
            Edit_Undo.Text = "Undo";
            // 
            // Edit_Redo
            // 
            Edit_Redo.Name = "Edit_Redo";
            Edit_Redo.Size = new Size(107, 22);
            Edit_Redo.Text = "Redo";
            // 
            // Edit_Cut
            // 
            Edit_Cut.Name = "Edit_Cut";
            Edit_Cut.Size = new Size(107, 22);
            Edit_Cut.Text = "Cut";
            // 
            // Edit_Copy
            // 
            Edit_Copy.Name = "Edit_Copy";
            Edit_Copy.Size = new Size(107, 22);
            Edit_Copy.Text = "Copy";
            // 
            // Edit_Paste
            // 
            Edit_Paste.Name = "Edit_Paste";
            Edit_Paste.Size = new Size(107, 22);
            Edit_Paste.Text = "Paste";
            // 
            // Edit_Delete
            // 
            Edit_Delete.Name = "Edit_Delete";
            Edit_Delete.Size = new Size(107, 22);
            Edit_Delete.Text = "Delete";
            // 
            // View
            // 
            View.DropDownItems.AddRange(new ToolStripItem[] { View_Fullscreen });
            View.ForeColor = Color.FromArgb(170, 212, 236);
            View.Name = "View";
            View.Size = new Size(44, 20);
            View.Text = "View";
            // 
            // View_Fullscreen
            // 
            View_Fullscreen.Name = "View_Fullscreen";
            View_Fullscreen.Size = new Size(127, 22);
            View_Fullscreen.Text = "Fullscreen";
            // 
            // TerminalBtn
            // 
            TerminalBtn.DropDownItems.AddRange(new ToolStripItem[] { Terminal_StartNew, Terminal_Close, Terminal_Reopen, Terminal_EndTerminal });
            TerminalBtn.ForeColor = Color.FromArgb(170, 212, 236);
            TerminalBtn.Name = "TerminalBtn";
            TerminalBtn.Size = new Size(64, 20);
            TerminalBtn.Text = "Terminal";
            // 
            // Terminal_StartNew
            // 
            Terminal_StartNew.Name = "Terminal_StartNew";
            Terminal_StartNew.Size = new Size(142, 22);
            Terminal_StartNew.Text = "Start New";
            Terminal_StartNew.Click += startNewToolStripMenuItem_Click;
            // 
            // Terminal_Close
            // 
            Terminal_Close.Name = "Terminal_Close";
            Terminal_Close.Size = new Size(142, 22);
            Terminal_Close.Text = "Close";
            Terminal_Close.Click += Terminal_Close_Click;
            // 
            // Terminal_Reopen
            // 
            Terminal_Reopen.Name = "Terminal_Reopen";
            Terminal_Reopen.Size = new Size(142, 22);
            Terminal_Reopen.Text = "Reopen";
            Terminal_Reopen.Click += Terminal_Reopen_Click;
            // 
            // Terminal_EndTerminal
            // 
            Terminal_EndTerminal.Name = "Terminal_EndTerminal";
            Terminal_EndTerminal.Size = new Size(142, 22);
            Terminal_EndTerminal.Text = "End Terminal";
            Terminal_EndTerminal.Click += Terminal_EndTerminal_Click;
            // 
            // TopQuickMenu
            // 
            TopQuickMenu.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TopQuickMenu.BackColor = Color.FromArgb(82, 8, 167);
            TopQuickMenu.Controls.Add(button1);
            TopQuickMenu.Controls.Add(label2);
            TopQuickMenu.Controls.Add(label1);
            TopQuickMenu.Controls.Add(RedoBtn);
            TopQuickMenu.Controls.Add(UndoBtn);
            TopQuickMenu.Location = new Point(0, 24);
            TopQuickMenu.Name = "TopQuickMenu";
            TopQuickMenu.Size = new Size(1108, 23);
            TopQuickMenu.TabIndex = 1;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = Color.FromArgb(170, 212, 236);
            button1.Location = new Point(83, -3);
            button1.Name = "button1";
            button1.Size = new Size(52, 26);
            button1.TabIndex = 4;
            button1.Text = "Crash";
            button1.TextAlign = ContentAlignment.TopCenter;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(57, 8, 127);
            label2.Location = new Point(67, -4);
            label2.Name = "label2";
            label2.Size = new Size(10, 27);
            label2.TabIndex = 3;
            label2.Text = "|";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.UseCompatibleTextRendering = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(57, 8, 127);
            label1.Location = new Point(3, -4);
            label1.Name = "label1";
            label1.Size = new Size(10, 27);
            label1.TabIndex = 2;
            label1.Text = "|";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.UseCompatibleTextRendering = true;
            label1.Click += label1_Click;
            // 
            // RedoBtn
            // 
            RedoBtn.FlatAppearance.BorderSize = 0;
            RedoBtn.FlatStyle = FlatStyle.Flat;
            RedoBtn.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            RedoBtn.ForeColor = Color.FromArgb(170, 212, 236);
            RedoBtn.Location = new Point(41, 0);
            RedoBtn.Name = "RedoBtn";
            RedoBtn.Size = new Size(23, 26);
            RedoBtn.TabIndex = 1;
            RedoBtn.Text = "↪";
            RedoBtn.TextAlign = ContentAlignment.TopCenter;
            RedoBtn.UseVisualStyleBackColor = false;
            // 
            // UndoBtn
            // 
            UndoBtn.BackColor = Color.FromArgb(82, 8, 167);
            UndoBtn.FlatAppearance.BorderSize = 0;
            UndoBtn.FlatStyle = FlatStyle.Flat;
            UndoBtn.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            UndoBtn.ForeColor = Color.FromArgb(170, 212, 236);
            UndoBtn.Location = new Point(12, 0);
            UndoBtn.Name = "UndoBtn";
            UndoBtn.Size = new Size(23, 23);
            UndoBtn.TabIndex = 0;
            UndoBtn.Text = "↩";
            UndoBtn.TextAlign = ContentAlignment.TopCenter;
            UndoBtn.UseVisualStyleBackColor = false;
            UndoBtn.Click += UndoBtn_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(82, 8, 167);
            panel1.Location = new Point(-1, 47);
            panel1.Name = "panel1";
            panel1.Size = new Size(192, 619);
            panel1.TabIndex = 2;
            // 
            // Terminal
            // 
            Terminal.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            Terminal.AutoScroll = true;
            Terminal.AutoSize = true;
            Terminal.ForeColor = SystemColors.ButtonHighlight;
            Terminal.IsInputEnabled = true;
            Terminal.Location = new Point(190, 482);
            Terminal.Margin = new Padding(4, 3, 4, 3);
            Terminal.Name = "Terminal";
            Terminal.SendKeyboardCommandsToProcess = true;
            Terminal.ShowDiagnostics = false;
            Terminal.Size = new Size(919, 184);
            Terminal.TabIndex = 3;
            Terminal.Load += Terminal_Load;
            // 
            // CodeBox
            // 
            CodeBox.AutoCompleteBrackets = true;
            CodeBox.AutoCompleteBracketsList = new char[] { '(', ')', '{', '}', '[', ']', '"', '"', '\'', '\'' };
            CodeBox.AutoIndentCharsPatterns = "^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:]*(?<range>:)\\s*(?<range>[^;]+);";
            CodeBox.AutoScrollMinSize = new Size(154, 14);
            CodeBox.BackBrush = null;
            CodeBox.BackColor = Color.FromArgb(57, 8, 127);
            CodeBox.CaretColor = Color.White;
            CodeBox.CharHeight = 14;
            CodeBox.CharWidth = 8;
            CodeBox.DefaultMarkerSize = 8;
            CodeBox.DisabledColor = Color.FromArgb(100, 180, 180, 180);
            CodeBox.Font = new Font("Courier New", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            CodeBox.ForeColor = Color.FromArgb(170, 212, 236);
            CodeBox.IndentBackColor = Color.FromArgb(82, 8, 167);
            CodeBox.IsReplaceMode = false;
            CodeBox.LineNumberColor = Color.DeepSkyBlue;
            CodeBox.Location = new Point(190, 47);
            CodeBox.Name = "CodeBox";
            CodeBox.Paddings = new Padding(0);
            CodeBox.SelectionColor = Color.FromArgb(60, 0, 0, 255);
            CodeBox.ServiceColors = (FastColoredTextBoxNS.ServiceColors)resources.GetObject("CodeBox.ServiceColors");
            CodeBox.Size = new Size(919, 436);
            CodeBox.TabIndex = 4;
            CodeBox.Text = "fastColoredTextBox1";
            CodeBox.Zoom = 100;
            CodeBox.Load += CodeBox_Load;
            // 
            // AzuriEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(57, 8, 127);
            ClientSize = new Size(1108, 665);
            Controls.Add(CodeBox);
            Controls.Add(Terminal);
            Controls.Add(panel1);
            Controls.Add(TopQuickMenu);
            Controls.Add(TopMenuBar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = TopMenuBar;
            Name = "AzuriEditor";
            Text = "Azuri Editor";
            Load += Form1_Load;
            TopMenuBar.ResumeLayout(false);
            TopMenuBar.PerformLayout();
            TopQuickMenu.ResumeLayout(false);
            TopQuickMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)CodeBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip TopMenuBar;
        private ToolStripMenuItem File;
        private ToolStripMenuItem File_New;
        private ToolStripMenuItem File_Open;
        private ToolStripMenuItem Open_File;
        private ToolStripMenuItem Open_Folder;
        private ToolStripMenuItem File_Save;
        private ToolStripMenuItem File_SaveAs;
        private ToolStripMenuItem File_Exit;
        private ToolStripMenuItem Edit;
        private ToolStripMenuItem View;
        private ToolStripMenuItem New_Project;
        private ToolStripMenuItem Edit_Undo;
        private ToolStripMenuItem Edit_Redo;
        private ToolStripMenuItem Edit_Cut;
        private ToolStripMenuItem Edit_Copy;
        private ToolStripMenuItem Edit_Paste;
        private ToolStripMenuItem Edit_Delete;
        private ToolStripMenuItem View_Fullscreen;
        private Panel TopQuickMenu;
        private Button UndoBtn;
        private Label label1;
        private Button RedoBtn;
        private Label label2;
        private Panel panel1;
        private ConsoleControl.ConsoleControl Terminal;
        private ToolStripMenuItem TerminalBtn;
        private ToolStripMenuItem Terminal_StartNew;
        private ToolStripMenuItem Terminal_Close;
        private ToolStripMenuItem Terminal_Reopen;
        private ToolStripMenuItem Terminal_EndTerminal;
        private FastColoredTextBoxNS.FastColoredTextBox CodeBox;
        private Button button1;
    }
}