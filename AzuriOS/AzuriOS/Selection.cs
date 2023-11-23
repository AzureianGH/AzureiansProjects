using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using IronPython.Runtime.Exceptions;
using System.Diagnostics.Tracing;

namespace AzuriOS.SystemUtils
{
    /// <summary>
    /// Class that handles choice selection in console.
    /// 
    ///Example:
    /// [1] Option 1,
    /// [2] Option 2,
    /// [3] Option 3,
    /// [4] Option 4,
    /// /End Example.
    /// You use your arrow keys to select the option you want. Enter to select.
    /// </summary>
    public class Selection
    {
        public List<string> options = new List<string>();
        public void AddOption(string option)
        {
            options.Add(option);
        }
        public void RemoveOption(string option)
        {
            options.Remove(option);
        }
        public void ChangeOrder(string option, int index)
        {
            options.Remove(option);
            options.Insert(index, option);
        }
        public void ClearOptions()
        {
            options.Clear();
        }
        /// <summary>
        /// Remember that the selection starts at 0. So your first option is 0, second is 1, etc.
        /// </summary>
        /// <returns></returns>
        public int GetSelection()
        {
            //Using arrow keys to select option.
            int index = 0;
            while (true)
            {
                Console.Clear();
                for (int i = 0; i < options.Count; i++)
                {
                    if (i == index)
                    {
                        Console.Write(">");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                    Console.WriteLine(options[i]);
                }
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    index--;
                    if (index == -1)
                    {
                        index = options.Count - 1;
                    }
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    index++;
                    if (index == options.Count)
                    {
                        index = 0;
                    }
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    return index;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stringoutput"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string GetSelection(bool stringoutput)
        {
            if (stringoutput) 
            {
                //Using arrow keys to select option.
                int index = 0;
                while (true)
                {
                    Console.Clear();
                    for (int i = 0; i < options.Count; i++)
                    {
                        if (i == index)
                        {
                            Console.Write("> ");
                            Console.BackgroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                        Console.WriteLine(options[i]);
                    }
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        index--;
                        if (index == -1)
                        {
                            index = options.Count - 1;
                        }
                    }
                    else if (key.Key == ConsoleKey.DownArrow)
                    {
                        index++;
                        if (index == options.Count)
                        {
                            index = 0;
                        }
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        return options[index];
                    }
                }
            }
            else
            {
                throw new Exception("I don't know how the HELL you managed to get this error, but you must set the stringoutput to true to use this method.");
            }
        }
    }
    public class CodeEditor
    {
        private StringBuilder textBuffer;
        private int cursorX;
        private int cursorY;
        private string currentFileName;

        public CodeEditor()
        {
            textBuffer = new StringBuilder();
            cursorX = 0;
            cursorY = 0;
            currentFileName = null;
        }

        public void Run()
        {
            Console.CursorVisible = false;

            while (true)
            {
                DisplayTextBuffer();

                // Check for keyboard input
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    MoveCursorLeft();
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    MoveCursorRight();
                }
                else if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    MoveCursorUp();
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    MoveCursorDown();
                }
                else if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    Backspace();
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    NewLine();
                }
                else if (keyInfo.Modifiers == ConsoleModifiers.Control && keyInfo.Key == ConsoleKey.S)
                {
                    SaveFile();
                }
                else if (keyInfo.Modifiers == ConsoleModifiers.Control && keyInfo.Key == ConsoleKey.O)
                {
                    OpenFile();
                }
                else
                {
                    // Normal typing
                    TypeCharacter(keyInfo.KeyChar);
                }
            }
        }

        private void DisplayTextBuffer()
        {
            Console.Clear();
            Console.WriteLine(textBuffer.ToString());
            Console.SetCursorPosition(cursorX, cursorY);
            DrawCursor();
            DrawBottomBar();
        }

        private void DrawCursor()
        {
            Console.SetCursorPosition(cursorX, cursorY);
            Console.CursorVisible = true;
        }

        private void DrawBottomBar()
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.Write("Current File: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(currentFileName ?? "New File");
            Console.ResetColor();
            Console.Write("   |   ");
            Console.Write("Press Ctrl + S to save, Ctrl + O to open");
        }

        private void MoveCursorLeft()
        {
            if (cursorX > 0)
            {
                cursorX--;
            }
        }

        private void MoveCursorRight()
        {
            if (cursorX < textBuffer.Length)
            {
                cursorX++;
            }
        }

        private void MoveCursorUp()
        {
            if (cursorY > 0)
            {
                cursorY--;
            }
        }

        private void MoveCursorDown()
        {
            if (cursorY < Console.WindowHeight - 2) // -2 to account for the bottom bar
            {
                cursorY++;
            }
        }

        private void Backspace()
        {
            if (cursorX > 0)
            {
                textBuffer.Remove(cursorX - 1, 1);
                cursorX--;
            }
            else if (cursorY > 0)
            {
                cursorY--;
                cursorX = textBuffer.Length - 1;
                textBuffer.Remove(textBuffer.Length - 1, 1);
            }
        }

        private void NewLine()
        {
            textBuffer.Insert(cursorX, Environment.NewLine);
            cursorX = 0;
            cursorY++;
        }

        private void TypeCharacter(char c)
        {
            textBuffer.Insert(cursorX, c);
            cursorX++;
        }

        private void SaveFile()
        {
            if (currentFileName == null)
            {
                SaveCurrentFileAs();
            }
            else
            {
                try
                {
                    File.WriteAllText(currentFileName, textBuffer.ToString());
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("Error: Access to the file is denied. Please check file permissions.");
                }
                catch (IOException)
                {
                    Console.WriteLine("Error: Unable to save the file. Please check the file path and try again.");
                }
            }
        }

        private void SaveCurrentFileAs()
        {
            Console.Write("Enter file name to save: ");
            string fileName = Console.ReadLine();

            if (!fileName.Contains("."))
            {
                Console.WriteLine("Error: File must have an extension.");
                return;
            }

            try
            {
                File.WriteAllText(fileName, textBuffer.ToString());
                currentFileName = fileName;
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Error: Access to the file is denied. Please check file permissions.");
            }
            catch (IOException)
            {
                Console.WriteLine("Error: Unable to save the file. Please check the file path and try again.");
            }
        }

        private void OpenFile()
        {
            Console.Write("Enter file name to open: ");
            string fileName = Console.ReadLine();
            if (File.Exists(fileName))
            {
                textBuffer.Clear();
                textBuffer.Append(File.ReadAllText(fileName));
                currentFileName = fileName;
            }
            else
            {
                Console.WriteLine("Error: File not found.");
            }
        }
    }
}
