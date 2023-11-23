using System.Diagnostics;
using System.Runtime.InteropServices;
namespace ProgramWatcher
{
    internal class Program
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        static void Main(string[] args)
        {
            //check if argument is passed
            if (args.Length == 0)
            {
                var watcher = new Watcher("msedge");
                watcher.Watch();
            }
            //if argument is -s
            else if (args[0] == "-s")
            {
                //hide console window
                var handle = GetConsoleWindow();
                ShowWindow(handle, SW_HIDE);
                var watcher = new Watcher("msedge");
                watcher.Watch();
            }
            else if (args[0] == "-p")
            {
                //get second argument as process name
                var processName = args[1];
                var watcher = new Watcher(processName);
                watcher.Watch();
            }
            
        }
        public class Watcher
        {
            public string ProcessName = "msedge";
            public Watcher(string processName)
            {
                ProcessName = processName;
            }
            public void Watch()
            {
                while (true)
                {
                    var processes = Process.GetProcessesByName(ProcessName);
                    foreach (var process in processes)
                    {
                        process.Kill();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"\rKilled {process.ProcessName}");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Thread.Sleep(500);    
                    Console.Write("\rWatching...                                      ");
                }
            }
        }
    }
}