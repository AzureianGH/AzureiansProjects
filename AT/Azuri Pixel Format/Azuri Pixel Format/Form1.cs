using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Azuri_Pixel_Format
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "/";
            openFileDialog.Title = "Select file";
            openFileDialog.Filter = "apf files (*.apf)|*.apf|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ViewAPF(openFileDialog.FileName);
            }
        }

        private void ConvertFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "/";
            openFileDialog.Title = "Select file";
            openFileDialog.Filter = "Jpg Files (*.jpg)|*.jpg|Png Files (*.png)|*.png|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ConvertJpgToAPF(openFileDialog.FileName);
            }
        }

        private void ConvertJpgToAPF(string filename)
        {
            using (Bitmap img = new Bitmap(filename))
            {
                int width = img.Width;
                int height = img.Height;
                Console.WriteLine("Image size: " + width + "x" + height);

                string fileExtension = Path.GetExtension(filename);
                string newFilename = filename.Replace(fileExtension, ".apf");

                using (StreamWriter writer = new StreamWriter(newFilename))
                {
                    writer.WriteLine(width + "x" + height);

                    for (int x = 0; x < width; x++)
                    {
                        for (int y = 0; y < height; y++)
                        {
                            Color pixelColor = img.GetPixel(x, y);
                            int r = pixelColor.R;
                            int g = pixelColor.G;
                            int b = pixelColor.B;
                            writer.WriteLine(r + "," + g + "," + b);
                        }
                    }
                }

                Console.WriteLine("Done!");
            }
        }

        private void ViewAPF(string filename)
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                string sizeLine = reader.ReadLine();
                string[] size = sizeLine.Split('x');
                int width = int.Parse(size[0]);
                int height = int.Parse(size[1]);
                Console.WriteLine("Image size: " + width + "x" + height);

                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        string rgbLine = reader.ReadLine();
                        string[] rgb = rgbLine.Split(',');
                        int r = int.Parse(rgb[0]);
                        int g = int.Parse(rgb[1]);
                        int b = int.Parse(rgb[2]);

                        Label pixel = new Label();
                        pixel.BackColor = Color.FromArgb(r, g, b);
                        pixel.Width = 2;
                        pixel.Height = 1;
                        pixel.Location = new Point(x, y);
                        Controls.Add(pixel);
                        Application.DoEvents();
                    }
                }
            }
        }
    }
}
