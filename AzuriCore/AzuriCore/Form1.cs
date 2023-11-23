using System.Runtime.InteropServices;
namespace AzuriCore
{
    public partial class AzuriCoreMain : Form
    {

        public AzuriCoreMain()
        {

            InitializeComponent();

        }


        private void AzuriCoreMain_Load(object sender, EventArgs e)
        {
            //paint loadtxt
            loadtxt.Parent = panel2;
            startLoad();
        }

        private void closebutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void minimizemaxbutton_Click(object sender, EventArgs e)
        {
            //shrink the window to make it look like it disappeared
            FormBorderStyle = FormBorderStyle.None;
            //change size quickly to make it look like it disappeared using for loop
            for (int i = 0; i < 25; i++)
            {
                //change size
                Size = new Size(Size.Width - 50, Size.Height - 50);
                //wait 1 millisecond
                Thread.Sleep(1);
            }
            WindowState = FormWindowState.Minimized;
            //change size back to normal
            Size = new Size(792, 688);
        }
        bool mouseDown;
        private Point offset;
        private void mouseDown_Event(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDown = true;
        }

        private void mouseMove_Event(object sender, MouseEventArgs e)
        {
            if (mouseDown == true)
            {
                Point currenScreenPos = PointToScreen(e.Location);
                Location = new Point(currenScreenPos.X - offset.X, currenScreenPos.Y - offset.Y);
            }
        }

        private void mouseUp_Event(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
        private async void startLoad()
        {
            //change loadlabel to say "Loading Static Assemblies..."
            loadtxt.Text = "Waiting for child-processes to start...";
            for (int i = 0; i < 50; i++)
            {
                //make the progress bar go up
                progressBar1.Value = i;
                //wait 10 milliseconds asynchronously
                await Task.Delay(1);
            }
            //hide both the progress bar and the loadlabel
            progressBar1.Hide();
            loadtxt.Hide();
        }


        private void loadtxt_ParentChanged(object sender, EventArgs e)
        {
        }
    }
}