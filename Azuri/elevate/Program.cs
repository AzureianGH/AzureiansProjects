using System;
using System.Diagnostics;
using System.IO;
using System.IO.Enumeration;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    
    static void Main(string[] args)
    {
        string filepath = "C:\\Windows\\system32\\cmd.exe";
        var proc = new ProcessStartInfo();
        proc.UseShellExecute = true;
        proc.WorkingDirectory = Environment.CurrentDirectory;
        proc.FileName = filepath;
        proc.Verb = "runas";
        //if ran with args --version
        if (args.Length > 0 && args[0] == "--version")
        {
            Console.WriteLine("Azuri Elevate");
            Console.WriteLine("Made by AzuriTools");
            Console.WriteLine("Used for elevating processes.");
            Console.WriteLine("Version 1.0.0");
            return;
        }
        //if the program is ran with args of a exe path
        if (args.Length > 0)
        {
            //if the file exists
            if (File.Exists(args[0]))
            {
                filepath = args[0];
            }
            else
            {
                Console.WriteLine("The file you are trying to run does not exist.");
                return;
            }
        }
        


        try
        {
            Process.Start(proc);
            Console.WriteLine("Elevated this prompt.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Failed to elevate because: " + e.ToString());
        }
    }
}
