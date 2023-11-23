using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hydrix_Editor
{
    public partial class LaunchSettings : Form
    {
        public bool isDragging = false;
        public Point offset;
        public LaunchSettings()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void siticoneButton3_Click(object sender, EventArgs e)
        {
            //minimize
            WindowState = FormWindowState.Minimized;
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            //if the left mouse button is pressed
            if (e.Button == MouseButtons.Left)
            {
                //set isDragging to true
                isDragging = true;
                //set offset to the mouse position
                offset = e.Location;
            }
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            //if isDragging is true
            if (isDragging)
            {
                //get the new location
                Point newLocation = PointToScreen(new Point(e.X, e.Y));
                //offset the new location by the offset
                newLocation.Offset(-offset.X, -offset.Y);
                //set the form location to the new location
                base.Location = newLocation;
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            //dragging is false
            isDragging = false;
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            //start new form NewProj
            NewProj newProj = new NewProj(this);
            newProj.Show();
            this.Hide();
        }

        private void siticoneButton4_Click(object sender, EventArgs e)
        {
            Mainwindow mainwindow = new Mainwindow();
            mainwindow.Show();
            this.Hide();
            mainwindow.FormClosed += (s, args) => this.Close();

        }

        private void BuildTree(DirectoryInfo directoryInfo, TreeNodeCollection addInMe)
        {
            TreeNode curNode = addInMe.Add(directoryInfo.Name);

            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                curNode.Nodes.Add(file.FullName, file.Name);
            }
            foreach (DirectoryInfo subdir in directoryInfo.GetDirectories())
            {
                BuildTree(subdir, curNode.Nodes);
            }
        }

        private void siticoneButton5_Click(object sender, EventArgs e)
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
    }
}
