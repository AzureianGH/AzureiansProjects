using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ConsoleControl;
using ConsoleControlAPI;

namespace Azuri_Editor
{
    public partial class AzuriEditor : Form
    {
        bool isminimizedterminal = false;
        bool isfileshown = false;
        public AzuriEditor()
        {
            InitializeComponent();
            // Attach event handler to customize menu item colors
            TopMenuBar.Renderer = new MyRenderer();
            Application.EnableVisualStyles();
            UndoBtn.Enabled = false;
            RedoBtn.Enabled = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Terminal.Visible = false;
            // Change the menu bar color to 82, 8, 167
            TopMenuBar.BackColor = Color.FromArgb(82, 8, 167);
            // Foreground color to 170, 212, 236
            TopMenuBar.ForeColor = Color.FromArgb(170, 212, 236);

            // Set File, Edit, and View to 82, 8, 167
            File_New.BackColor = Color.FromArgb(82, 8, 167);
            File_Open.BackColor = Color.FromArgb(82, 8, 167);
            File_Save.BackColor = Color.FromArgb(82, 8, 167);
            File_SaveAs.BackColor = Color.FromArgb(82, 8, 167);
            File_Exit.BackColor = Color.FromArgb(82, 8, 167);
            New_Project.BackColor = Color.FromArgb(82, 8, 167);
            Open_File.BackColor = Color.FromArgb(82, 8, 167);
            Open_Folder.BackColor = Color.FromArgb(82, 8, 167);
            Edit_Undo.BackColor = Color.FromArgb(82, 8, 167);
            Edit_Redo.BackColor = Color.FromArgb(82, 8, 167);
            Edit_Cut.BackColor = Color.FromArgb(82, 8, 167);
            Edit_Copy.BackColor = Color.FromArgb(82, 8, 167);
            Edit_Paste.BackColor = Color.FromArgb(82, 8, 167);
            Edit_Delete.BackColor = Color.FromArgb(82, 8, 167);
            View_Fullscreen.BackColor = Color.FromArgb(82, 8, 167);
            Terminal_Close.BackColor = Color.FromArgb(82, 8, 167);
            Terminal_StartNew.BackColor = Color.FromArgb(82, 8, 167);
            Terminal_Reopen.BackColor = Color.FromArgb(82, 8, 167);
            Terminal_EndTerminal.BackColor = Color.FromArgb(82, 8, 167);
            // Foreground color to 57, 8, 127
            File_New.ForeColor = Color.FromArgb(170, 212, 236);
            File_Open.ForeColor = Color.FromArgb(170, 212, 236);
            File_Save.ForeColor = Color.FromArgb(170, 212, 236);
            File_SaveAs.ForeColor = Color.FromArgb(170, 212, 236);
            File_Exit.ForeColor = Color.FromArgb(170, 212, 236);
            New_Project.ForeColor = Color.FromArgb(170, 212, 236);
            Open_File.ForeColor = Color.FromArgb(170, 212, 236);
            Open_Folder.ForeColor = Color.FromArgb(170, 212, 236);
            Edit_Undo.ForeColor = Color.FromArgb(170, 212, 236);
            Edit_Redo.ForeColor = Color.FromArgb(170, 212, 236);
            Edit_Cut.ForeColor = Color.FromArgb(170, 212, 236);
            Edit_Copy.ForeColor = Color.FromArgb(170, 212, 236);
            Edit_Paste.ForeColor = Color.FromArgb(170, 212, 236);
            Edit_Delete.ForeColor = Color.FromArgb(170, 212, 236);
            View_Fullscreen.ForeColor = Color.FromArgb(170, 212, 236);
            Terminal_Close.ForeColor = Color.FromArgb(170, 212, 236);
            Terminal_StartNew.ForeColor = Color.FromArgb(170, 212, 236);
            Terminal_Reopen.ForeColor = Color.FromArgb(170, 212, 236);
            Terminal_EndTerminal.ForeColor = Color.FromArgb(170, 212, 236);
            Thread watchterm = new Thread(WatchTerminal);
            watchterm.Start();
        }
        private void TopMenuBar_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void UndoBtn_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Terminal_Load(object sender, EventArgs e)
        {

        }
        public void WatchTerminal()
        {
            bool isProcessRunning = false;
            while (true)
            {


                //check if the process is running
                if (Terminal.IsProcessRunning)
                {
                    isProcessRunning = true;
                    //Set codebox to 919, 436
                    if (!isminimizedterminal)
                    {
                        CodeBox.Invoke((MethodInvoker)(() => CodeBox.Size = new Size(919, 436)));
                    }
                }
                else
                {
                    isProcessRunning = false;
                    //Set CodeBox size to this 919, 619
                    CodeBox.Invoke((MethodInvoker)(() => CodeBox.Size = new Size(919, 619)));
                }
                if (Terminal.IsHandleCreated)
                {
                    Terminal.Invoke((MethodInvoker)(() => Terminal_StartNew.Enabled = !isProcessRunning));
                    //If it isnt running, disable close, end, and reopen
                    Terminal.Invoke((MethodInvoker)(() => Terminal_Close.Enabled = isProcessRunning));
                    Terminal.Invoke((MethodInvoker)(() => Terminal_EndTerminal.Enabled = isProcessRunning));
                    Terminal.Invoke((MethodInvoker)(() => Terminal_Reopen.Enabled = isProcessRunning));
                }

                // Sleep to avoid excessive CPU usage in the loop
                Thread.Sleep(500);
            }
        }
        private void startNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartTerminal("cmd.exe");
        }

        public void KillTerminal()
        {
            //Send command to the terminal (cls)
            Terminal.ResetText();
            Terminal.StopProcess();
            Terminal.Visible = false;
        }

        public void StartTerminal(string file)
        {
            // Ensure the Terminal control has a process associated with it
            Terminal.StartProcess(file, "");
            Terminal.Visible = true;
        }

        private void Terminal_Close_Click(object sender, EventArgs e)
        {
            //Hide the terminal
            Terminal.Visible = false;
            CodeBox.Invoke((MethodInvoker)(() => CodeBox.Size = new Size(919, 619)));
            isminimizedterminal = true;
        }

        private void Terminal_Reopen_Click(object sender, EventArgs e)
        {
            //Show the terminal
            Terminal.Visible = true;
            CodeBox.Invoke((MethodInvoker)(() => CodeBox.Size = new Size(919, 436)));
            isminimizedterminal = false;
        }

        private void Terminal_EndTerminal_Click(object sender, EventArgs e)
        {
            //Kill the terminal
            KillTerminal();
        }

        private void CodeBox_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //throw exception
            throw new NotImplementedException();
        }
    }

    // Custom renderer to change menu item background color
    public class MyRenderer : ToolStripProfessionalRenderer
    {
        public MyRenderer() : base(new MyColors()) { }
    }

    public class MyColors : ProfessionalColorTable
    {
        public override Color MenuItemSelected
        {
            get { return Color.MediumPurple; }
        }
        public override Color MenuItemSelectedGradientBegin
        {
            get { return Color.MediumPurple; }
        }
        public override Color MenuItemSelectedGradientEnd
        {
            get { return Color.SkyBlue; }
        }
        //If the item is selected
        public override Color MenuItemBorder
        {
            get { return Color.Black; }
        }
        public override Color MenuBorder
        {
            get { return Color.Black; }
        }
    }
}
