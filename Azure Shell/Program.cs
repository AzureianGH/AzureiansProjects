using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Security.Principal;
using System.Diagnostics;
using System.Drawing;

namespace AzureShell
{
    class Program
    {
        [DllImport("Kernel32")]
        public static extern bool SetConsoleCtrlHandler(ConsoleCtrlHandlerDelegate handler, bool add);
        static bool debuggingmode = false;
        static bool isadmin = false;
        static bool firstrun = false;
        static string? user;
        public delegate bool ConsoleCtrlHandlerDelegate(int signal);
        static string? dir;
        public static bool nouni = false;
        public static string input = "";
        public static Process? currentprocess;
        public static string dire;
        public static ConsoleColor foregroundc = ConsoleColor.White;
        public static string azureshellfile = "";
        static void ExecuteExternalExecutable(string executable, string arguments)
        {
            currentprocess = new Process();
            currentprocess.StartInfo.FileName = "cmd.exe"; // Use cmd.exe as the executable
            currentprocess.StartInfo.Arguments = "/C " + executable + " " + arguments; // Pass the command as arguments
            currentprocess.StartInfo.UseShellExecute = false;
            currentprocess.StartInfo.RedirectStandardInput = true;
            currentprocess.StartInfo.RedirectStandardOutput = true;
            currentprocess.StartInfo.CreateNoWindow = true;

            currentprocess.OutputDataReceived += (sender, e) => Console.WriteLine(e.Data); // Output event handler

            currentprocess.Start();

            currentprocess.BeginOutputReadLine(); // Start reading output asynchronously

            // Read user input and pass it to cmd.exe
            while (true)
            {
                string input = Console.ReadLine();

                if (input == null)
                {
                    currentprocess.Kill();
                    Console.WriteLine("Process terminated.");
                    break;
                }
                if (input.ToLower() == "exit")
                {
                    currentprocess.CloseMainWindow(); // Close cmd.exe when the user types "exit"
                    Console.WriteLine("Process closed.");
                    break;
                }
                currentprocess.StandardInput.WriteLine(input);
            }
        }
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
        static bool ConsoleCtrlHandler(int signal)
        {
            if (signal == 0)  // Ctrl+C event
            {
                if (currentprocess != null)
                { 
                    currentprocess.Kill();
                }
                return true;  // Return true to indicate that you've handled the event
            }
            return false;  // Return false for other events
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
        public static bool IsAdministrator()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        public static void Startup()
        {
            //check for a .azureshell file in the current user's home directory
            string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string azureshell = home + "\\.azureshell";

            if (File.Exists(azureshell))
            {
                azureshellfile = azureshell;
                string[] lines = File.ReadAllLines(azureshell);
                foreach (string line in lines)
                {
                    if (line.StartsWith("debug"))
                    {
                        string[] split = line.Split("=");
                        if (split[1] == "True")
                        {
                            debuggingmode = true;
                        }
                    }
                    if (line.StartsWith("nouni"))
                    {
                        string[] split = line.Split("=");
                        if (split[1] == "True")
                        {
                            nouni = true;
                        }
                    }
                    //console color
                    if (line.StartsWith("foregroundcolor"))
                    {
                        string[] split = line.Split("=");
                        if (split[1] == "0")
                        {
                            foregroundc = ConsoleColor.White;
                        }
                        //if the number is 1, set the color to blue
                        else if (split[1] == "1")
                        {
                            foregroundc = ConsoleColor.DarkBlue;
                        }
                        //if the number is 2, set the color to cyan
                        else if (split[1] == "2")
                        {

                            foregroundc = ConsoleColor.DarkGreen;
                        }
                        //if the number is 3, set the color to dark blue
                        else if (split[1] == "3")
                        {

                            foregroundc = ConsoleColor.DarkCyan;
                        }
                        //if the number is 4, set the color to dark cyan
                        else if (split[1] == "4")
                        {

                            foregroundc = ConsoleColor.DarkRed;
                        }
                        //if the number is 5, set the color to dark gray
                        else if (split[1] == "5")
                        {

                            foregroundc = ConsoleColor.DarkMagenta;
                        }
                        //if the number is 6, set the color to dark green
                        else if (split[1] == "6")
                        {

                            foregroundc = ConsoleColor.DarkYellow;
                        }
                        //if the number is 7, set the color to dark magenta
                        else if (split[1] == "7")
                        {

                            foregroundc = ConsoleColor.Gray;
                        }
                        //if the number is 8, set the color to dark red
                        else if (split[1] == "8")
                        {

                            foregroundc = ConsoleColor.DarkGray;
                        }
                        //if the number is 9, set the color to dark yellow
                        else if (split[1] == "9")
                        {
                            foregroundc = ConsoleColor.Blue;
                        }
                        //if the number is 10, set the color to gray
                        else if (split[1] == "10")
                        {

                            foregroundc = ConsoleColor.Green;
                        }
                        //if the number is 11, set the color to green
                        else if (split[1] == "11")
                        {
                            foregroundc = ConsoleColor.Cyan;

                        }
                        //if the number is 12, set the color to magenta
                        else if (split[1] == "12")
                        {
                            foregroundc = ConsoleColor.Red;
                        }
                        //if the number is 13, set the color to red
                        else if (split[1] == "13")
                        {
                            foregroundc = ConsoleColor.Magenta;
                        }
                        //if the number is 14, set the color to white
                        else if (split[1] == "14")
                        {
                            foregroundc = ConsoleColor.Yellow;
                        }
                        //if the number is 15, set the color to yellow
                        else if (split[1] == "15")
                        {
                            foregroundc = ConsoleColor.White;
                        }
                    }   
                }
            }
            else
            {
                File.WriteAllText(azureshell, "foregroundcolor=0\ndebug=false\nnouni=false");
                azureshellfile = azureshell;
            }
            Console.Clear();
        }
    static void Main(string[] args)
        {
            Startup();
            SetConsoleCtrlHandler(new ConsoleCtrlHandlerDelegate(ConsoleCtrlHandler), true);
            user = Environment.UserName;
            
            Console.WriteLine("Azure Shell Version 0.5.7 (c) Azureian 2023\n");

            dir = Directory.GetCurrentDirectory();
            string inputBuffer = "";
            bool isContinuingCommand = false;
            
            while (true)
            {
                if (isContinuingCommand == false)
                {
                    firstrun = true;
                    if (!isadmin)
                    {
                        if (nouni == false)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("\n┌─");
                        }
                    }
                    else
                    {
                        if (nouni == false)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\n┌─");
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
                            Console.Write("└─");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("└─");
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
                        Console.Write("└─> ");
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
                //saveconf
                Console.WriteLine("saveconf - saves the configuration");
                //apm
                Console.WriteLine("apm install <packages> - Azure Package Manager");
            }
            else if (input == "root")
            {
                if (isadmin)
                {
                    SendError("\nUser already root!");
                }
                else
                {
                    if (IsAdministrator())
                    {
                        isadmin = true;
                        user = "root";
                    }
                    else
                    {
                        SendError("\nInsufficient permissions -> Unable to root.");
                    }
                }
            }
            else if (input == "unroot")
            {

                if (isadmin)
                {
                    isadmin = false;
                    user = Environment.UserName;
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
            else if (input.StartsWith("saveconf"))
            {
                //write to the .azureshell file
                File.WriteAllText(azureshellfile, "foregroundcolor=" + (int)foregroundc + "\n" + "debug=" + debuggingmode + "\n" + "nouni=" + nouni);
                Console.WriteLine("\nSaved configuration.");
            }
            else if (input == "apm install" || input == "apm")
            {
                Console.WriteLine("Azuri Package Manager.");
            }
            else if (input.StartsWith("apm install"))
            {
                if (isadmin)
                {
                    // the args after apm install are the packages to install
                    string[] args = input.Split(' ');
                    //get the args after apm install
                    string argsa = input.Substring(11).Trim();
                    Process process = new Process();
                    //filename apm.exe, args. First one is -ch, second is the packages to install
                    process.StartInfo.FileName = "apm.exe";
                    process.StartInfo.Arguments = "-ch " + argsa;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.Start();
                    while (!process.HasExited)
                    {
                        //print output
                        Console.WriteLine(process.StandardOutput.ReadToEnd());
                    }
                }
                else
                {
                    SendError("\nYou need to be root to install packages.");
                }
            }
            else
            {
                //check if input starts with a valid filepath
                string imp = input.Split(' ')[0];
                // args are the rest after the first space
                string argsa = input.Substring(imp.Length).Trim();
                if (argsa.Length == 0)
                {
                    argsa = "";
                }
                if (File.Exists(imp))
                {
                    ExecuteExternalExecutable(input, argsa);
                }
                if (input.Length == 0)
                {
                    return;
                }
                else { SendError("\n'" + input + "' Is not a valid command."); }
                
            }
        }
    }
}
