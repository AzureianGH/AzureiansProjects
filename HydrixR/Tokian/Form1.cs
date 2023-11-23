using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.ML;
using Microsoft.ML.Data;
using System.Threading;
using System.Runtime.InteropServices;
using AForge.Controls;
using System.Diagnostics;

namespace Tokian
{
    public partial class Form1 : Form
    {
        private Bitmap screenCapture;
        private CancellationTokenSource tokenSource;
        private MLContext mlContext;
        private ITransformer model;
        private PredictionEngine<CursorPosition, Prediction> predictionEngine;
        public Form1()
        {
            InitializeComponent();
            mlContext = new MLContext();

            // Load your trained ML.NET model here
            model = mlContext.Model.Load("your_model_path", out var modelSchema);

            predictionEngine = mlContext.Model.CreatePredictionEngine<CursorPosition, Prediction>(model);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private async void StartTrackingCursor()
        {
            tokenSource = new CancellationTokenSource();

            while (!tokenSource.Token.IsCancellationRequested)
            {
                var cursorPosition = Cursor.Position;
                var cursorData = new CursorPosition { X = cursorPosition.X, Y = cursorPosition.Y };

                var prediction = predictionEngine.Predict(cursorData);

                Debug.WriteLine($"Predicted cursor position: {prediction.CursorPosition}");

                // Capture a 300x300 area around the cursor
                var x = cursorPosition.X - 150;
                var y = cursorPosition.Y - 150;
                var width = 300;
                var height = 300;

                screenCapture = new Bitmap(width, height);

                using (var graphics = Graphics.FromImage(screenCapture))
                {
                    graphics.CopyFromScreen(x, y, 0, 0, new Size(width, height));
                }

                pictureBox1.Image = screenCapture;

                await Task.Delay(100); // Adjust the delay as needed
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartTrackingCursor();
        }
    }
    public class CursorPosition
    {
        public float X { get; set; }
        public float Y { get; set; }
    }
    public class Prediction
    {
        [ColumnName("PredictedLabel")]
        public string CursorPosition;
    }

}