using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public enum TokenType
{
    // Define your token types here, including the new data types
    Identifier,
    IntegerLiteral,
    FloatLiteral,
    StringLiteral,
    Plus,
    Minus,
    Multiply,
    Divide,
    // New data types
    String,
    Float,
    Char,
    Bool,
    Int,
    UInt,
    UFloat,
    Double,
    EOF,
    // ... and so on
}

public class Token
{
    public TokenType Type { get; }
    public string Lexeme { get; }
    public int Line { get; }
    public int Column { get; }

    public Token(TokenType type, string lexeme, int line, int column)
    {
        Type = type;
        Lexeme = lexeme;
        Line = line;
        Column = column;
    }
}

public class Lexer
{
    private readonly string sourceCode;
    private int position;
    private int line;
    private int column;

    private static readonly Dictionary<TokenType, string> tokenPatterns = new Dictionary<TokenType, string>
    {
        // Regular expressions for each token type, including the new data types
        { TokenType.Identifier, @"[a-zA-Z_][a-zA-Z0-9_]*" },
        { TokenType.IntegerLiteral, @"\d+" },
        { TokenType.FloatLiteral, @"\d+(\.\d+)?" }, // Updated pattern for float literals
        { TokenType.StringLiteral, @"""(?:\\.|[^""])*""" },
        { TokenType.Plus, @"\+" },
        { TokenType.Minus, @"-" },
        { TokenType.Multiply, @"\*" },
        { TokenType.Divide, @"/" },
        // New data type patterns
        { TokenType.String, @"\bstring\b" },
        { TokenType.Float, @"\bfloat\b" },
        { TokenType.Char, @"\bchar\b" },
        { TokenType.Bool, @"\bbool\b" },
        { TokenType.Int, @"\bint\b" },
        { TokenType.UInt, @"\buint\b" },
        { TokenType.UFloat, @"\bufloat\b" },
        { TokenType.Double, @"\bdouble\b" },
        // ... and so on
    };

    public Lexer(string sourceCode)
    {
        this.sourceCode = sourceCode;
        this.position = 0;
        this.line = 1;
        this.column = 1;
    }

    private char Peek()
    {
        if (position >= sourceCode.Length)
            return '\0';
        return sourceCode[position];
    }

    private char Advance()
    {
        char currentChar = Peek();
        position++;
        column++;
        if (currentChar == '\n')
        {
            line++;
            column = 1;
        }
        return currentChar;
    }

    private bool Match(char expected)
    {
        if (Peek() == expected)
        {
            Advance();
            return true;
        }
        return false;
    }

    public Token NextToken()
    {
        // Implement the lexing process here
        while (position < sourceCode.Length)
        {
            // Check for each token type using regular expressions
            foreach (var entry in tokenPatterns)
            {
                var tokenType = entry.Key;
                var pattern = entry.Value;
                var match = Regex.Match(sourceCode.Substring(position), "^" + pattern);

                if (match.Success)
                {
                    var lexeme = match.Value;
                    var token = new Token(tokenType, lexeme, line, column);
                    Advance(match.Length);
                    return token;
                }
            }

            // If no token pattern matched, raise an error or skip the unrecognized character
            // based on your error-handling strategy.
            // For simplicity, we'll just skip the character here.
            Advance();
        }

        // Return an EOF token when the end of the source code is reached.
        return new Token(TokenType.EOF, "", line, column);
    }

    private void Advance(int steps)
    {
        for (int i = 0; i < steps; i++)
            Advance();
    }
}

// Example usage:
class Program
{
    static void Main()
    {
        string zefroinCode = @"string name = ""John"";
            float pi = 3.14;
            int age = 30;
            bool isValid = true;
            ufloat someValue = 1.5;
            char initial = 'J';
            double precision = 0.001;
            return 0;";


        Lexer lexer = new Lexer(zefroinCode);
        Token token;
        do
        {
            token = lexer.NextToken();
            Console.WriteLine($"Token: {token.Type}, Lexeme: '{token.Lexeme}', Line: {token.Line}, Column: {token.Column}");
        } while (token.Type != TokenType.EOF);
    }
}
