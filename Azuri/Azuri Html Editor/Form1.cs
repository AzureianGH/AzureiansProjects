
namespace Azuri_Html_Editor
{
    public partial class Form1 : Form
    {
        bool projopen = false;
        string version = "0.0.1";
        string filepath;
        public Form1()
        {
            InitializeComponent();
            //Create new thread for runtime
            Thread runtime = new Thread(RunTime);
            runtime.Start();
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void htmlToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void FileExplorer_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
        public void RunTime()
        {
            while (true)
            {
                if (projopen)
                {
                    UpdateFileExplorer();
                }
                Thread.Sleep(1500);
            }
        }
        public void UpdateFileExplorer()
        {
            if (projopen)
            {
                // Use Invoke to update UI controls from a separate thread
                FileExplorer.Invoke((MethodInvoker)delegate
                {
                    //Clear the treeview
                    FileExplorer.Nodes.Clear();

                    //Add the root node
                    FileExplorer.Nodes.Add(ProjNameTB.Text);

                    //Add the sub nodes using FileScanner and DirectoryScanner
                    string[] files = FileScanner(filepath + "\\" + ProjNameTB.Text);
                    string[] dirs = DirectoryScanner(filepath + "\\" + ProjNameTB.Text);

                    //Add the files to the root node
                    for (int i = 0; i < files.Length; i++)
                    {
                        FileExplorer.Nodes[0].Nodes.Add(files[i]);
                    }

                    //Add the directories to the root node
                    for (int i = 0; i < dirs.Length; i++)
                    {
                        FileExplorer.Nodes[0].Nodes.Add(dirs[i]);
                    }
                });
            }
        }
        public string[] FileScanner(string directory)
        {
            //Get each file in the dir, and all directories, and the files in those and the dirs in those
            string[] files = Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories);
            return files;

        }
        public string[] DirectoryScanner(string directory)
        {
            string[] dirs = Directory.GetDirectories(directory, "*.*", SearchOption.AllDirectories);
            return dirs;
        }

        private void Project_HtmlProject_Click(object sender, EventArgs e)
        {
            NewProjMenu.Visible = true;
            CreateNewHTMLLabel.Visible = true;
            ProjNameLabel.Visible = true;
            ProjNameTB.Visible = true;
            ProjLocation.Visible = true;
            ProjLocationTB.Visible = true;
            BrowseFlder.Visible = true;
            CreateProjButton.Visible = true;
        }

        private void FBDialog_HelpRequest(object sender, EventArgs e)
        {

        }

        private void BrowseFlder_Click(object sender, EventArgs e)
        {
            DialogResult result = FBDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                filepath = FBDialog.SelectedPath;
                ProjLocationTB.Text = filepath;
            }
        }

        private void CreateProjButton_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(MakeNewProj);
            thread.Start();
        }
        public void MakeNewProj()
        {
            //Check if ProjLocationTB is not null and if ProjNameTB is not null
            if (ProjLocationTB.Text != null && ProjNameTB.Text != null && Directory.Exists(filepath))
            {
                Invoke((MethodInvoker)delegate
                {
                        //hide
                    projopen = true;
                    NewProjMenu.Visible = false;
                    CreateNewHTMLLabel.Visible = false;
                    ProjNameLabel.Visible = false;
                    ProjNameTB.Visible = false;
                    ProjLocation.Visible = false;
                    ProjLocationTB.Visible = false;
                    BrowseFlder.Visible = false;
                    CreateProjButton.Visible = false;
                    StatProg.Visible = true;
                    //set to marquee
                    StatProg.Style = ProgressBarStyle.Marquee;
                    CurrentEventStat.Text = "Creating Project...";
                
                    //Remove any characters from project name that are not allowed in a folder name
                    string projname = ProjNameTB.Text;
                    //For loop and if it is not a number, or letter, or underscore, or dash, remove it
                    CurrentEventStat.Text = "Formating Project Name...";
                    for (int i = 0; i < projname.Length; i++)
                    {
                        if (!char.IsLetterOrDigit(projname[i]) && projname[i] != '_' && projname[i] != '-')
                        {
                            projname = projname.Remove(i, 1);
                        }
                    }
                    CurrentEventStat.Text = "Creating Project File...";
                    //Create the directory
                    Directory.CreateDirectory(filepath + "\\" + projname);
                    var handle = File.Create(filepath + "\\" + projname + "\\" + projname + ".azc");
                    handle.Close();
                    CurrentEventStat.Text = "Creating Required Directories...";
                    Directory.CreateDirectory(filepath + "\\" + projname + "\\html");
                    Directory.CreateDirectory(filepath + "\\" + projname + "\\css");
                    Directory.CreateDirectory(filepath + "\\" + projname + "\\js");
                    Directory.CreateDirectory(filepath + "\\" + projname + "\\img");
                    CurrentEventStat.Text = "Creating Required Files...";
                    var handle2 = File.Create(filepath + "\\" + projname + "\\html\\index.html");
                    handle2.Close();
                    var handle3 = File.Create(filepath + "\\" + projname + "\\css\\style.css");
                    handle3.Close();
                    var handle4 = File.Create(filepath + "\\" + projname + "\\js\\script.js");
                    handle4.Close();
                    Thread.Sleep(750);
                    CurrentEventStat.Text = "Writing to Project Files...";
                    Thread.Sleep(750);
                    //Open index.html and write the basic html code
                    using (StreamWriter sw = new StreamWriter(filepath + "\\" + projname + "\\html\\index.html"))
                    {
                        sw.WriteLine("<!DOCTYPE html>");
                        sw.WriteLine("<html>");
                        sw.WriteLine("<head>");
                        sw.WriteLine("<title>" + projname + "</title>");
                        sw.WriteLine("<link rel=\"stylesheet\" href=\"../css/style.css\">");
                        sw.WriteLine("<script src=\"../js/script.js\"></script>");
                        sw.WriteLine("</head>");
                        sw.WriteLine("<body>");
                        sw.WriteLine("<h1>" + projname + "</h1>");
                        sw.WriteLine("</body>");
                        sw.WriteLine("</html>");
                    }
                    Thread.Sleep(750);

                    using (StreamWriter sw = new StreamWriter(filepath + "\\" + projname + "\\css\\style.css"))
                    {
                        sw.WriteLine("body {");
                        sw.WriteLine("}");
                    }
                    Thread.Sleep(750);

                    using (StreamWriter sw = new StreamWriter(filepath + "\\" + projname + "\\js\\script.js"))
                    {
                        sw.WriteLine("function init() {");
                        sw.WriteLine("}");
                    }
                    Thread.Sleep(750);

                    CurrentEventStat.Text = "Writing Project Locations...";
                    using (StreamWriter sw = new StreamWriter(filepath + "\\" + projname + "\\" + projname + ".azc"))
                    {
                        sw.WriteLine("AzuriHtmlEditorVersion:" + version);
                        sw.WriteLine("name:" + projname);
                        sw.WriteLine("html:" + filepath + "\\" + projname + "\\html\\index.html");
                        sw.WriteLine("css:" + filepath + "\\" + projname + "\\css\\style.css");
                        sw.WriteLine("js:" + filepath + "\\" + projname + "\\js\\script.js");
                    }
                    Thread.Sleep(750);
                    CurrentEventStat.Text = "Finished Creating Project.";
                    CurrentEventStat.Text = "Loading Editor...";
                    MainHTML.Visible = true;
                    MainHTML.Text = File.ReadAllText(filepath + "\\" + projname + "\\html\\index.html");
                    Controls.Add(MainHTML);
                    CurrentEventStat.Text = "Loaded Editor.";
                    CurrentEventStat.Text = "Loading File Explorer...";
                    //Load the files into the file explorer
                    FileExplorer.Nodes.Remove(FileExplorer.Nodes[0]);
                    FileExplorer.Nodes.Add(projname);
                    FileExplorer.Nodes[0].Nodes.Add("html");
                    FileExplorer.Nodes[0].Nodes.Add("css");
                    FileExplorer.Nodes[0].Nodes.Add("js");
                    FileExplorer.Nodes[0].Nodes.Add("img");
                    //Load the files in the html folder, then css, then js, then img
                    string[] htmlfiles = Directory.GetFiles(filepath + "\\" + projname + "\\html");
                    for (int i = 0; i < htmlfiles.Length; i++)
                    {
                        FileExplorer.Nodes[0].Nodes[0].Nodes.Add(htmlfiles[i]);
                    }
                    string[] cssfiles = Directory.GetFiles(filepath + "\\" + projname + "\\css");
                    for (int i = 0; i < cssfiles.Length; i++)
                    {
                        FileExplorer.Nodes[0].Nodes[1].Nodes.Add(cssfiles[i]);
                    }
                    string[] jsfiles = Directory.GetFiles(filepath + "\\" + projname + "\\js");
                    for (int i = 0; i < jsfiles.Length; i++)
                    {
                        FileExplorer.Nodes[0].Nodes[2].Nodes.Add(jsfiles[i]);
                    }
                    string[] imgfiles = Directory.GetFiles(filepath + "\\" + projname + "\\img");
                    for (int i = 0; i < imgfiles.Length; i++)
                    {
                        FileExplorer.Nodes[0].Nodes[3].Nodes.Add(imgfiles[i]);
                    }
                    CurrentEventStat.Text = "Loaded File Explorer.";
                    //Hide the status bar
                    StatProg.Visible = false;
                    CurrentEventStat.Text = "";
                });
            }
        }
    }
}