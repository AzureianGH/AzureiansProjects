string directory = "E:\\SteamLibrary\\steamapps\\workshop\\content\\387990";
// for each folder in that directory, open and check if there is a description.json file
foreach (string folder in Directory.GetDirectories(directory))
{
    string descriptionFile = Path.Combine(folder, "description.json");
    if (File.Exists(descriptionFile))
    {
        // if there is, open it and read the description
        string description = File.ReadAllText(descriptionFile);
        if (description.Contains("Azure") || description.Contains("azure") || description.Contains("lift") || description.Contains("Lift"))
        {
            //write directory to console
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(folder);
            Console.ResetColor();
            if (description.Contains("Azure's Lift"))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(folder);
                Console.ResetColor();
            }
        }
    }
    Console.WriteLine("Checking folder {0}", folder);
}