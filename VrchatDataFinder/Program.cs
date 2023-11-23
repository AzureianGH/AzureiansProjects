namespace VrchatDataFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //first arg is folder to search, second arg is output folder
            var finder = new Finder(args[0], args[1]);
            finder.FindandOut();
        }
    }
    public class Finder
    {
        public string InputFolder { get; set; }
        public string OutputFolder { get; set; }
        public Finder(string inputFolder, string outputFolder)
        {
            InputFolder = inputFolder;
            OutputFolder = outputFolder;
        }
        public void FindandOut()
        {
            //for each folder and subfolder in input folder, look for .__data, if there is, make a folder in the output folder starting at 0 and incrementing by 1 for each new folder
            //then copy the contents of the folder to the output folder
            foreach (var folder in Directory.GetDirectories(InputFolder, "*", SearchOption.AllDirectories))
            {
                Console.WriteLine($"Checking {folder}");
                var files = Directory.GetFiles(folder);
                foreach (var file in files)
                {
                    // Check if the file has the desired "__data" name with no extension
                    if (Path.GetFileNameWithoutExtension(file) == "__data")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Found data in {folder}");
                        Console.ForegroundColor = ConsoleColor.White;
                        var newFolder = Path.Combine(OutputFolder, Directory.GetDirectories(OutputFolder).Length.ToString());
                        Directory.CreateDirectory(newFolder);
                        File.Copy(file, Path.Combine(newFolder, Path.GetFileName(file)));
                    }
                }
                if (files.Length == 0)
                {
                    //write the contents of the folder to console
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"No data in {folder}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
    }
}