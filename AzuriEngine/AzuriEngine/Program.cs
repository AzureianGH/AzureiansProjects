using System.Runtime.InteropServices;

public partial class Program
{

    static void Main()
    {
        string dirpath = "C:\\Users\\alexm\\source\\repos\\AzuriEngine\\AzuriEngine\\assets";
        Metadata metadata = new Metadata();
        metadata.MakeMetaDataFiles(dirpath);
        Console.WriteLine("Made Metadata Files");
    }
}
