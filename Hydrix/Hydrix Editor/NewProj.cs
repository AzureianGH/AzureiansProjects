using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hydrix_Editor
{
    public partial class NewProj : Form
    {
        public bool isDragging = false;
        public Point offset;
        public Form launchsettings;
        public bool check1 = false;
        public bool check2 = false;
        public bool check3 = false;
        public NewProj(Form _launch)
        {
            InitializeComponent();
            launchsettings = _launch;
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

        }

        private void siticoneButton1_Click_1(object sender, EventArgs e)
        {
            launchsettings.Show();
            this.Close();
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            //open folder selecter
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Select a folder to create your project in.";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                //set the text to the selected folder
                projdirectory.Text = fbd.SelectedPath;
            }
        }

        private void createproj_Click(object sender, EventArgs e)
        {
            
            if (projname.TextLength < 50 && projname.Text != "")
            {
                check1 = true;
            }

            if (Directory.Exists(projdirectory.Text))
            {
                check2 = true;
            }

            //languagecombo if it has something in it
            if (languagecombo.Text != "")
            {
                check3 = true;
            }

            if (check1)
            {
                  if (check2)
                {
                    if (check3)
                    {
                        if (!File.Exists(Environment.CurrentDirectory + "\\projects.txt"))
                        {
                            FileStream handler = File.Create(Environment.CurrentDirectory + "\\projects.txt");
                            handler.Close();
                        }
                        string text = File.ReadAllText(Environment.CurrentDirectory + "\\projects.txt");
                        foreach (string line in text.Split('\n'))
                        {
                            if (line.Contains(projname.Text))
                            {
                                MessageBox.Show("A project with that name already exists.");
                                return;
                            }
                        }
                        File.WriteAllText(projdirectory.Text + "\\" + projname.Text + ".hyx", "language;" + languagecombo.Text + "\ndirectory;" + projdirectory.Text + "\nname;" + projname.Text);
                        File.AppendAllText(Environment.CurrentDirectory + "\\projects.txt", projname.Text + "\n");
                        Thread.Sleep(500);
                        Mainwindow main = new Mainwindow(projdirectory.Text + "\\" + projname.Text + ".hyx");
                        main.Show();
                        this.Hide();
                        main.FormClosed += (s, args) => this.Close();
                    }
                    else
                    {
                        //messagebox
                        MessageBox.Show("Please select a language.");
                    }
                }
                  else
                {
                      //messagebox
                    MessageBox.Show("Please enter a valid project directory.");
                }
            }
            else
            {
                //messagebox
                MessageBox.Show("Please enter a valid project name.");
            }
        }
    }
}
