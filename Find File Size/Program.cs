namespace Find_File_Size
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //make longlong typedof
            Type longlong = typeof(long);
            //the first arg is the folder to search for file sizes
            // for each subfolder, and folders in them, it will take all the file sizes and add them up and write them out as it goes

            string folder = args[0];
            long size = 0;
            foreach (string subfolder in Directory.GetDirectories(folder))
            {
                
                foreach (string file in Directory.GetFiles(subfolder))
                {
                    FileInfo fi = new FileInfo(file);
                    size += fi.Length;
                }
                //write size and add prefix (KB, MB, GB, TB) to the end
                Console.Write("\r" + size + " " + GetPrefix(size));
            }
        }
        static string GetPrefix(long size)
        {
            if (size < 1024)
            {
                return "B";
            }
            else if (size < 1024 * 1024)
            {
                return "KB";
            }
            else if (size < 1024 * 1024 * 1024)
            {
                return "MB";
            }
            else
            {
                return "GB";
            }
        }
    }
}