using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
//using streamreader and writer
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;

namespace AzuriEngine.Internal
{
    public class Metadata
    {

        public void WriteToMetaHolder(string pathtofile, string metadatafilepath)
        {
            //Write to the .m.hold file in MainDir\AzuriEngine\DataHandler\Meta\metas.m.hold
            using (StreamWriter writer = new StreamWriter(pathtofile))
            {
                //Get the metadatafilepath
                writer.WriteLine(metadatafilepath);
                writer.Close();
            }
            Console.WriteLine("Wrote to MetaHolder");
        }
        public void MakeMetaDataFile(string path)
        {
            //Take path of file and make a meta data file for it
            if (File.Exists(path))
            {
                bool hasStart = false;
                bool hasUpdateFrame = false;
                bool hasFixedUpdate = false;
                bool hasLateUpdate = false;
                //Get file name
                string fileName = Path.GetFileName(path);
                string metaDataFilePath = path + ".data";

                //Open the path file and read it to see if it has any of the following: Start, UpdateFrame, FixedUpdate, LateUpdate
                //If it has any of those, write it to the meta data file
                using (StreamReader reader = new(path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Contains("Start("))
                        {
                            hasStart = true;
                        }
                        if (line.Contains("UpdateFrame("))
                        {
                            hasUpdateFrame = true;
                        }
                        if (line.Contains("FixedUpdate("))
                        {
                            hasFixedUpdate = true;
                        }
                        if (line.Contains("LateUpdate("))
                        {
                            hasLateUpdate = true;
                        }
                    }
                }

                //Write to meta data file
                //Wait 2
                Thread.Sleep(1000);

                using (StreamWriter writer = new StreamWriter(metaDataFilePath))
                {
                    writer.WriteLine("Type: Script (C#)");
                    writer.WriteLine("Name: " + fileName);
                    writer.WriteLine("Location: " + path);
                    writer.WriteLine("Has Start: " + hasStart);
                    writer.WriteLine("Has UpdateFrame: " + hasUpdateFrame);
                    writer.WriteLine("Has FixedUpdate: " + hasFixedUpdate);
                    writer.WriteLine("Has LateUpdate: " + hasLateUpdate);

                    ArrayList callables = new ArrayList();
                    if (hasStart)
                    {
                        callables.Add("Start");
                    }
                    if (hasUpdateFrame)
                    {
                        callables.Add("UpdateFrame");
                    }
                    if (hasFixedUpdate)
                    {
                        callables.Add("FixedUpdate");
                    }
                    if (hasLateUpdate)
                    {
                        callables.Add("LateUpdate");
                    }
                    //Write callables like this: Callables: Start, UpdateFrame, FixedUpdate, LateUpdate (only if they have them)
                    writer.Write("Callables: ");
                    if (hasStart)
                    {
                        writer.Write("Start");
                    }
                    if (hasUpdateFrame)
                    {
                        if (hasStart)
                        {
                            writer.Write(", ");
                        }
                        writer.Write("UpdateFrame");
                    }
                    if (hasFixedUpdate)
                    {
                        if (hasStart || hasUpdateFrame)
                        {
                            writer.Write(", ");
                        }
                        writer.Write("FixedUpdate");
                    }
                    if (hasLateUpdate)
                    {
                        if (hasStart || hasUpdateFrame || hasFixedUpdate)
                        {
                            writer.Write(", ");
                        }
                        writer.Write("LateUpdate");
                    }

                    writer.Close();
                }
            }
        }
        public void MakeMetaDataFiles(string dir)
        {
            //Find all CS files in the project as a list
            string[] files = Directory.GetFiles(dir, "*.cs", SearchOption.AllDirectories);
            //Make a meta data file for each one
            foreach (string file in files)
            {
                MakeMetaDataFile(file);
            }
        }
    }
}