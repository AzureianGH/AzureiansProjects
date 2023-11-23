using System;
using System.Text;

class RandomStringGenerator
{
    static Random random = new Random();

    static void Main(string[] args)
    {
        int length = 10; // Change this to the desired length of the random string
        while (true)
        {
            string randomString = GenerateRandomString(length);
            Console.Write(randomString);
        }
        
    }

    static string GenerateRandomString(int length)
    {
        const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        StringBuilder builder = new StringBuilder(length);

        for (int i = 0; i < length; i++)
        {
            int index = random.Next(chars.Length);
            builder.Append(chars[index]);
        }

        return builder.ToString();
    }
}
