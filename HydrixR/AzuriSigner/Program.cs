namespace AzuriSigner
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (args[0] == "--version") 
            {
                Console.WriteLine("Azuri Signer 2023 V.0.0.0.X");
                Console.WriteLine("Copyright (c) 2023");
                Console.WriteLine("All rights reserved.");
            }
            else if (args[0] == "-sign")
            {
                string filepath1 = args[1];
                string finalsign = "";
                Console.WriteLine("Signing " + filepath1 + "...");
                finalsign = Sign(filepath1);
                //open file and write the sign at a new line at the bottom
                File.AppendAllText(filepath1, Environment.NewLine + "AZURISIGN[" + finalsign);
                Console.WriteLine("Signed " + filepath1 + " with sign " + finalsign);
            }
        }
        public static string Sign(string path)
        {
            //File 1
            string filepath1 = path;
            int finalsign = 0;
            string sign = "";
            //open file
            string file1 = File.ReadAllText(filepath1);
            //foreach each char and add 1 if it is a letter, add 2 if it is a number, subtract 1 if it is a symbol
            
            foreach (char c in file1)
            {
                if (char.IsLetter(c))
                {
                    finalsign += 1;
                }
                else if (char.IsNumber(c))
                {
                    finalsign += 2;
                }
                else
                {
                    finalsign -= 1;
                }
            }
            //then convert the number to a string
            string finalsignstr = finalsign.ToString();
            return finalsignstr;
        }
    }
}