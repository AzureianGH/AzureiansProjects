using System;
using System.Threading;
namespace GeoRenderer
{
    public partial class Form1 : Form
    {
        Canvas canvas;
        public Form1()
        {
            InitializeComponent();
            canvas = new Canvas(Width, Height, Color.White, CreateGraphics());
            canvas.DrawPoint(new Point(100, 100), Color.Black);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //draw line from (0,0) to (100,100) on the form
            Paint += Form1_Paint;
        }
        public void Form1_Paint(object sender, PaintEventArgs e)
        {
            Handler();
        }
        public void Handler()
        {
            canvas.DrawLine(new Point(100, 100), new Point(200, 200), Color.Black);
            //draw line from 200, 200 to 300, 100
            canvas.DrawLine(new Point(200, 200), new Point(300, 100), Color.Black);
            //draw line from 300, 100 to 100, 100
            canvas.DrawLine(new Point(300, 100), new Point(100, 100), Color.Black);
            //for each angle in the triangle, draw a line from the center to the angle
            canvas.DrawLine(new Point(200, 150), new Point(100, 100), Color.Black);
            canvas.DrawLine(new Point(200, 150), new Point(300, 100), Color.Black);
            canvas.DrawLine(new Point(200, 150), new Point(200, 200), Color.Black);

        }
    }
    public class Canvas
    {
        public Graphics Graphics { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Color BackgroundColor { get; set; }
        public Canvas(int width, int height, Color backgroundColor, Graphics graphics)
        {
            Width = width;
            Height = height;
            BackgroundColor = backgroundColor;
            Graphics = graphics;
        }
        public void Resize(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public void Clear(Color color)
        {
            Graphics.Clear(color);
        }
        public void DrawPoint(Point point, Color color)
        {
            Graphics.FillRectangle(new SolidBrush(color), point.X, point.Y, 1, 1);
        }
        public void DrawLine(Point start, Point end, Color color)
        {
            Graphics.DrawLine(new Pen(color), start.X, start.Y, end.X, end.Y);
        }
        public void DrawPolygon(Point[] points, Color color)
        {
            Graphics.FillPolygon(new SolidBrush(color), points);
        }
        public void DrawCircle(Point center, int radius, Color color)
        {
            Graphics.DrawEllipse(new Pen(color), center.X - radius, center.Y - radius, radius * 2, radius * 2);
        }
        public void DrawEllipse(Point center, int radiusX, int radiusY, Color color)
        {
            Graphics.DrawEllipse(new Pen(color), center.X - radiusX, center.Y - radiusY, radiusX * 2, radiusY * 2);
        }
        public void DrawRectangle(Point topLeft, int width, int height, Color color)
        {
            Graphics.DrawRectangle(new Pen(color), topLeft.X, topLeft.Y, width, height);
        }
        public void DrawString(string text, Point location, Font font, Color color)
        {
            Graphics.DrawString(text, font, new SolidBrush(color), location);
        }
        public void DrawImage(Image image, Point location)
        {
            Graphics.DrawImage(image, location);
        }
    }
}
