using System;
using System.Diagnostics;
namespace APM
{
    public class AzuriPackageMgr
    {
        static void Main(string[] args)
        {

            if (args != null)
            {
                if (args[0] == "-ch")
                {
                    //foreach argument, if it does not start with -, add it to the string
                    string packages = "";
                    int numberOfArgs = 0;
                    foreach (string arg in args)
                    {
                        if (!arg.StartsWith("-"))
                        {
                            packages += arg + " ";
                            numberOfArgs++;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Arg: {0} has been disregarded.", arg);
                        }
                    }
                    //start choco first with args feature enable -n allowGlobalConfirmation
                    Process processs = new Process();
                    processs.StartInfo.FileName = "choco\\choco.exe";
                    processs.StartInfo.Arguments = "feature enable -n allowGlobalConfirmation";
                    processs.StartInfo.UseShellExecute = false;
                    processs.Start();
                    processs.WaitForExit();

                    //start a new process in choco\choco.exe with install as the first arg and the second arg is the args[1]
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Azuri Package Manager (APM) V1.3.4");
                    Console.WriteLine("Powered by Chocolatey > Choco");
                    Console.ForegroundColor = ConsoleColor.White;
                    Process process = new Process();
                    process.StartInfo.FileName = "choco\\choco.exe";
                    process.StartInfo.Arguments = "install " + packages;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Azuri Package Manager is installing {0}.", packages);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    process.Start();
                    //error 
                    
                    while (process.StandardOutput.EndOfStream != true)
                    {
                        Console.WriteLine(process.StandardOutput.ReadLine());
                        //if the line contains a number or char surrounded by [] then redirect all input to the process
                        if (process.StandardOutput.ReadLine() != null)
                        {
                            //if one line has 'already' in it, write 0 installed, 0 upgraded, 0 removed, 0 failed
                            if (process.StandardOutput.ReadLine().Contains("already"))
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("0 Installed, 0 Upgraded, 0 Removed, 0 Failed");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            if (process.StandardOutput.ReadLine().Contains("["))
                            {
                                //allow user to input
                                Console.WriteLine(process.StandardOutput.ReadLine());
                                process.StandardInput.WriteLine(Console.ReadLine());

                            }
                            
                        }
                    }
                        string error = process.StandardError.ReadToEnd();
                        sw.Stop();
                    //if there is an error, print it

                    if (error != "")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Azuri Package Manager failed in {0}.", sw.Elapsed);
                        Console.WriteLine("0 Installed, 0 Upgraded, 0 Removed," + numberOfArgs.ToString() + "Failed");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Azuri Package Manager finished in {0}.", sw.Elapsed);
                        Console.WriteLine(numberOfArgs.ToString() + " Installed, 0 Upgraded, 0 Removed, 0 Failed");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                
                }
                    else { return; }
                }
            

            
        }
    }
}