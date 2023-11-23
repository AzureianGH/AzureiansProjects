/*using System.Security.AccessControl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Sys = Cosmos.System;
using System.Runtime.InteropServices;
using Cosmos.System.Graphics;
using Cosmos.System.FileSystem;
using System.Drawing;
using Cosmos.System.Network;
using Python.Runtime;

//Add install.cs to the project
namespace AzureOS
{ 
    public class Kernel : Sys.Kernel
    {
        CosmosVFS AzuriFS;
        string current_directory = "0:\\";
        protected Canvas canvas;
        protected override void BeforeRun()
        {   
            
            //Make object of install
            
            
            AzuriFS = new CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(AzuriFS);
            Console.WriteLine("Azure OS: VERSION 1.2");
            Console.WriteLine("Setting Up RunTime environment...");
            Console.WriteLine("Testing File System...");
            try
            {
                var available_space = AzuriFS.GetAvailableFreeSpace(@"0:\");
                Console.WriteLine("Available Free Space: " + available_space);
            }
            catch(Exception ex)
            {
                Console.WriteLine("File System Unavalible...");
                Console.WriteLine(ex.ToString());
            }
            Console.WriteLine("File System Operational.");

        }

        protected override void Run()
        { 
            try
            {
                
                var fs_type = AzuriFS.GetFileSystemType(@"0:\");
                install Installer = new install();
                try
                {
                    if(Directory.Exists(@"0:\System"))
                    {

                    }
                    Directory.Exists(@"0:\Azure64");
                    Directory.Exists(@"0:\Users");
                }
                catch
                {
                    Console.WriteLine("Azure OS is not installed or is corrupted. Launching Installer...");
                    Installer.RunInstaller();
                }
                
                //Command line starts
                Console.WriteLine("Azure OS: VERSION 1.2");
                Console.WriteLine("Type 'help' for a list of commands.");
                while(true)
                {
                    Console.Write(current_directory + ">");
                    string command = Console.ReadLine();

                    if(command == "fs") {
                        Console.WriteLine("File System: Azuri File System 2.0");
                    }
                    else if(command == "ls") {
                        string[] files = Directory.GetFiles(current_directory);
                        string[] dirs = new string[files.Length];
                        foreach(string file in files) {
                            Console.WriteLine(file);
                        }
                        foreach(string dir in dirs)
                        {
                            Console.WriteLine(dir);
                        }
                    }
                    else if(command == "fs -type") {
                        Console.WriteLine("File System Type: " + fs_type);
                    }
                    else if(command.StartsWith("fs -newfile")) {
                        // Command looks like this: fs -newfile <file_name> <file_extension>
                        string[] command_parts = command.Split(' ');
                        string file_name = command_parts[2];
                        string file_extension = command_parts[3];
                        File.Create(current_directory + file_name + "." + file_extension);
                    }
                    else if(command == "code")
                    {
                        //Clear screen
                        Console.Clear();
                    }
                    else if(command == "python")
                    {
                        dynamic pythonCode = "print('Hello, Python!')";
                        PythonEngine.Initialize();
                        PythonEngine.RunSimpleString(pythonCode);
                        PythonEngine.Shutdown();

   
                    }
                    else if(command == "shutdown")
                    {
                        Stop();  
                    }
                    else if (command == "cat")
                    {
                        //Command looks like this: cat <file_name> <file_extension>
                        string[] command_parts = command.Split(' ');
                        string file_name = command_parts[1];
                        string file_extension = command_parts[2];
                        string file_path = current_directory + file_name + "." + file_extension;
                        string file_contents = File.ReadAllText(file_path);
                        Console.WriteLine(file_contents);
                    }
         
            }
            }
            catch (Exception e)
            {
                mDebugger.Send("Exception occurred: " + e.Message);
                mDebugger.Send(e.Message);
                Stop();
            }   
        }
    }
}*/