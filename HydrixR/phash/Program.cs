using System;
using System.Security.Cryptography;
using System.Text;

namespace phash
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2 && args[0] != "--version")
            {
                Console.WriteLine("Usage: phash -hash <password>");
                return;
            }

            if (args[0] == "--version")
            {
                Console.WriteLine("AzuriTools phash 0.0.1");
                Console.WriteLine("Copyright (C) 2023 AzuriTools");
                Console.WriteLine("License phash License: V1");
                Console.WriteLine("This is free software: you are free to redistribute it but NOT modify it in any way.");
                Console.WriteLine("There is NO WARRANTY, to the extent permitted by law.");
            }
            else if (args[0] == "-hash")
            {
                string password = args[1];

                // Generate a random key (you can replace this with your own key generation logic)
                string key = GenerateRandomKey();

                // Combine the password and key
                string combined = password + key;

                // Hash the combined string using SHA256
                string hashedPassword = ComputeSHA256Hash(combined);

                Console.WriteLine("Password: " + password);
                Console.WriteLine("Key: " + key);
                Console.WriteLine("Hashed Password: " + hashedPassword);
            }
            else if (args[0] == "-verify")
            {
                string password = args[1];
                string key = args[2];
                string hashedPasswordStored = args[3];

                // Combine the provided password and key
                string combined = password + key;

                // Hash the combined string using SHA256
                string hashedPassword = ComputeSHA256Hash(combined);

                // Compare the computed hash with the stored hash
                if (hashedPassword == hashedPasswordStored)
                {
                    Console.WriteLine("Password is valid.");
                }
                else
                {
                    Console.WriteLine("Password is invalid.");
                }
            }
        }

        // Generates a random key (for demonstration purposes)
        static string GenerateRandomKey()
        {
            // You can replace this with your own key generation logic
            return Guid.NewGuid().ToString();
        }

        // Computes the SHA256 hash of a string
        static string ComputeSHA256Hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
