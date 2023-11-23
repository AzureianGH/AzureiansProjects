namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //create a winforms page
            Form form = new();
            // draw a slider at the top of the page from 0 to 10
            TrackBar trackBar = new();
            trackBar.Minimum = 0;
            trackBar.Maximum = 10;
            trackBar.Value = 5;
            trackBar.Dock = DockStyle.Top;

            form.Paint += (sender, e) => e.Graphics.DrawLine(Pens.Black, 0, 0, 100, Math.Sin(trackBar.Value));
            form.Controls.Add(trackBar);
            // show the page
            Application.Run(form);
        }
    }
}