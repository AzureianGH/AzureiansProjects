using System;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;

class PackageManager
{
    private JObject packages;

    public PackageManager()
    {
        string json = File.ReadAllText("E:\\Downloads\\programs.json"); // Load your JSON file here
        packages = JObject.Parse(json);
    }

    public string GetDownloadLink(string packageName, string architecture, string platform)
    {
        JToken package = packages["packages"][packageName];

        if (package == null)
            return "Package not found.";

        JToken version = package["versions"]["latest"][architecture];

        if (version == null)
            return "Architecture not found.";

        string link = version[platform]?.ToString();

        if (link == null)
            return "Platform not found.";

        return link;
    }
}

class Program
{
    static void Main(string[] args)
    {
        string settingsPath = "settings.json";
        string downloadDirectory = "";

        if (File.Exists(settingsPath))
        {
            downloadDirectory = File.ReadAllText(settingsPath);
        }
        else
        {
            Console.Write("Enter download directory: ");
            downloadDirectory = Console.ReadLine();
            File.WriteAllText(settingsPath, downloadDirectory);
        }

        PackageManager packageManager = new PackageManager();

        string packageName = "visualstudiocode";
        string architecture = "x64";
        string platform = "win";

        string downloadLink = packageManager.GetDownloadLink(packageName, architecture, platform);

        if (downloadLink != null)
        {
            string downloadFilePath = Path.Combine(downloadDirectory, Path.GetFileName(new Uri(downloadLink).LocalPath));

            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadFile(downloadLink, downloadFilePath);
            }

            Console.WriteLine($"Downloaded {packageName} to: {downloadFilePath}");
        }
        else
        {
            Console.WriteLine("Package information not found.");
        }
    }
}
