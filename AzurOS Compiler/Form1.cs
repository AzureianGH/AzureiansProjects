using System.Runtime.InteropServices;

namespace AzurOS_Compiler
{
    public partial class Form1 : Form
    {
        //unhide console libraryimport

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public Form1()
        {
            InitializeComponent();
            AllocConsole();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //unhide console
            Console.WriteLine("[ZEPHYR VERSION v1]");
        }

        private void browsefile_Click(object sender, EventArgs e)
        {
            //open file dialog
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //look for .s or .asm files
            openFileDialog1.Filter = "Assembly Files|*.s;*.asm";
            openFileDialog1.Title = "Select a Assembly File";
            //if file is selected
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //set text to file path
                mainassemnly.Text = openFileDialog1.FileName;
            }
        }

        private void browseforkernelC_Click(object sender, EventArgs e)
        {
            //open file dialog
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //look for .c or .cpp files
            openFileDialog1.Filter = "C/C++ Files|*.c;*.cpp";
            openFileDialog1.Title = "Select a C/C++ File";
            //if file is selected
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //set text to file path
                mainkernelC.Text = openFileDialog1.FileName;
            }
        }

        private void othercompilables_Click(object sender, EventArgs e)
        {
            //multi select file dialog
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            // any file
            openFileDialog1.Filter = "Any File|*.*";
            openFileDialog1.Title = "Select a File";
            //if file is selected
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //add file to listbox
                compilableslistbox.Items.Add(openFileDialog1.FileName);
            }
        }

        private void compilableslistbox_DoubleClick(object sender, EventArgs e)
        {
            //remove selected item
            compilableslistbox.Items.Remove(compilableslistbox.SelectedItem);
        }

        private void browsefolder_Click(object sender, EventArgs e)
        {
            //open folder dialog
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            //if folder is selected
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (string file in Directory.GetFiles(folderBrowserDialog1.SelectedPath))
                {
                    //add file to listbox
                    compilableslistbox.Items.Add(file);
                }
            }
            //foreach file in folder

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}