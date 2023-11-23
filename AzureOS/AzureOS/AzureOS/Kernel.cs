using System.Security.AccessControl;
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


//Add install.cs to the project
namespace AzureOS
{ 
    public class Kernel : Sys.Kernel
    {
        CosmosVFS AzuriFS;
        string current_directory = "0:/";
        protected override void BeforeRun()
        {   
            
            //Make object of install
            
            
            AzuriFS = new CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(AzuriFS);
            Console.WriteLine("Azure OS: VERSION 1.2");
            Console.WriteLine("Setting Up RunTime environment...");

        }

        protected override void Run()
        { 
            try
            {
                
                var fs_type = AzuriFS.GetFileSystemType(@"0:/");
                
                
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
                    else if(command == "clear")
                    {
                        //Clear screen
                        Console.Clear();
                    }
                    else if(command == "help")
                    {
                        //List of commands
                        Console.WriteLine("Azure OS: VERSION 1.2");
                        Console.WriteLine("fs -type: Displays the file system type.");
                        Console.WriteLine("fs -newfile <file_name> <file_extension>: Creates a new file.");
                        Console.WriteLine("ls: Lists all files in the current directory.");
                        Console.WriteLine("clear: Clears the screen.");
                        Console.WriteLine("cat <file_name> <file_extension>: Displays the contents of a file.");
                        Console.WriteLine("shutdown: Shuts down the computer.");
                        Console.WriteLine("cd <directory>: Changes the current directory.");
                        Console.WriteLine("mkdir <directory_name>: Creates a new directory.");
                        Console.WriteLine("rmdir <directory_name>: Deletes a directory.");
                        Console.WriteLine("rm <file_name> <file_extension>: Deletes a file.");
                        Console.WriteLine("cp <file_name> <file_extension> <new_file_name> <new_file_extension>: Copies a file.");
                        Console.WriteLine("mv <file_name> <file_extension> <new_file_name> <new_file_extension>: Moves a file.");
                        Console.WriteLine("file <file_name> <file_extension>: Creates a new file.");
                        Console.WriteLine("write <file_name> <file_extension> <content> : Writes to a file.");
                        Console.WriteLine("read <file_name> <file_extension>: Reads a file.");


                    }
                    else if(command.StartsWith("cd"))
                    {
                        //Command looks like this: cd <directory>
                        string[] command_parts = command.Split(' ');
                        string directory = command_parts[1];
                        current_directory = current_directory + directory + "/";
                    }
                    else if(command.StartsWith("mkdir"))
                    {
                        //Command looks like this: mkdir <directory_name>
                        string[] command_parts = command.Split(' ');
                        string directory_name = command_parts[1];
                        Directory.CreateDirectory(current_directory + directory_name);
                    }
                    else if(command.StartsWith("rmdir"))
                    {
                        //Command looks like this: rmdir <directory_name>
                        string[] command_parts = command.Split(' ');
                        string directory_name = command_parts[1];
                        Directory.Delete(current_directory + directory_name);
                    }
                    else if(command.StartsWith("rm"))
                    {
                        //Command looks like this: rm <file_name> <file_extension>
                        string[] command_parts = command.Split(' ');
                        string file_name = command_parts[1];
                        string file_extension = command_parts[2];
                        File.Delete(current_directory + file_name + "." + file_extension);
                    }
                    else if(command.StartsWith("cp"))
                    {
                        //Command looks like this: cp <file_name> <file_extension> <new_file_name> <new_file_extension>
                        string[] command_parts = command.Split(' ');
                        string file_name = command_parts[1];
                        string file_extension = command_parts[2];
                        string new_file_name = command_parts[3];
                        string new_file_extension = command_parts[4];
                        File.Copy(current_directory + file_name + "." + file_extension, current_directory + new_file_name + "." + new_file_extension);
                    }
                    else if(command.StartsWith("mv"))
                    {
                        //Command looks like this: mv <file_name> <file_extension> <new_file_name> <new_file_extension>
                        string[] command_parts = command.Split(' ');
                        string file_name = command_parts[1];
                        string file_extension = command_parts[2];
                        string new_file_name = command_parts[3];
                        string new_file_extension = command_parts[4];
                        File.Move(current_directory + file_name + "." + file_extension, current_directory + new_file_name + "." + new_file_extension);
                    }
                    else if(command.StartsWith("file"))
                    {
                        //Command looks like this: file <file_name> <file_extension>
                        string[] command_parts = command.Split(' ');
                        string file_name = command_parts[1];
                        string file_extension = command_parts[2];
                        File.Create(current_directory + file_name + "." + file_extension);
                    }
                    else if (command.StartsWith("write"))
                    {
                        //Command looks like this: write <file_name> <file_extension> <content>
                        string[] command_parts = command.Split(' ');
                        string file_name = command_parts[1];
                        string file_extension = command_parts[2];
                        string content = command_parts[3];
                        File.WriteAllText(current_directory + file_name + "." + file_extension, content);
                    }
                    else if (command.StartsWith("read"))
                    {
                        //Command looks like this: read <file_name> <file_extension>
                        string[] command_parts = command.Split(' ');
                        string file_name = command_parts[1];
                        string file_extension = command_parts[2];
                        string file_contents = File.ReadAllText(current_directory + file_name + "." + file_extension);
                        Console.WriteLine(file_contents);
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
}