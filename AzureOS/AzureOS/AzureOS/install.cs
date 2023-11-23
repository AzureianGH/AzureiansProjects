using System;
using System.IO;
using Sys = Cosmos.System;
using Cosmos.System.FileSystem;
namespace AzureOS
{
    public class install
    {
        
        public void RunInstaller(CosmosVFS AzuriFS) {
            try
            {
                //Print in large letters
                //clear screen
                Console.Clear();
                Console.WriteLine("Azure OS Installer");
                Console.WriteLine("Installing Azure OS...");
                //Clear all existing files
                //make directories
                Directory.CreateDirectory(@"0:/System");
                Directory.CreateDirectory(@"0:/Azure64");
                Directory.CreateDirectory(@"0:/Users");
                //make files
                File.CreateText(@"0:/System/config.ac");
                //Write in config.ac Language: en
                File.WriteAllText(@"0:/System/config.ac", "Language: en");

                //Create DefaultUsr folder (hidden)
                Directory.CreateDirectory(@"0:/Users/DefaultUsr");
                Directory.CreateDirectory(@"0:/Users/DefaultUsr/Home");
                Directory.CreateDirectory(@"0:/Users/DefaultUsr/Home/Documents");
                File.CreateText(@"0:/Users/DefaultUsr/Home/Documents/Welcome.txt");
                File.WriteAllText(@"0:/Users/DefaultUsr/Home/Documents/Welcome.txt", "Welcome to Azure OS!");
                Directory.CreateDirectory(@"0:/Azure64/Registery");
                Directory.CreateDirectory(@"0:/Azure64/Registery/AOSK-SYSTEM");
                Directory.CreateDirectory(@"0:/Azure64/Temp");
                Console.WriteLine("Username: ");
                string username = Console.ReadLine();
                username= username.Trim();
                username = username.Replace("/","");
                username = username.Replace("\\", "");

                //Restart
                Sys.Power.Reboot();
            }
            catch (Exception e)
                    {
                        Console.WriteLine("Error: " + e.Message);
                    }
        }
    }
}