using System;
using System.Collections.Generic;

namespace EnhancedTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lines = new List<string>();
            int currentLineIndex = 0;
            int cursorPosition = 0;
            bool isEditing = false;

            while (true)
            {
                Console.Clear();

                // Display the lines with line numbers
                for (int i = 0; i < lines.Count; i++)
                {
                    if (i == currentLineIndex)
                    {
                        Console.Write(">");
                    }
                    else
                    {
                        Console.Write(" ");
                    }

                    Console.WriteLine($"{i + 1}: {lines[i]}");
                }

                // Handle user input
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    currentLineIndex = Math.Max(0, currentLineIndex - 1);
                    cursorPosition = Math.Min(cursorPosition, lines[currentLineIndex].Length);
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    currentLineIndex = Math.Min(lines.Count - 1, currentLineIndex + 1);
                    cursorPosition = Math.Min(cursorPosition, lines[currentLineIndex].Length);
                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    cursorPosition = Math.Max(0, cursorPosition - 1);
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    cursorPosition = Math.Min(lines[currentLineIndex].Length, cursorPosition + 1);
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    string remainingText = lines[currentLineIndex].Substring(cursorPosition);
                    lines[currentLineIndex] = lines[currentLineIndex].Remove(cursorPosition);
                    lines.Insert(currentLineIndex + 1, remainingText);
                    currentLineIndex++;
                    cursorPosition = 0;
                }
                else if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (cursorPosition > 0)
                    {
                        lines[currentLineIndex] = lines[currentLineIndex].Remove(cursorPosition - 1, 1);
                        cursorPosition--;
                    }
                    else if (cursorPosition == 0 && lines[currentLineIndex].Length > 0)
                    {
                        lines[currentLineIndex - 1] += lines[currentLineIndex];
                        lines.RemoveAt(currentLineIndex);
                        currentLineIndex--;
                        cursorPosition = lines[currentLineIndex].Length;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.Delete)
                {
                    if (cursorPosition < lines[currentLineIndex].Length)
                    {
                        lines[currentLineIndex] = lines[currentLineIndex].Remove(cursorPosition, 1);
                    }
                    else if (cursorPosition == lines[currentLineIndex].Length && currentLineIndex < lines.Count - 1)
                    {
                        lines[currentLineIndex] += lines[currentLineIndex + 1];
                        lines.RemoveAt(currentLineIndex + 1);
                    }
                }
                else if (keyInfo.Key == ConsoleKey.Home)
                {
                    cursorPosition = 0;
                }
                else if (keyInfo.Key == ConsoleKey.End)
                {
                    cursorPosition = lines[currentLineIndex].Length;
                }
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    isEditing = !isEditing;
                }
                else if (isEditing)
                {
                    lines[currentLineIndex] = lines[currentLineIndex].Insert(cursorPosition, keyInfo.KeyChar.ToString());
                    cursorPosition++;
                }
            }
        }
    }
}
