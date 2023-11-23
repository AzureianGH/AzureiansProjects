using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.System.Graphics;
using IL2CPU.API.Attribs;
using Cosmos.System.FileSystem;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using HydrixOS.GUI.String;
using System.Threading;

namespace HydrixOS
{

    public class Kernel : Sys.Kernel
    {
        [ManifestResourceStream(ResourceName = "HydrixOS.Images.OSBG1.bmp")]
        static byte[] bg1;
        

        static public bool isgraphicsmode = false;
        static bool debuggingmode = false;
        static bool isadmin = false;
        static bool firstrun = false;
        static string? user;
        public delegate bool ConsoleCtrlHandlerDelegate(int signal);
        static string? dir;
        public static bool nouni = false;
        public static string input = "";
        public static string dire;
        public static ConsoleColor foregroundc = ConsoleColor.White;
        //create a timer to store how long the system has been running
        static Stopwatch timer = new();
        CosmosVFS azurefs = new();
        static public void SendDebug(string message)
        {
            if (debuggingmode == false)
            {
                return;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[DEBUG] " + message);
            Console.ForegroundColor = foregroundc;
        }
        static public void SendError(string message)
        {
            if (!nouni)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                Console.ForegroundColor = foregroundc;
            }
            else
            {
                Console.WriteLine(message);
            }
        }
        protected override void BeforeRun()
        {
            //set the timer to 0
            timer.Start();
            //register the azurefs
            try
            {
                Sys.FileSystem.VFS.VFSManager.RegisterVFS(azurefs);
            }
            catch (Exception e)
            {
                //Kernel Panic
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[{timer.ElapsedMilliseconds}] Kernel Panic -> Unable to Sync VFS\n[{timer.ElapsedMilliseconds}] Call Trace:");
                Console.WriteLine("[{timer.ElapsedMilliseconds}] " + e.ToString());
                Console.WriteLine($"\n\n[{timer.ElapsedMilliseconds}] Press any key to shut down.");
                Console.ReadKey();
                Stop();
            }
        }

        protected override void Run()
        {
           

            
            //set current directory to 0:\ for now
            Directory.SetCurrentDirectory(@"0:\");
            Console.WriteLine("Azure Shell Version 0.2.6 (c) Azureian 2023\n");
            user = "Hydrix";
            dir = Directory.GetCurrentDirectory();
            string inputBuffer = "";
            bool isContinuingCommand = false;
            Bitmap osbg = new(bg1);
            Image bgimage = osbg;
            while (true)
            {
               if (isgraphicsmode)
               {
                    Canvas canvas = FullScreenCanvas.GetFullScreenCanvas();
                    canvas.Mode = new Mode(1920, 1080, ColorDepth.ColorDepth32);
                    
                    while (true)
                    {
                        canvas.DrawImage(bgimage, 0, 0);
                        canvas.Display();
                    }
               }
                if (isContinuingCommand == false)
                {
                    firstrun = true;
                    if (!isadmin)
                    {
                        if (nouni == false)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("\n|-");
                        }
                    }
                    else
                    {
                        if (nouni == false)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\n|-");
                        }
                    }
                    if (!nouni)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("(AS@" + user + ") ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("[" + dir + "]");
                    }

                    if (!nouni)
                    {
                        if (!isadmin)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("|-");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("|-");
                        }
                    }
                    if (!nouni)
                    {
                        if (!isadmin)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("$");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("#");
                        }
                    }
                    Console.ForegroundColor = foregroundc;
                }
                if (isContinuingCommand)
                {
                    if (!nouni)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("-> ");
                        Console.ForegroundColor = foregroundc;
                    }
                    else
                    {
                        Console.ForegroundColor = foregroundc;
                        Console.Write("> ");
                    }
                }
                else
                {
                    Console.Write(" ");
                }
                if (!nouni)
                {
                    input = Console.ReadLine();
                }
                else
                {
                    Console.ForegroundColor = foregroundc;
                    Console.Write(user + "@" + dir + " $");
                    input = Console.ReadLine();
                }
                if (input == null)
                {
                    input = "echo";
                }
                string secinp = input.TrimEnd();
                if (secinp.EndsWith("|") && firstrun == true)
                {
                    input += "|";
                    firstrun = false;
                }
                if (isContinuingCommand)
                {
                    inputBuffer += input + Environment.NewLine;
                    if (!input.EndsWith("|"))
                    {
                        input = inputBuffer.Trim();
                        inputBuffer = "";
                        isContinuingCommand = false;
                    }
                    else
                    {
                        continue;
                    }
                }

                if (input.EndsWith("|"))
                {
                    isContinuingCommand = true;
                    inputBuffer = input.Substring(0, input.Length - 1);
                    continue;
                }
                SendDebug(input);

                string[] commands = input.Split('|');  // Split input into individual commands
                foreach (string command in commands)
                {
                    ProcessInputLine(command.Trim());  // Process each individual command
                }
            }
            
            
        }
        static void ProcessInputLine(string input)
        {

            // Process your input commands here
            if (input == "exit")
            {
                Environment.Exit(0);
            }
            if (input == "graphic")
            {
                isgraphicsmode = true;
            }
            else if (input == "echo")
            {
                Console.WriteLine("");
            }
            else if (input.StartsWith("echo "))
            {
                Console.WriteLine("\n" + input.Substring(5));
            }
            else if (input == "help")
            {
                Console.WriteLine("\nCommands:");
                Console.WriteLine("echo - prints out the text after it");
                Console.WriteLine("exit - exits the shell");
                Console.WriteLine("help - prints out this message");
                Console.WriteLine("cd - changes the current directory");
                Console.WriteLine("ls - lists the files in the current directory");
                Console.WriteLine("clear - clears the screen");
                Console.WriteLine("root - makes the user root");
                Console.WriteLine("unroot - makes the user not root");
                Console.WriteLine("console.color - changes the color of the console");
                Console.WriteLine("console.debug - toggles debug mode");
                Console.WriteLine("console.simple - toggles the user interface to be non-graphical");
                Console.WriteLine("console.regular - toggles the user interface to be graphical");
            }
            else if (input == "root")
            {
                if (isadmin)
                {
                    SendError("\nUser already root!");
                }
                else
                {
                    isadmin = true;
                    user = "root";
                }
            }
            else if (input == "unroot")
            {

                if (isadmin)
                {
                    isadmin = false;
                    user = "Hydrix";
                }
                else
                {
                    SendError("\nUser is not root!");
                }
            }
            else if (input.StartsWith("cd"))
            {
                // Change directory
                string[] args = input.Split(' ');
                if (args.Length == 1)
                {
                    Console.WriteLine(Directory.GetCurrentDirectory());
                }
                else
                {

                    foreach (string arg in args)
                    {
                        if (arg != "cd")
                        {
                            dire = arg;
                            break;
                        }
                    }

                    if (dire == "..")
                    {
                        Directory.SetCurrentDirectory(Directory.GetParent(Directory.GetCurrentDirectory()).FullName);
                        dir = Directory.GetCurrentDirectory();
                    }
                    else
                    {
                        dire = dire.Replace('"', ' ');
                        dire = dire.Trim();
                        if (Directory.Exists(dire))
                        {
                            Directory.SetCurrentDirectory(dire);
                            dir = Directory.GetCurrentDirectory();
                        }
                        else
                        {
                            SendError("\nDirectory does not exist!");
                        }
                    }
                }
            }
            else if (input.StartsWith("ls"))
            {
                // List files and directories.
                // Folders will end with \
                string[] args = input.Split(' ');
                if (args.Length == 1)
                {
                    string outfile = "";
                    string[] files = Directory.GetFiles(Directory.GetCurrentDirectory());
                    string[] dirs = Directory.GetDirectories(Directory.GetCurrentDirectory());
                    foreach (string file in files)
                    {
                        outfile += Path.GetFileName(file);
                        outfile += "  ";
                    }
                    foreach (string dira in dirs)
                    {
                        outfile += Path.GetFileName(dira);
                        outfile += "  ";
                    }
                    Console.WriteLine(outfile);
                }
                else
                {
                    string dire = args[1];
                    string outfile = "";
                    if (dire == "..")
                    {
                        dire = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
                        string[] files = Directory.GetFiles(dire);
                        string[] dirs = Directory.GetDirectories(dire);

                        foreach (string file in files)
                        {
                            outfile += Path.GetFileName(file);
                            outfile += "  ";
                        }
                        foreach (string dira in dirs)
                        {
                            outfile += Path.GetFileName(dira);
                            outfile += "  ";
                        }
                        Console.WriteLine(outfile);
                    }
                    else if (dire == "--version")
                    {
                        Console.WriteLine("ls - Remake by Azureian.");
                        Console.WriteLine("Version 1.0.0");
                    }
                    else
                    {
                        string[] files = Directory.GetFiles(dire);
                        string[] dirs = Directory.GetDirectories(dire);
                        foreach (string file in files)
                        {
                            outfile += Path.GetFileName(file);
                            outfile += "  ";
                        }
                        foreach (string dira in dirs)
                        {
                            outfile += Path.GetFileName(dira);
                            outfile += "  ";
                        }
                        Console.WriteLine(outfile);
                    }
                }
            }
            else if (input.StartsWith("clear"))
            {
                //clear the console
                Console.Clear();
            }
            else if (input.StartsWith("console.simple"))
            {
                nouni = true;
                Console.Clear();
            }
            else if (input.StartsWith("console.regular"))
            {
                nouni = false;
                Console.Clear();
            }
            else if (input.StartsWith("console.color"))
            {
                //get the number after the space
                string[] args = input.Split(' ');
                //if the number of args is only console.color, print all the colors
                if (args.Length == 1)
                {
                    Console.WriteLine("0 = Default (White)");
                    Console.WriteLine("1 = Blue");
                    Console.WriteLine("2 = Green");
                    Console.WriteLine("3 = Cyan");
                    Console.WriteLine("4 = Red");
                    Console.WriteLine("5 = Magenta");
                    Console.WriteLine("6 = Yellow");
                    Console.WriteLine("7 = Gray");
                    Console.WriteLine("8 = Dark Gray");
                    Console.WriteLine("9 = Light Blue");
                    Console.WriteLine("10 = Light Green");
                    Console.WriteLine("11 = Light Cyan");
                    Console.WriteLine("12 = Light Red");
                    Console.WriteLine("13 = Light Magenta");
                    Console.WriteLine("14 = Light Yellow");
                    Console.WriteLine("15 = White");

                    Console.WriteLine("Current color: " + foregroundc);
                }
                //if the number is 0, set the color to black
                if (args[1] == "0")
                {
                    foregroundc = ConsoleColor.White;
                }
                //if the number is 1, set the color to blue
                else if (args[1] == "1")
                {
                    foregroundc = ConsoleColor.DarkBlue;
                }
                //if the number is 2, set the color to cyan
                else if (args[1] == "2")
                {

                    foregroundc = ConsoleColor.DarkGreen;
                }
                //if the number is 3, set the color to dark blue
                else if (args[1] == "3")
                {

                    foregroundc = ConsoleColor.DarkCyan;
                }
                //if the number is 4, set the color to dark cyan
                else if (args[1] == "4")
                {

                    foregroundc = ConsoleColor.DarkRed;
                }
                //if the number is 5, set the color to dark gray
                else if (args[1] == "5")
                {

                    foregroundc = ConsoleColor.DarkMagenta;
                }
                //if the number is 6, set the color to dark green
                else if (args[1] == "6")
                {

                    foregroundc = ConsoleColor.DarkYellow;
                }
                //if the number is 7, set the color to dark magenta
                else if (args[1] == "7")
                {

                    foregroundc = ConsoleColor.Gray;
                }
                //if the number is 8, set the color to dark red
                else if (args[1] == "8")
                {

                    foregroundc = ConsoleColor.DarkGray;
                }
                //if the number is 9, set the color to dark yellow
                else if (args[1] == "9")
                {
                    foregroundc = ConsoleColor.Blue;
                }
                //if the number is 10, set the color to gray
                else if (args[1] == "10")
                {

                    foregroundc = ConsoleColor.Green;
                }
                //if the number is 11, set the color to green
                else if (args[1] == "11")
                {
                    foregroundc = ConsoleColor.Cyan;

                }
                //if the number is 12, set the color to magenta
                else if (args[1] == "12")
                {
                    foregroundc = ConsoleColor.Red;
                }
                //if the number is 13, set the color to red
                else if (args[1] == "13")
                {
                    foregroundc = ConsoleColor.Magenta;
                }
                //if the number is 14, set the color to white
                else if (args[1] == "14")
                {
                    foregroundc = ConsoleColor.Yellow;
                }
                //if the number is 15, set the color to yellow
                else if (args[1] == "15")
                {
                    foregroundc = ConsoleColor.White;
                }
                else
                {
                    SendError("\n'" + args[1] + "' Is not a valid color.");
                }
            }
            else if (input.StartsWith("console.debug"))
            {
                //toggle debugging mode
                if (debuggingmode == true)
                {
                    debuggingmode = false;
                    Console.WriteLine("\nDebugging mode disabled.");
                }
                else
                {
                    debuggingmode = true;
                    Console.WriteLine("\nDebugging mode enabled.");
                }
            }
            else if (input.StartsWith("console"))
            {
                Console.WriteLine("\nConsole is a class.");
            }
            else
            {
                SendError("\n'" + input + "' Is not a valid command.");
            }
        }
    }
}
