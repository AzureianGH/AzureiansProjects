namespace Hydro
{
    public class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
    public class Lexer
    {
        private int current_token_index = 0;
        public void Lex(string input)
        {
            
        }
        public Token Next(string tokens)
        {

        }
    }
    public class Token
    {
        public TokenType Type { get; set; }
        public required string Value { get; set; }
        public int Line { get; set; }
        public int Column { get; set; }
    }
    public enum TokenType
    {
        Identifier,
        Number,
        String,
        Operator,
        Keyword,
        Punctuation,
        Comment,
        Whitespace,
        Unknown
    }
}