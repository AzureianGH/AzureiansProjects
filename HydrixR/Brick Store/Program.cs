using System;
using System.Threading;
using System.Collections.Generic;
class Program
{
    public static async Task Main(string[] args)
    {
        string arg1 = args[0];
        if (arg1 == "-f")
        {
            string filepath = args[1];
            int bricklength = Convert.ToInt32(args[2]);
            char divider = Convert.ToChar(args[3]);
            string outputfilepath = args[4];

            byte[] filebytes = System.IO.File.ReadAllBytes(filepath);
            // Create a Task to perform the bricking asynchronously
            var brickingTask = Task.Run(() => Bricker.Brick(filebytes, bricklength, divider));

            // Print a loading animation while bricking
            while (!brickingTask.IsCompleted)
            {
                BrickState();
                await Task.Delay(200);
                Console.Clear();
            }

            // Once bricking is done, write the bricked file
            System.IO.File.WriteAllBytes(outputfilepath, brickingTask.Result);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Done! Wrote :{brickingTask.Result.Length}: Bytes to :{outputfilepath}:");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    public static void BrickState()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("|___|");
        Console.WriteLine("Bricking.");
        Thread.Sleep(200);
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("  |___|");
        Console.WriteLine("Bricking..");
        Thread.Sleep(200);
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("    |___|");
        Console.WriteLine("Bricking...");
        Thread.Sleep(200);
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("      |___|");
        Console.WriteLine("Bricking.");
        Thread.Sleep(200);
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("|___| |___|");
        Console.WriteLine("Bricking..");
        Thread.Sleep(200);
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("    |___|");
        Console.WriteLine("      |___|");
        Console.WriteLine("Bricking...");
        Thread.Sleep(200);
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("      |___|");
        Console.WriteLine("      |___|");
        Console.WriteLine("Bricking.");
        Thread.Sleep(200);
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("    |___|");
        Console.WriteLine("      |___|");
        Console.WriteLine("Bricking..");
        Thread.Sleep(200);
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("|___| |___|");
        Console.WriteLine("Bricking...");
        Thread.Sleep(200);
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("      |___|");
        Console.WriteLine("Bricking.");
        Thread.Sleep(200);
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("    |___|");
        Console.WriteLine("Bricking..");
        Thread.Sleep(200);
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("  |___|");
        Console.WriteLine("Bricking...");
        Thread.Sleep(200);
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("|___|");
        Console.WriteLine("Bricking.");
        Thread.Sleep(200);
        Console.Clear();
    }
}
public static class Bricker
{
    public static byte[] Brick(byte[] filebytes, int bricklength, char divider)
    {
        List<byte> bytelist = new List<byte>();
        for (int j = 0; j < filebytes.Length; j++) // Change <= to < here
        {
            if (j % bricklength == 0)
            {
                bytelist.Add(Convert.ToByte(divider));
                
            }
            bytelist.Add(filebytes[j]);
        }
        return bytelist.ToArray();
    }
}