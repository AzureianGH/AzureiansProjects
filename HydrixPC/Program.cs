using System;
using System.IO;
using Newtonsoft.Json;
namespace HydrixPC
{
    internal class Program
    {
        //variables for check
        static bool projectsFolderExists = false;
        static bool projectsJsonExists = false;
        static bool projectsJsonEmpty = false;
        static void Main(string[] args)
        {
            //
        }
        static void Init()
        {
            Console.Write("Checking for projects/   ||  ... ");
            //in projects/ folder, check for projects.json
            if (Directory.Exists("projects"))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\rChecking for projects/   ||  OK\n");
                Console.ForegroundColor = ConsoleColor.White;
                projectsFolderExists = true;
                Console.Write("Checking for projects.json   ||  ... ");
                if (File.Exists("projects/projects.json"))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\rChecking for projects.json   ||  OK\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    projectsJsonExists = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\rChecking for projects.json   ||  FAIL\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\rChecking for projects/   ||  FAIL\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            if (!projectsFolderExists)
            {
                Console.Write("Creating projects/   ||  ... ");
                Directory.CreateDirectory("projects");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\rCreating projects/   ||  OK\n");
                Console.ForegroundColor = ConsoleColor.White;
                projectsFolderExists = true;
            }
            if (!projectsJsonExists)
            {
                //create projects.json
                Console.Write("Creating projects.json   ||  ... ");
                File.Create("projects/projects.json");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\rCreating projects.json   ||  OK\n");
                Console.ForegroundColor = ConsoleColor.White;
                projectsJsonExists = true;
                //for each folder inside of projects/, check for .project file, if there is one, add it to projects.json with command name as key and path as value
                Console.Write("Checking for projects in projects/   ||  ... ");
                string[] dirs = Directory.GetDirectories("projects");
                //if dirs is empty, fail the check
                if (dirs.Length > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\rChecking for projects in projects/   ||  OK\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\rChecking for projects in projects/   ||  FAIL\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
        public struct ProgramFile
        {
            public string cn;
            public string path;
            public ProgramFile(string commandname, string path)
            {
                this.cn = commandname;
                this.path = path;
            }
        }
        public ProgramFile GetFileContent(string dir)
        {
            //open the project file
            StreamReader sr = new StreamReader(dir);
            //read the file
            string file = sr.ReadToEnd();
            //close the file
            sr.Close();
            //first line is the command name
            string commandname = file.Split('\n')[0];
            //return path of file and command name
            return new ProgramFile(commandname, dir);
        }
    }
}