using System;
using System.Collections.Generic;
namespace SIN_Expr
{
    public partial class form1 : Form
    {
        public form1()
        {
            InitializeComponent();
            //Run the loop check in a separate thread
            Thread thread = new Thread(new ThreadStart(LoopCheck));
            thread.Start();
        }
        public void LoopCheck()
        {
            while (true)
            {
                //Form Keypress
                Control.Kep
                //add 3 to the combobox
                comboBox1.Items.Add("3");
            }
        }
    }
}