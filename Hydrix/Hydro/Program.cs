using System.Security.Cryptography;
using Hydro.CodeAnalysis;
namespace Hydro
{
    class Program
    {
        static void Main(string[] args)
        {
            bool showTree = false;
            Console.WriteLine("Hydro Compiler b9.23.23");
            while (true)
            {
                Console.Write(">>> ");
                var line = Console.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    return;
                }
                if (line == ":toggletree")
                {
                    showTree = !showTree;
                    Console.WriteLine(showTree ? "[Debug] Parse Trees Enabled" : "[Debug] Parse Trees Disabled");
                    continue;
                }
                else if (line == ":clear")
                {
                    Console.Clear();
                    continue;
                }
                else if (line == ":?" || line == ":help")
                {
                    Console.WriteLine(":? or :help - Shows this help message");
                    Console.WriteLine(":toggletree - Toggles Parse Tree Debugging");
                    Console.WriteLine(":clear - Clears the console");
                    continue;
                }
                var syntaxtree = SyntaxTree.Parse(line);

                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGray;
                if (showTree)
                { 
                    DetailedPrint(syntaxtree.Root);
                }
                Console.ForegroundColor = color;

                if (!syntaxtree.Diagnostics.Any())
                {
                    var e = new Evaluator(syntaxtree.Root);
                    var result = e.Evaluate();
                    Console.WriteLine(result);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    foreach (var diagnostic in syntaxtree.Diagnostics)
                    {
                        Console.WriteLine(diagnostic);
                    }
                    Console.ForegroundColor = color;
                }
            }
        }
        static void DetailedPrint(SyntaxNode node, string indent = "")
        {
            Console.Write(indent);
            Console.Write(node.Kind);

            if (node is SyntaxToken t && t.Value != null)
            {
                Console.Write(" ");
                Console.Write(t.Value);
            }
            Console.WriteLine();
            indent += "    ";

            foreach (var child in node.GetChildren())
            {
                DetailedPrint(child, indent);
            }
        }
    }
    
}