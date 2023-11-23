using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Forms;
namespace Hydrix_Editor
{
    public partial class Mainwindow : Form
    {
        public static bool isDragging;
        public static Point offset;
        public static CTask? currenttask;
        public static bool activetask = false;
        public static int taskcount = 0;
        public static Language language;
        public static string currentdirectory = "";
        public static string projectname = "";
        public static string hyxfile = "";
        public RichTextBox _outputtext;
        public struct Language
        {
            public string lang;
            public Language(string _lang)
            {
                lang = _lang;
            }
        }

        public static class Languages
        {
            public static class Assembly
            {
                public struct x86
                {
                    public static string Name = "Assembly x86";
                    public static Color commentcolor = Color.FromArgb(78, 201, 176);
                }
                public struct x64
                {
                    public static string Name = "Assembly x64";
                    public static Color commentcolor = Color.FromArgb(78, 201, 176);
                }
            }
            public static string SafeMode = "safemode";
        }
        public Mainwindow()
        {
            InitializeComponent();
            init();

        }
        public class CustomToolRender : ToolStripSystemRenderer
        {
            public CustomToolRender() { }

            protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
            {
                //base.OnRenderToolStripBorder(e);
            }
            //override select color
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                if (!e.Item.Selected)
                {
                    base.OnRenderMenuItemBackground(e);
                }
                else
                {
                    Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
                    Brush brush = new SolidBrush(Color.FromArgb(37, 27, 63));
                    Pen pen = new Pen(Color.FromArgb(255, 192, 203));
                    e.Graphics.FillRectangle(brush, rc);
                    e.Graphics.DrawRectangle(pen, 1, 0, rc.Width - 2, rc.Height - 1);
                }
            }
            //override hover color for toolstrip
            protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
            {
                if (!e.Item.Selected)
                {
                    base.OnRenderButtonBackground(e);
                }
                else
                {
                    Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
                    Brush brush = new SolidBrush(Color.FromArgb(37, 27, 63));
                    Pen pen = new Pen(Color.FromArgb(255, 192, 203));
                    e.Graphics.FillRectangle(brush, rc);
                    e.Graphics.DrawRectangle(pen, 1, 0, rc.Width - 2, rc.Height - 1);
                }
            }
        }
        /// <summary>
        /// Initializes the main window.
        /// </summary>
        public void init()
        {
            maintoolbar.BackColor = Color.FromArgb(37, 27, 63);
            maintoolbar.ForeColor = Color.FromArgb(255, 192, 203);
            //remove border from maintoolbar
            maintoolbar.GripStyle = ToolStripGripStyle.Hidden;
            //remove border from maintoolbar
            maintoolbar.Renderer = new CustomToolRender();
            toolsidebar.BackColor = Color.FromArgb(37, 27, 63);
            toolsidebar.ForeColor = Color.FromArgb(255, 192, 203);
            //remove border from toolsidebar
            toolsidebar.GripStyle = ToolStripGripStyle.Hidden;
            //remove border from toolsidebar
            toolsidebar.Renderer = new CustomToolRender();
            //create new thread for watching for changes
            Thread thread = new Thread(WatchForChanges);
            thread.Start();
        }

        public Mainwindow(string _hyxfile)
        {

            _outputtext = outputtxt;
            int SafeCheck()
            {
                if (language.lang == Languages.SafeMode)
                {
                    DialogResult result = MessageBox.Show("Error loading project file: " + hyxfile + "\nHere's what failed: Language Invalid.\nYou can try again, or continue to load the project.", "Uh oh!", MessageBoxButtons.CancelTryContinue);
                    if (result == DialogResult.Cancel)
                    {
                        Application.Exit();
                        return 1;
                    }
                    else if (result == DialogResult.TryAgain)
                    {
                        //try again
                        SafeCheck();
                        return 1;
                    }
                    else if (result == DialogResult.Continue)
                    {
                        projectname = "SAFE MODE!";
                        //set language to safe mode
                        language = new Language(Languages.SafeMode);
                        //set directory to current directory
                        currentdirectory = Path.GetDirectoryName(hyxfile);
                        return 1;
                    }
                }
                else if (projectname == "SAFE MODE!")
                {
                    DialogResult result = MessageBox.Show("Error loading project file: " + hyxfile + "\nHere's what failed: Project Name Invalid.\nYou can try again, or continue to load the project.", "Uh oh!", MessageBoxButtons.CancelTryContinue);
                    if (result == DialogResult.Cancel)
                    {
                        Application.Exit();
                        return 1;
                    }
                    else if (result == DialogResult.TryAgain)
                    {
                        //try again
                        SafeCheck();
                        return 1;
                    }
                    else if (result == DialogResult.Continue)
                    {
                        projectname = "SAFE MODE!";
                        //set language to safe mode
                        language = new Language(Languages.SafeMode);
                        //set directory to current directory
                        currentdirectory = Path.GetDirectoryName(hyxfile);
                        return 1;
                    }
                }
                else if (currentdirectory == "")
                {
                    DialogResult result = MessageBox.Show("Error loading project file: " + hyxfile + "\nHere's what failed: Directory Invalid.\nYou can try again, or continue to load the project.", "Uh oh!", MessageBoxButtons.CancelTryContinue);
                    if (result == DialogResult.Cancel)
                    {
                        Application.Exit();
                        return 1;
                    }
                    else if (result == DialogResult.TryAgain)
                    {
                        //try again
                        SafeCheck();
                        return 1;
                    }
                    else if (result == DialogResult.Continue)
                    {
                        projectname = "SAFE MODE!";
                        //set language to safe mode
                        language = new Language(Languages.SafeMode);
                        //set directory to the hyx file's directory
                        currentdirectory = Path.GetDirectoryName(hyxfile);
                        return 1;
                    }
                }
                return 0;
            }
            InitializeComponent();
            hyxfile = _hyxfile;
            //on a seperate thread, while true, check if taskcount is 0, if it is, set updatetext to "Idle"
            LoadHYX();
            //check if any are null, or Language is safemode
            int check = SafeCheck();
            if (check == 1)
            {
                //if check is 1, then we are in safe mode
                //set updatetext to "Safe Mode"
                UT.SetText(updatetext, "Safe Mode");
                this.Text = projectname + " - Safe Mode - Hydrix Studio";
                DWriteLine("Loaded Project in SAFE MODE: " + projectname);
            }
            else
            {
                //set updatetext to "Idle"
                UT.SetText(updatetext, "Idle");
                //change window title to project name
                this.Text = projectname + " - Hydrix Studio";

            }
            Thread.Sleep(1000);
            init();
            //For all files in project directory, add to treeview
            string[] files = Directory.GetFiles(currentdirectory);
            string[] filelist = { };
            foreach (string file in files)
            {
                //look for .hyx files, make it the root node
                if (file.Contains(".hyx"))
                {
                    TreeNode node = new TreeNode(Path.GetFileName(file));
                    node.Tag = file;
                    node.ImageIndex = 0;
                    node.SelectedImageIndex = 0;
                    treeView1.Nodes.Add(node);
                }
                else
                {
                    //add to filelist
                    Array.Resize(ref filelist, filelist.Length + 1);
                    filelist[filelist.Length - 1] = file;
                }
            }
            //for all files in filelist, add to treeview under root node
            foreach (string file in filelist)
            {
                TreeNode node = new TreeNode(Path.GetFileName(file));
                node.Tag = file;
                node.ImageIndex = 1;
                node.SelectedImageIndex = 1;
                treeView1.Nodes[0].Nodes.Add(node);
            }

        }

        public void DWriteLine(string text)
        {
            outputtxt.Text += text + "\n";
        }
        public void DWrite(string text)
        {
            outputtxt.AppendText(text);
        }
        public void DWriteLine(string text, Color color)
        {
            outputtxt.SelectionColor = color;
            outputtxt.AppendText(text + "\n");
        }
        public void DWrite(string text, Color color)
        {
            outputtxt.SelectionColor = color;
            outputtxt.AppendText(text);
        }
        public void DWriteLine(string text, Color color, Font font)
        {
            outputtxt.SelectionColor = color;
            outputtxt.SelectionFont = font;
            outputtxt.AppendText(text + "\n");
        }
        public void DWrite(string text, Color color, Font font)
        {
            outputtxt.SelectionColor = color;
            outputtxt.SelectionFont = font;
            outputtxt.AppendText(text);
        }
        public void DRemoveLine(int line)
        {
            outputtxt.Select(outputtxt.GetFirstCharIndexFromLine(line), outputtxt.Lines[line].Length);
            outputtxt.SelectedText = "";
        }
        public void DRemoveLine(int line, int length)
        {
            outputtxt.Select(outputtxt.GetFirstCharIndexFromLine(line), length);
            outputtxt.SelectedText = "";
        }

        private void LoadHYX()
        {
            //variable for file contents
            string filecontents = "";
            //load the hyx file into the filecontents variable
            filecontents = File.ReadAllText(hyxfile);
            //debug filecontents
            Debug.WriteLine(filecontents);
            //split the file contents by line
            string[] lines = filecontents.Split('\n');
            //for each line in the file
            foreach (string line in lines)
            {
                try
                {
                    string varion = line.Split(';')[0];
                    string varion2 = line.Split(';')[1];
                    if (varion == "language")
                    {
                        if (varion2 == "Assembly x86")
                        {
                            //set the language to assembly
                            language = new Language(Languages.Assembly.x86.Name);
                        }
                    }
                    else if (varion == "directory")
                    {
                        currentdirectory = varion2;
                    }
                    else if (varion == "name")
                    {
                        projectname = varion2;
                    }
                }
                catch (Exception e)
                {
                    if (language.lang == null)
                    {
                        language = new Language(Languages.SafeMode);
                    }
                    //if currentdirectory is null, set to current directory
                    if (currentdirectory == null)
                    {
                        currentdirectory = Directory.GetCurrentDirectory();
                    }
                    //if projectname is null, set to "Untitled"
                    if (projectname == null)
                    {
                        projectname = "SAFE MODE!";
                    }
                    Debug.WriteLine(e.ToString());

                }
            }
        }
        struct Project
        {
            public static string projectlocation;
        }
        private void mainwindow_Load(object sender, EventArgs e)
        {
            UT.SetText(updatetext, "Loaded Main Window.");
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            UT.SetText(updatetext, "Painted Title Bar.");
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                offset = new Point(e.X, e.Y);
            }

        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (isDragging)
            {
                Point newLocation = PointToScreen(new Point(e.X, e.Y));
                newLocation.Offset(-offset.X, -offset.Y);
                Location = newLocation;
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }

        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            //exit
            if (activetask == true)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit? This current task will be cancelled: " + currenttask, "Exit", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do nothing
                }
            }
            else
            {
                Application.Exit();
            }
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            //maximize
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void siticoneButton3_Click(object sender, EventArgs e)
        {
            //minimize
            WindowState = FormWindowState.Minimized;
        }
        public static class TM
        {
            public static void RegisterTask(CTask task)
            {
                taskcount++;
                activetask = true;
                currenttask = task;
                Debug.WriteLine("Task Registered: " + task.name);
            }
            public static void UnregisterTask()
            {
                taskcount--;
                activetask = false;
                currenttask = null;
                Debug.WriteLine("Task Unregistered");
            }
        }
        /// <summary>
        /// Represents a task with a name, description, and associated action.
        /// </summary>
        public struct CTask
        {
            public string name;
            public string description;
            public Action Action;
            public CTask(string _name, string _description, Action _action)
            {
                name = _name;
                description = _description;
                Action = _action;
            }
        }
        public static class AsyncHelper
        {
            public static async Task RunTaskAsync(CTask task)
            {
                //await Task.Run(action);
                TM.RegisterTask(task);
                await Task.Run(task.Action);
                Debug.WriteLine("Task Completed");
                TM.UnregisterTask();
                return;
            }
        }
        public class Loadingbar
        {
            public ToolStripProgressBar progress;
            public ToolStripLabel text;
            public int total;
            public int step;
            public int current;
            public Loadingbar(ToolStripProgressBar _progress, ToolStripLabel _text, int _total, int _step, int _current)
            {
                progress = _progress;
                text = _text;
                total = _total;
                step = _step;
                current = _current;
            }
            public void init()
            {
                progress.Maximum = total;
                progress.Step = step;
                progress.Value = current;
                text.Text = "";
                progress.Visible = true;
            }
            public void StepOneText(string _text)
            {
                progress.PerformStep();
                text.Text = _text;
            }
            public void StepOne()
            {
                progress.PerformStep();
            }
            public void Reset()
            {
                progress.Value = 0;
                text.Text = "";
            }
            public void ResetText()
            {
                text.Text = "";
            }
            public void ResetValue()
            {
                progress.Value = 0;
            }
            public void Hide()
            {
                progress.Visible = false;
            }
            public void Show()
            {
                progress.Visible = true;
            }
            public void DisposeOf()
            {
                progress.Value = 0;
                progress.Visible = false;
                text.Text = "Idle";
            }
        }
        public static class UT
        {
            public static void SetText(ToolStripLabel label, string text)
            {
                if (label.Text != text)
                {

                    _ = AsyncHelper.RunTaskAsync(new CTask("Set Text", "Sets the text of a label", () =>
                    {
                        taskcount++;
                        label.Text = text;
                        taskcount--;
                    }));

                }
            }
        }


        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("Clicked");
            CTask task = new("Test", "Test", () => MessageBox.Show("Hydrix Studio 2023: Version 1.0\nMade by Azureian."));
            _ = AsyncHelper.RunTaskAsync(task);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void newTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] names = { "New Tab", "New Tab 2", "New Tab 3", "New Tab 4", "New Tab 5", "New Tab 6", "New Tab 7", "New Tab 8", "New Tab 9", "New Tab 10" };
            // Choose a random name from names array
            Random random = new Random();
            int index = random.Next(names.Length);
            string name = names[index];
            // Create a new tab
            CreateNewTab(name);
        }

        public void SaveData()
        {
            //get the current tab
            TabPage tabPage = siticoneTabControl2.SelectedTab;
            //get the richtextbox
            RichTextBox rtb = (RichTextBox)tabPage.Controls["editor"];
            //get the text
            string text = rtb.Text;
            //get the name
            string name = tabPage.Text;
            //get the path
            string path = currentdirectory + "\\" + name;
            string fixedpath = path.Replace("*", "");
            File.WriteAllText(fixedpath, text);
            //remove the * from the tab name
            tabPage.Text = tabPage.Text.Replace("*", "");
            //set updatetext to saved
            UT.SetText(updatetext, "Saved");
        }

        /// <summary>
        /// If the file is unsaved, add a * to the end of the tab name.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IsUnsaved(object sender, EventArgs e)
        {
            //get selected tab, and get the richtextbox
            TabPage tabPage = siticoneTabControl2.SelectedTab;
            if (tabPage == null)
            {
                return;
            }
            if (tabPage.Text.EndsWith("*") == false)
            {
                tabPage.Text = tabPage.Text + "*";
            }
        }

        void WatchForChanges()
        {
            while (true)
            {
                //check if siticoneTabControl2 has any tabs, if not, gray out save button
                if (siticoneTabControl2.TabCount == 0)
                {
                    toolsavebutton.Enabled = false;
                }
                else
                {
                    toolsavebutton.Enabled = true;
                }
            }
        }
        /// <summary>
        /// Creates a new tab with the name specified.
        /// </summary>
        /// <param name="name"></param>
        public void CreateNewTab(string name)
        {
            if (siticoneTabControl2.Visible == false)
            {
                siticoneTabControl2.Visible = true;
            }
            // Create a new tab in siticone tabcontrol 2
            TabPage tabPage = new TabPage(name);
            siticoneTabControl2.TabPages.Add(tabPage);

            // Create a new richtextbox in the tab and dock to fill
            RichTextBox rtb = new RichTextBox();
            rtb.Dock = DockStyle.Fill;
            rtb.BorderStyle = BorderStyle.None;
            rtb.BackColor = Color.FromArgb(37, 27, 63);
            rtb.ForeColor = Color.FromArgb(255, 192, 203);
            rtb.Font = new Font("Consolas", 12);
            tabPage.BorderStyle = BorderStyle.None;
            // Add the RichTextBox control to the tab page
            tabPage.Controls.Add(rtb);
            //add tag "editor" to it
            rtb.Tag = "editor";
            //set name to editor
            rtb.Name = "editor";
            //add text changed event
            rtb.TextChanged += new EventHandler(IsUnsaved);
        }


        /// <summary>
        /// Creates a new tab with the name and file contents specified.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="filepath"></param>
        public void CreateNewTab(string name, string filepath)
        {
            if (siticoneTabControl2.Visible == false)
            {
                siticoneTabControl2.Visible = true;
            }
            TabPage tabPage = new TabPage()
            {
                Text = name
            };
            siticoneTabControl2.TabPages.Add(tabPage);
            RichTextBox rtb = new RichTextBox()
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.None,
                BackColor = Color.FromArgb(37, 27, 63),
                ForeColor = Color.FromArgb(255, 192, 203),
                Font = new Font("Consolas", 12)
            };
            tabPage.BorderStyle = BorderStyle.None;
            tabPage.Controls.Add(rtb);
            rtb.Tag = "editor";
            rtb.Name = "editor";
            rtb.Text = File.ReadAllText(filepath);
            rtb.TextChanged += new EventHandler(IsUnsaved);
        }

        private void siticoneTabControl2_TabIndexChanged(object sender, EventArgs e)
        {
            //if tab index is > 0, show tabcontrol 2
            if (siticoneTabControl2.TabCount != 0)
            {
                Debug.WriteLine("Tab Count: " + siticoneTabControl2.TabCount);
                siticoneTabControl2.Visible = true;
            }
            else
            {
                Debug.WriteLine(e.ToString());
                siticoneTabControl2.Visible = false;
            }
        }

        private void outputtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void NewProjTool_Click(object sender, EventArgs e)
        {
            //ask
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to create a new project? This will close the current project.", "New Project", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //start new form NewProj
                NewProj newProj = new NewProj(this);
                newProj.Show();
                this.Hide();
                //close this form
                newProj.FormClosed += (s, args) => this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do nothing
            }

        }

        private void loadprojbuttontool_Click(object sender, EventArgs e)
        {
            //ask
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to load a project? This will close the current project.", "Load Project", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //file dialog for .hyx file
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Hydrix Project File|*.hyx";
                openFileDialog1.Title = "Open a Hydrix Project File";
                openFileDialog1.ShowDialog();
                //if the file is not null
                if (openFileDialog1.FileName != "")
                {
                    //start new form Mainwindow with hydrix file
                    Mainwindow mainwindow = new Mainwindow(openFileDialog1.FileName);
                    mainwindow.Show();
                    this.Hide();
                    Debug.WriteLine(openFileDialog1.FileName);
                    mainwindow.FormClosed += (s, args) => this.Close();
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                //do nothing
            }
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            //get item double clicked
            TreeNode node = treeView1.SelectedNode;
            //get the name of the node aka file
            string name = node.Text;
            if (name.EndsWith(".hyx"))
            {
                return;
            }
            // use project directory + name to get full path
            string path = currentdirectory + "\\" + name;
            //if the node is a file
            if (File.Exists(path))
            {
                Debug.WriteLine("File: " + path);
                //check if the tab is already open
                foreach (TabPage tabPage in siticoneTabControl2.TabPages)
                {
                    //if the tab is already open
                    if (tabPage.Text == name)
                    {
                        //select the tab
                        siticoneTabControl2.SelectedTab = tabPage;
                        return;
                    }
                }
                CreateNewTab(name, path);
            }
        }

        private void siticoneTabControl2_Click(object sender, EventArgs e)
        {
            //if right click print true
            if (e is MouseEventArgs)
            {
                MouseEventArgs me = (MouseEventArgs)e;
                if (me.Button == MouseButtons.Right)
                {
                    Debug.WriteLine("Right Clicked");
                }
            }
        }

        private void toolsavebutton_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void siticoneTabControl2_DoubleClick(object sender, EventArgs e)
        {
            //if double clicked with rmb, remove tab
            if (e is MouseEventArgs)
            {
                MouseEventArgs me = (MouseEventArgs)e;
                if (me.Button == MouseButtons.Right)
                {
                    //get the tab
                    TabPage tabPage = siticoneTabControl2.SelectedTab;
                    //remove the tab
                    siticoneTabControl2.TabPages.Remove(tabPage);
                }
            }
        }

        private void treeView1_Enter(object sender, EventArgs e)
        {
            //get
        }
        public void RenameFile(string file, string newName)
        {
            //get the file's directory
            string directory = Path.GetDirectoryName(file);
            //get the file's extension
            string extension = Path.GetExtension(file);
            //get the new file path
            string newfile = directory + "\\" + newName;
            //rename the file
            File.Move(file, newfile);
        }
        public static bool IsFileReady(string filename)
        {
            // If the file can be opened for exclusive access it means that the file
            // is no longer locked by another process.
            try
            {
                using (FileStream inputStream = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.None))
                    return inputStream.Length > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            //get the node and rename the file
            TreeNode node = e.Node;
            string file = node.Tag.ToString();
            string newName = e.Label;
            RenameFile(file, newName);

        }

        private void treeView1_Click(object sender, EventArgs e)
        {
            //check if right click, if it is, show context menu
            if (e is MouseEventArgs)
            {
                MouseEventArgs me = (MouseEventArgs)e;
                if (me.Button == MouseButtons.Right)
                {
                    TreeNode node = treeView1.SelectedNode;
                    //create context menu strip
                    ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
                    //create rename button
                    ToolStripMenuItem rename = new ToolStripMenuItem("Rename");
                    //add click event with parameters
                    rename.Click += (s, args) => treeView1.SelectedNode.BeginEdit();
                    //add rename button to context menu strip
                    contextMenuStrip.Items.Add(rename);
                    //create delete button
                    ToolStripMenuItem delete = new ToolStripMenuItem("Delete");
                    //add click event with parameters
                    delete.Click += (s, args) => File.Delete(node.Tag.ToString());
                    //add delete button to context menu strip
                    contextMenuStrip.Items.Add(delete);
                    //show context menu strip
                    contextMenuStrip.Show(treeView1, me.Location);


                }
            }
        }


    }


}