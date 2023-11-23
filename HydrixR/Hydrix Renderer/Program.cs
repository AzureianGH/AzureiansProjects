using System;
using System.Drawing;
using System.Windows.Forms;

public class Simple3DRenderer : Form
{
    private Bitmap offscreenBitmap;
    private Graphics offscreenGraphics;
    private Pen pen;
    private Point3D[] cubeVertices;
    private int[][] cubeEdges;
    private int[][] cubeFaces;
    private float rotationX = 0;
    private float rotationY = 0;

    public Simple3DRenderer()
    {
        //form size 800 by 800
        ClientSize = new Size(800, 800);
        DoubleBuffered = true;
        offscreenBitmap = new Bitmap(ClientSize.Width, ClientSize.Height);
        offscreenGraphics = Graphics.FromImage(offscreenBitmap);
        pen = new Pen(Color.Black);
        InitializeCube();
        Paint += new PaintEventHandler(OnPaint);
        KeyDown += new KeyEventHandler(OnKeyDown);
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque, true);
    }
    private void InitializeCube()
    {
        cubeVertices = new Point3D[]
        {
        new Point3D(-1, -1, -1),
        new Point3D(1, -1, -1),
        new Point3D(1, 1, -1),
        new Point3D(-1, 1, -1),
        new Point3D(-1, -1, 1),
        new Point3D(1, -1, 1),
        new Point3D(1, 1, 1),
        new Point3D(-1, 1, 1),
        new Point3D(1, -1, -1),
        new Point3D(11, -1, -1),
        new Point3D(11, 1, -1),
        new Point3D(-11, 1, -1),
        new Point3D(-11, -1, 1),
        new Point3D(11, -1, 1),
        new Point3D(1, 1, 1),
        new Point3D(-1, 1, 1),
        };

        cubeEdges = new int[][]
        {
        new int[] { 0, 1 },
        new int[] { 1, 2 },
        new int[] { 2, 3 },
        new int[] { 3, 0 },
        new int[] { 4, 5 },
        new int[] { 5, 6 },
        new int[] { 6, 7 },
        new int[] { 7, 4 },
        new int[] { 0, 4 },
        new int[] { 1, 5 },
        new int[] { 2, 6 },
        new int[] { 3, 7 },
        new int[] { 04, 1 },
        new int[] { 15, 2 },
        new int[] { 62, 3 },
        new int[] { 23, 0 },
        new int[] { 34, 5 },
        new int[] { 54, 6 },
        new int[] { 61, 7 },
        new int[] { 73, 4 },
        new int[] { 10, 4 },
        new int[] { 11, 5 },
        new int[] { 12, 6 },
        new int[] { 13, 7 }
        };

        cubeFaces = new int[][]
        {
        // Front face
        new int[] { 0, 1, 2, 3 },
        // Back face
        new int[] { 4, 5, 6, 7 },
        // Left face
        new int[] { 0, 1, 5, 4 },
        // Right face
        new int[] { 2, 3, 7, 6 },
        // Top face
        new int[] { 0, 3, 7, 4 },
        // Bottom face
        new int[] { 1, 2, 6, 5 }
        };

    }


    private void OnPaint(object sender, PaintEventArgs e)
    {
        offscreenGraphics.Clear(Color.White);

        // Define an array of colors for each face.
        Color[] faceColors = new Color[]
        {
        Color.Red,    // Front face
        Color.Blue,   // Back face
        Color.Green,  // Left face
        Color.Yellow, // Right face
        Color.Orange, // Top face
        Color.Purple  // Bottom face
        };

        for (int i = 0; i < cubeFaces.Length; i++)
        {
            // Create an array to store the screen coordinates of the face vertices.
            Point[] faceVertices = new Point[cubeFaces[i].Length];

            for (int j = 0; j < cubeFaces[i].Length; j++)
            {
                Point3D vertex = RotatePoint(cubeVertices[cubeFaces[i][j]]);
                faceVertices[j] = Project(vertex);
            }

            // Set the brush color to the corresponding face color.
            Brush brush = new SolidBrush(Color.Purple);

            // Fill the face with the specified color.
            

            // Set the pen color to black for drawing edges.
            Pen pen = new Pen(Color.Black);

            // Draw the edges of the face using the black pen.
            offscreenGraphics.DrawPolygon(pen, faceVertices);
        }

        e.Graphics.DrawImage(offscreenBitmap, 0, 0);
    }

    private Point3D RotatePoint(Point3D point)
    {
        // Apply rotation around X and Y axes.
        float cosX = (float)Math.Cos(rotationX);
        float sinX = (float)Math.Sin(rotationX);
        float cosY = (float)Math.Cos(rotationY);
        float sinY = (float)Math.Sin(rotationY);

        float x = point.X;
        float y = point.Y * cosX - point.Z * sinX;
        float z = point.Y * sinX + point.Z * cosX;

        x = x * cosY - z * sinY;
        z = x * sinY + z * cosY;

        return new Point3D(x, y, z);
    }

    private Point Project(Point3D point)
    {
        // Simple perspective projection for demonstration purposes.
        float distance = 5; // Adjust this value for different perspectives.
        float scaleFactor = 100; // Adjust this value for scaling.
        int centerX = ClientSize.Width / 2;
        int centerY = ClientSize.Height / 2;

        float x = point.X * distance / (distance - point.Z);
        float y = point.Y * distance / (distance - point.Z);

        return new Point((int)(x * scaleFactor) + centerX, (int)(y * scaleFactor) + centerY);
    }

    private void RotateX(float angle)
    {
        float cosX = (float)Math.Cos(angle);
        float sinX = (float)Math.Sin(angle);

        for (int i = 0; i < cubeVertices.Length; i++)
        {
            float y = cubeVertices[i].Y * cosX - cubeVertices[i].Z * sinX;
            float z = cubeVertices[i].Y * sinX + cubeVertices[i].Z * cosX;

            cubeVertices[i] = new Point3D(cubeVertices[i].X, y, z);
        }
    }

    private void RotateY(float angle)
    {
        float cosY = (float)Math.Cos(angle);
        float sinY = (float)Math.Sin(angle);

        for (int i = 0; i < cubeVertices.Length; i++)
        {
            float x = cubeVertices[i].X * cosY - cubeVertices[i].Z * sinY;
            float z = cubeVertices[i].X * sinY + cubeVertices[i].Z * cosY;

            cubeVertices[i] = new Point3D(x, cubeVertices[i].Y, z);
        }
    }

    private void OnKeyDown(object sender, KeyEventArgs e)
    {
        const float rotationSpeed = 0.05f;

        switch (e.KeyCode)
        {
            case Keys.Left:
                RotateY(-rotationSpeed);
                break;
            case Keys.Right:
                RotateY(rotationSpeed);
                break;
            case Keys.Up:
                RotateX(-rotationSpeed);
                break;
            case Keys.Down:
                RotateX(rotationSpeed);
                break;
        }

        Invalidate(); // Redraw the cube with the updated rotation.
    }

    public static void Main()
    {
        Application.Run(new Simple3DRenderer());
        
    }
}

public struct Point3D
{
    public float X;
    public float Y;
    public float Z;

    public Point3D(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }
}
