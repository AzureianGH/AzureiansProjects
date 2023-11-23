using System;
using System.IO;
using System.Text;

class FusionProgram
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage:");
            Console.WriteLine("To pack: Fusion -pack <outputFileName> <inputFile1> <inputFile2> ...");
            Console.WriteLine("To unpack: Fusion -unpack <fusedFileName>");
            return;
        }

        string operation = args[0].ToLower();

        if (operation == "-pack")
        {
            // Packing operation
            if (args.Length < 3)
            {
                Console.WriteLine("Usage: Fusion -pack <outputFileName> <inputFile1> <inputFile2> ...");
                return;
            }

            string outputFileName = args[1];
            string[] inputFiles = new string[args.Length - 2];
            Array.Copy(args, 2, inputFiles, 0, args.Length - 2);

            // Create a FileStream to write to the output file
            using (FileStream outputStream = new FileStream(outputFileName, FileMode.Create))
            {
                int fileNumber = 1; // Initialize a file number counter

                foreach (string inputFile in inputFiles)
                {
                    if (!File.Exists(inputFile))
                    {
                        Console.WriteLine($"Input file '{inputFile}' does not exist. Skipping.");
                        continue;
                    }

                    // Read the file bytes
                    byte[] fileBytes = File.ReadAllBytes(inputFile);

                    // Determine the file format based on the file extension
                    string fileExtension = Path.GetExtension(inputFile);
                    string fileFormat = fileExtension.TrimStart('.');

                    // Write the "cNk" indicator followed by the file size and format
                    string indicator = $"{fileNumber}cNk{fileBytes.Length}({fileFormat})\n";
                    byte[] indicatorBytes = Encoding.ASCII.GetBytes(indicator);
                    outputStream.Write(indicatorBytes, 0, indicatorBytes.Length);

                    // Write the file data
                    outputStream.Write(fileBytes, 0, fileBytes.Length);

                    fileNumber++; // Increment the file number counter
                }
            }

            Console.WriteLine("Files fused successfully.");
        }
        else if (operation == "-unpack")
        {
            // Unpacking operation
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: Fusion -unpack <fusedFileName>");
                return;
            }

            string fusedFileName = args[1];

            // Check if the fused file exists
            if (!File.Exists(fusedFileName))
            {
                Console.WriteLine("The specified fused file does not exist.");
                return;
            }

            // Read the fused file
            using (FileStream fusedFileStream = new FileStream(fusedFileName, FileMode.Open))
            {
                byte[] indicatorBytes = new byte[1024]; // Increased to accommodate larger indicators
                int bytesRead;

                while ((bytesRead = fusedFileStream.Read(indicatorBytes, 0, indicatorBytes.Length)) > 0)
                {
                    string indicator = Encoding.ASCII.GetString(indicatorBytes, 0, bytesRead);

                    // Check if the indicator is valid (contains "cNk" and ends with a newline character)
                    if (indicator.Contains("cNk") && indicator.EndsWith("\n"))
                    {
                        // Split indicators by newline character ('\n')
                        string[] indicators = indicator.Split('\n');

                        foreach (string singleIndicator in indicators)
                        {
                            // Check if the indicator is valid (starts with a number followed by "cNk")
                            if (singleIndicator.EndsWith("cNk"))
                            {
                                // Extract the file number, file size, and file format
                                string[] indicatorParts = singleIndicator.Split('(');
                                if (indicatorParts.Length == 2)
                                {
                                    string fileNumberStr = indicatorParts[0];
                                    int fileNumber;
                                    if (int.TryParse(fileNumberStr, out fileNumber))
                                    {
                                        string fileInfo = indicatorParts[1].TrimEnd(')');
                                        string[] fileInfoParts = fileInfo.Split(',');
                                        if (fileInfoParts.Length == 2)
                                        {
                                            int fileSize = int.Parse(fileInfoParts[0]);
                                            string fileFormat = fileInfoParts[1];

                                            // Read the file data
                                            byte[] fileData = new byte[fileSize];
                                            fusedFileStream.Read(fileData, 0, fileSize);

                                            // Save the extracted file with a unique name
                                            string outputFileName = $"extracted_{fileNumber}.{fileFormat}";
                                            File.WriteAllBytes(outputFileName, fileData);

                                            Console.WriteLine($"Extracted {fileFormat} file: {outputFileName}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid file info format. Exiting.");
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid file number format. Exiting.");
                                        return;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid indicator format. Exiting.");
                                    return;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid indicator found. Exiting.");
                                return;
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Extraction completed successfully.");
        } 
        else
        {
            Console.WriteLine("Invalid operation.");
        }
    }
}
