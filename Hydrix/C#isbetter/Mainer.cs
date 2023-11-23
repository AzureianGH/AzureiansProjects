using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace C_isbetter
{
    internal class Mainer
    {
        static async Task Main(string[] args)
        {
            string link = "https://www.dundeecity.gov.uk/sites/default/files/publications/civic_renewal_forms.zip"; 
            string downloadFolder = "E:\\Downloads\\"; 
            int totalWidth = 50; // Total width of the loading bar
            Console.CursorVisible = false; // Hide the cursor
            await DownloadFileWithProgressBarAsync(link, downloadFolder, totalWidth);
        }

        static async Task DownloadFileWithProgressBarAsync(string url, string savePath, int totalWidth)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    byte[] data = await client.GetByteArrayAsync(url);
                    string fileName = Path.GetFileName(url);
                    string filePath = Path.Combine(savePath, fileName);

                    // Check if the directory exists, create it if not
                    Directory.CreateDirectory(savePath);

                    using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {
                        int bytesRead = 0;
                        long totalBytes = data.Length;
                        int bufferSize = 1024;
                        byte[] buffer = new byte[bufferSize];

                        Console.WriteLine("Downloading...");
                        for (int i = 0; i < totalBytes; i += bytesRead)
                        {
                            bytesRead = (int)Math.Min(bufferSize, totalBytes - i);
                            await fileStream.WriteAsync(data, i, bytesRead);

                            // Calculate the progress and display the loading bar
                            int progress = (int)((i + bytesRead) * totalWidth / totalBytes);
                            Console.Write("[");
                            for (int j = 0; j < progress; j++)
                            {
                                Console.Write("#");
                            }
                            for (int j = progress; j < totalWidth; j++)
                            {
                                Console.Write(" ");
                            }
                            Console.Write($"] {progress * 2}%");

                            // Move the cursor back to the beginning
                            Console.SetCursorPosition(0, Console.CursorTop);
                        }

                        Console.WriteLine("\nDownload complete!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
