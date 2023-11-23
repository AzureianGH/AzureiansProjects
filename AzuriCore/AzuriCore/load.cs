using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzuriCore
{
    public partial class load : Form
    {
        public load()
        {
            InitializeComponent();
        }

        private void load_Load(object sender, EventArgs e)
        {
            BackColor = Color.LimeGreen;
            TransparencyKey = Color.LimeGreen;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
