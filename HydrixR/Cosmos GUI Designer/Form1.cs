using System.Text.RegularExpressions;

namespace Cosmos_GUI_Designer
{
    public partial class Form1 : Form
    {
        public Panel cosmospanel;
        public Form1()
        {
            InitializeComponent();
            //call colorize 
            CodeColorizer.Colorize(richTextBox1, CodeColorizer.Codinglangs.CSharp);
            cosmospanel = canvasCosmos;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            CodeColorizer.Colorize(richTextBox1, CodeColorizer.Codinglangs.CSharp);
        }

        private void lightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThemeManager.SetTheme(ThemeManager.Themes.Light);
        }

        private void darkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThemeManager.SetTheme(ThemeManager.Themes.Dark);
        }
        public static class CodeColorizer
        {
            public static void Colorize(RichTextBox textbox, Codinglangs lang)
            {
                int currentPosition = textbox.SelectionStart;
                switch (lang)
                {
                    case Codinglangs.C:
                        ColorizeC(textbox);
                        break;
                    case Codinglangs.Cpp:
                        ColorizeCpp(textbox);
                        break;
                    case Codinglangs.CSharp:
                        ColorizeCSharp(textbox);
                        break;
                    default:
                        break;
                }
                textbox.SelectionStart = currentPosition;
                textbox.SelectionLength = 0;
            }
            private static void ColorizeC(RichTextBox textbox)
            {
                throw new NotImplementedException("Colorize C is not implemented yet, sorry.");
            }
            private static void ColorizeCpp(RichTextBox textbox)
            {
                throw new NotImplementedException("Colorize C++ is not implemented yet, sorry.");
            }
            private static void ColorizeCSharp(RichTextBox textbox)
            {
                //make a dictionary of custom keywords and their colors
                Dictionary<string, Color> keywordscustom = new Dictionary<string, Color>();
                //add Canvas as a dark green
                keywordscustom.Add("Canvas", Color.DarkGreen);

                int currentPosition = textbox.SelectionStart;
                //in the textbox, find all the keywords and color them blue
                textbox.SelectionStart = 0;
                textbox.SelectionLength = textbox.Text.Length;
                textbox.SelectionColor = Color.Black;

                string text = textbox.Text;
                string[] keywords = new string[] { "abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked", "class", "const", "continue",
        "decimal", "default", "delegate", "do", "double", "else", "enum", "event", "explicit", "extern", "false", "finally", "fixed", "float",
        "for", "foreach", "goto", "if", "implicit", "in", "int", "interface", "internal", "is", "lock", "long", "namespace", "new", "null",
        "object", "operator", "out", "override", "params", "private", "protected", "public", "readonly", "ref", "return", "sbyte", "sealed",
        "short", "sizeof", "stackalloc", "static", "string", "struct", "switch", "this", "throw", "true", "try", "typeof", "uint", "ulong",
        "unchecked", "unsafe", "ushort", "using", "virtual", "void", "volatile", "while" };

                foreach (string keyword in keywords)
                {
                    int index = 0;
                    while (index < text.Length)
                    {
                        index = text.IndexOf(keyword, index);
                        if (index == -1)
                        {
                            break;
                        }
                        if (index > 0 && char.IsLetterOrDigit(text[index - 1]))
                        {
                            // If there is a letter or digit before the keyword, skip coloring it.
                            index += keyword.Length;
                        }
                        else
                        {
                            textbox.SelectionStart = index;
                            textbox.SelectionLength = keyword.Length;
                            textbox.SelectionColor = Color.Blue;
                            index += keyword.Length;
                        }
                    }
                }
                //color strings green
                foreach (Match match in Regex.Matches(text, "\".*?\""))
                {
                    textbox.SelectionStart = match.Index;
                    textbox.SelectionLength = match.Length;
                    textbox.SelectionColor = Color.Green;
                }
                //color comments orange
                foreach (Match match in Regex.Matches(text, "//.*"))
                {
                    textbox.SelectionStart = match.Index;
                    textbox.SelectionLength = match.Length;
                    textbox.SelectionColor = Color.Orange;
                }
                //color numbers red
                foreach (Match match in Regex.Matches(text, @"\b[0-9]+\b"))
                {
                    int index = match.Index;
                    textbox.SelectionStart = index;
                    textbox.SelectionLength = match.Length;
                    textbox.SelectionColor = Color.Red;
                }
                //color operators purple
                foreach (Match match in Regex.Matches(text, "[+\\-*/=]"))
                {
                    textbox.SelectionStart = match.Index;
                    textbox.SelectionLength = match.Length;
                    textbox.SelectionColor = Color.Purple;
                }
                //color custom keywords
                foreach (KeyValuePair<string, Color> keyword in keywordscustom)
                {
                    //Check if the keyword is in the text, and make sure it's not part of another word
                    foreach (Match match in Regex.Matches(text, "\\b" + keyword.Key + "\\b"))
                    {
                        textbox.SelectionStart = match.Index;
                        textbox.SelectionLength = match.Length;
                        textbox.SelectionColor = keyword.Value;
                    }
                }
                //check if there is a . and then a word, and color the word blue, if it has () then color the () green
                foreach (Match match in Regex.Matches(text, "\\.[a-zA-Z0-9_]+"))
                {
                    textbox.SelectionStart = match.Index + 1;
                    textbox.SelectionLength = match.Length - 1;
                    textbox.SelectionColor = Color.FromArgb(41, 142, 142);
                }
                foreach (Match match in Regex.Matches(text, "\\.[a-zA-Z0-9_]+\\("))
                {
                    textbox.SelectionStart = match.Index + 1;
                    textbox.SelectionLength = match.Length - 2; // Subtract 2 to exclude the '('
                    textbox.SelectionColor = Color.Green;
                }
                //color () darkorchid
                foreach (Match match in Regex.Matches(text, "\\("))
                {
                    textbox.SelectionStart = match.Index;
                    textbox.SelectionLength = match.Length;
                    textbox.SelectionColor = Color.DarkOrchid;
                }
                foreach (Match match in Regex.Matches(text, "\\)"))
                {
                    textbox.SelectionStart = match.Index;
                    textbox.SelectionLength = match.Length;
                    textbox.SelectionColor = Color.DarkOrchid;
                }
                //color {} orangered
                foreach (Match match in Regex.Matches(text, "\\{"))
                {
                    textbox.SelectionStart = match.Index;
                    textbox.SelectionLength = match.Length;
                    textbox.SelectionColor = Color.OrangeRed;
                }
                foreach (Match match in Regex.Matches(text, "\\}"))
                {
                    textbox.SelectionStart = match.Index;
                    textbox.SelectionLength = match.Length;
                    textbox.SelectionColor = Color.OrangeRed;
                }
                //color [] darkpink
                foreach (Match match in Regex.Matches(text, "\\["))
                {
                    textbox.SelectionStart = match.Index;
                    textbox.SelectionLength = match.Length;
                    textbox.SelectionColor = Color.DarkSalmon;
                }
                foreach (Match match in Regex.Matches(text, "\\]"))
                {
                    textbox.SelectionStart = match.Index;
                    textbox.SelectionLength = match.Length;
                    textbox.SelectionColor = Color.DarkSalmon;
                }
                textbox.SelectionStart = currentPosition;
                textbox.SelectionLength = 0;
            }

            public enum Codinglangs
            {
                C,
                Cpp,
                CSharp
            }
        }
        public static class ThemeManager
        {
            public static void SetTheme(Themes theme)
            {
                switch (theme)
                {
                    case Themes.Light:
                        SetLightTheme();
                        break;
                    case Themes.Dark:
                        SetDarkTheme();
                        break;
                    default:
                        break;
                }
            }
            private static void SetLightTheme()
            {
                //set the background color of the form to white
                Form1.ActiveForm.BackColor = Color.White;
                //set the text color of the form to black
                Form1.ActiveForm.ForeColor = Color.Black;
                //set the background color of the textbox to white
                Form1.ActiveForm.Controls["richTextBox1"].BackColor = Color.White;
                //set the text color of the textbox to black
                Form1.ActiveForm.Controls["richTextBox1"].ForeColor = Color.Black;
            }
            private static void SetDarkTheme()
            {
                //set the background color of the form to black
                Form1.ActiveForm.BackColor = Color.Black;
                //set the text color of the form to white
                Form1.ActiveForm.ForeColor = Color.White;
                //set the background color of the textbox to black
                Form1.ActiveForm.Controls["richTextBox1"].BackColor = Color.Black;
                //set the text color of the textbox to white
                Form1.ActiveForm.Controls["richTextBox1"].ForeColor = Color.White;
                //set canvas to white

            }
            public enum Themes
            {
                Light,
                Dark
            }
        }
    }

}