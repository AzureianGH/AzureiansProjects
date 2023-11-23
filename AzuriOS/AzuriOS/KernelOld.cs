/*using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.System.FileSystem;
using System.IO;
using System.Threading;
using IronPython;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using AzuriOS.SystemUtils;

namespace AzuriOS
{


    public class Kernel : Sys.Kernel
    {
        
        public string calltrace = "Start of call trace: \n";
        //File system
        Sys.FileSystem.CosmosVFS azfs = new Sys.FileSystem.CosmosVFS();

        protected override void BeforeRun()

        {
            //Write print("Hello, world") to hello.py
            File.WriteAllText(@"0:\Testing\hello.py", "print(\"Hello, world\")");
            calltrace += "ran create vfs\n";
            //Register virtual file system
            Console.WriteLine("Initializing file system...");
            calltrace += "ran system stdout\n";
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(azfs);
            calltrace += "ran register vfs\n";
            Console.WriteLine("File system initialized!");
            calltrace += "ran system stdout\n";
            Console.WriteLine("Running file checks...");
            calltrace += "ran system stdout\n";
            if (Directory.Exists(@"0:\Testing") == false)
            {
                calltrace += "ran if result: false\n";
                Directory.CreateDirectory(@"0:\Testing");
                calltrace += "ran create directory\n";
            }
            if (Directory.Exists(@"0:\Azure64") == false)
            {
                calltrace += "ran if result: false\n";
                Directory.CreateDirectory(@"0:\Azure64");
                calltrace += "ran create directory\n";
            }
        }

        protected override void Run()
        {
            Console.Write("\\> ");
            calltrace += "ran system stdout\n";
            var input = Console.ReadLine();
            calltrace += "ran system stdin on variable: " + input + "\n";

            if (input == "option")
            {
                Selection selection = new Selection();
                selection.AddOption("Option 1");
                selection.AddOption("Option 2");
                selection.AddOption("Option 3");
                selection.AddOption("Option 4");

                string select = selection.GetSelection(true);
                calltrace += "ran selection\n";
                Console.WriteLine(select);
                calltrace += "ran system stdout\n";

            }
            else if (input == "editor")
            {
                CodeEditor editor = new CodeEditor();
                editor.Run();
            }
            else
            {
                calltrace += "ran if result: " + input + "\n";
                HandleError("Not a valid command", 4);
                calltrace += "ran handle error event unsigned\n";
            }
            
        }
        /// <summary>
        /// 0 = Warning (Small, Ignorable)
        /// 1 = Error (Small, Ignorable)
        /// 2 = Error (Large, Start Damage Control)
        /// 3 = Error (Critical, Unmanagable, Start Panic)
        /// Else = Error (Unsigned no severity)
        /// </summary>
        /// <param name="error"></param>
        /// <param name="severity"></param>
        public void HandleError(string error, int severity)
        {
            if (severity == 0)
            {
                calltrace += "ran if result: " + severity + "\n";
                Console.WriteLine("Warning: " + error);
                calltrace += "ran system stdout\n";
            }
            else if (severity == 1)
            {
                calltrace += "ran if result: " + severity + "\n";
                Console.WriteLine("Error: " + error);
                calltrace += "ran system stdout\n";
            }
            else if (severity == 2)
            {
                calltrace += "ran if result: " + severity + "\n";
                Console.WriteLine("Severe Error: " + error);
                calltrace += "ran system stdout\n";
            }
            else if (severity == 3)
            {
                calltrace += "ran if result: " + severity + "\n";
                InitiateKernalPanic(error);
                calltrace += "initiated kernel panic\n";
            }
            else
            {
                calltrace += "ran if result: " + severity + "\n";
                Console.WriteLine("Unsigned Error: " + error);
                calltrace += "ran system stdout\n";
            }   
        }
        /// <summary>
        /// Starts a kernel panic
        /// </summary>
        /// <param name="error"></param>
        private void InitiateKernalPanic(string error)
        {
            calltrace += "End of call trace\n";
            Console.Clear();
            logging("Halting system...", @"0:\Azure64\kernal.log");
            logging("Kernel panic initiated!", @"0:\Azure64\kernal.log");
            
            //Get current time
            DateTime now = DateTime.Now;
            logging("Time: " + now, @"0:\Azure64\kernal.log");
            logging("Error: " + error, @"0:\Azure64\kernal.log");
            //call trace
            logging("Call Trace: " + calltrace, @"0:\Azure64\kernal.log");

            logging("End Kernel Panic", @"0:\Azure64\kernal.log");
            //say log saved to azure64\kernal.log
            logging("Log saved to Azure64\\kernal.log", @"0:\Azure64\kernal.log");
            logging("Press any key to restart...", @"0:\Azure64\kernal.log");
            //sleep for 5 seconds
            Console.ReadKey();
            //restart
            Sys.Power.Reboot();
        }
        /// <summary>
        /// Prints to console and writes to file
        /// </summary>
        /// <param name="toWriteandPrint"></param>
        /// <param name="filepath"></param>
        public void logging(string toWriteandPrint, string filepath)
        {
            //print toWriteandPrint and write to filepath
            Console.WriteLine(toWriteandPrint);
            //append to file
            File.AppendAllText(filepath, toWriteandPrint);
        }
    }
}*/