using System;
using System.IO;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms.Image;
using Microsoft.ML.Trainers.LightGbm;
public class CursorImageData
{
    [LoadColumn(0)]
    public string ImagePath;

    [LoadColumn(1)]
    public string CursorPosition;
}

public class CursorImagePrediction
{
    [ColumnName("PredictedLabel")]
    public string PredictedCursorPosition;
}

public static class Prog
{
    public static void Starting()
    {
        // Define your model output path
        string modelPath = "path_to_save_trained_model.zip";

        var context = new MLContext();

        // Load images from the "images" folder
        var imageFolder = Path.Combine(Environment.CurrentDirectory, "images");
        var imageFiles = Directory.GetFiles(imageFolder, "*", SearchOption.AllDirectories);

        // Create a list to store image data
        var imageData = new List<CursorImageData>();

        foreach (var imagePath in imageFiles)
        {
            // Extract the cursor position from the image filename
            var cursorPosition = Path.GetFileNameWithoutExtension(imagePath);

            // Add the image path and cursor position to the list
            imageData.Add(new CursorImageData
            {
                ImagePath = imagePath,
                CursorPosition = cursorPosition
            });
        }

        // Create a data view from the image data
        var data = context.Data.LoadFromEnumerable(imageData);

        // Data preprocessing
        var pipeline = context.Transforms.Conversion.MapValueToKey("Label")
            .Append(context.Transforms.LoadImages("Image", "images")
                .Append(context.Transforms.ResizeImages("Image", 300, 300))
                .Append(context.Transforms.ExtractPixels("Image"))
                .Append(context.Transforms.NormalizeMinMax("Image"))
                .Append(context.Transforms.Conversion.MapKeyToValue("Label")));

        // Choose a machine learning algorithm (e.g., a classification algorithm)
        var trainer = context.MulticlassClassification.Trainers
            .LightGbm();

        // Define the training pipeline
        var trainingPipeline = pipeline
            .Append(trainer)
            .Append(context.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

        // Train the model
        var model = trainingPipeline.Fit(data);

        // Save the trained model
        context.Model.Save(model, data.Schema, modelPath);

        Console.WriteLine("Model saved to " + modelPath);
    }
}
