using System;
using System.Text;

class Program
{
    static void Main()
    {
        string input = "int myVar;\nostream <- (char[])\n{\n\"Hello, world!\"\n}";
        string nasmCode = GenerateNASMCode(input);
        Console.WriteLine(nasmCode);
    }

    static string GenerateNASMCode(string input)
    {
        // Split the input into lines
        string[] lines = input.Split('\n');

        // Initialize a StringBuilder to build the NASM code
        var nasmCode = new StringBuilder();

        bool inStringBlock = false;

        foreach (string line in lines)
        {
            if (line.StartsWith("int"))
            {
                // Declare an integer variable
                string variableName = line.Split(' ')[1].TrimEnd(';');
                nasmCode.AppendLine($"section .data");
                nasmCode.AppendLine($"{variableName} dd 0");
            }
            else if (line.StartsWith("ostream <- (char[])"))
            {
                // Output a string
                inStringBlock = true;
                nasmCode.AppendLine($"section .data");
                nasmCode.AppendLine("output db ");
            }
            else if (inStringBlock)
            {
                // Append the content line by line
                if (line == "}")
                {
                    // End of string block
                    inStringBlock = false;
                    nasmCode.AppendLine(", 0");
                    nasmCode.AppendLine($"section .text");
                    nasmCode.AppendLine($"global _start");
                    nasmCode.AppendLine("_start:");
                    nasmCode.AppendLine("mov eax, 4");
                    nasmCode.AppendLine("mov ebx, 1");
                    nasmCode.AppendLine($"mov ecx, output");
                    nasmCode.AppendLine("mov edx, $ - output");
                    nasmCode.AppendLine("int 0x80");
                    nasmCode.AppendLine("mov eax, 1");
                    nasmCode.AppendLine("int 0x80");
                }
                else if (line.StartsWith("\""))
                {
                    // Handle lines inside double quotes
                    nasmCode.Append(line.Trim());
                }
                else
                {
                    // Handle lines outside double quotes (e.g., opening brace)
                    nasmCode.Append($"\"{line.Trim()}\", ");
                }
            }
        }

        return nasmCode.ToString();
    }
}
