using System;
using System.Collections.Generic;

namespace Homework10.Services
{
    public static class Tokenizer
    {
        private static readonly List<char> Operations = new() { '+', '-', '/', '*' };
        private static bool IsOperation(char symbol) => Operations.Contains(symbol);
        public static IEnumerable<Token> Tokenize(string expression)
        {
            var i = 0;
            while (i < expression.Length)
            {
                Token token;
                var symbol = expression[i];
                if (char.IsNumber(symbol))
                    token = ReadNumber(expression, i);

                else if (symbol == '(')
                    token = new Token("(", TokenType.LeftParenthesis);

                else if (symbol == ')')
                    token = new Token(")", TokenType.RightParenthesis);

                else if (IsOperation(symbol))
                    token = new Token(symbol.ToString(), TokenType.Operation);
                else
                    throw new ArgumentException($"Invalid expression: {expression}");
                i += token.Value.Length;
                yield return token;
            }
        }

        private static Token ReadNumber(string expression, int position)
        {
            var length = 0;
            while (position + ++length < expression.Length && char.IsDigit(expression, position + length));
            return new Token(expression.Substring(position, length), TokenType.Number);
        }
    }
}