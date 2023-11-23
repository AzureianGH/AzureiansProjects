using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Azuri_Editor
{

    public partial class Form2 : Form
    {
        string currentex;
        public Form2(string ex)
        {
            InitializeComponent();
            currentex = ex;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ExceptionLabel.Text = currentex;
        }

        private void ExceptionLabel_Click(object sender, EventArgs e)
        {
            //set ExceptionLabel.Text to currentex.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Restart the application
            Application.Restart();
        }
    }
}
