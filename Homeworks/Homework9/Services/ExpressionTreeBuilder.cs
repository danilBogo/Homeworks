using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Homework9.Services
{
    public static class ExpressionTreeBuilder
    {
        private static readonly Dictionary<string, int> OperatorPrecedence = new()
        {
            { "+", 0 }, { "-", 0 }, { "*", 1 }, { "/", 1 }
        };

        public static Expression BuildExpression(string expression)
        {
            var output = new Stack<Expression>();
            var operators = new Stack<Token>();
            foreach (var token in GetTokens(expression))
            {
                if (token.TokenType == TokenType.Number)
                    output.Push(Expression.Constant(decimal.Parse(token.Value)));
                else if (token.TokenType == TokenType.Operation)
                {
                    while (operators.TryPop(out var upper))
                        if (upper.TokenType != TokenType.OpenBracket
                            && PrecedenceOf(token.Value) <= PrecedenceOf(upper.Value))
                            ApplyOperator(output, upper.Value);
                        else
                        {
                            operators.Push(upper);
                            break;
                        }

                    operators.Push(token);
                }
                else if (token.TokenType == TokenType.OpenBracket)
                    operators.Push(token);
                else if (token.TokenType == TokenType.CloseBracket)
                {
                    while (operators.TryPop(out var upper) && upper.TokenType != TokenType.OpenBracket)
                        ApplyOperator(output, upper.Value);
                }
            }

            while (operators.Count > 0)
                ApplyOperator(output, operators.Pop().Value);

            return output.Pop();
        }

        private static void ApplyOperator(Stack<Expression> output, string operation)
        {
            var right = output.Pop();
            var left = output.Pop();
            output.Push(CreateBinaryExpression(operation, left, right));
        }

        private static int PrecedenceOf(string op)
        {
            return OperatorPrecedence[op];
        }

        private static Expression CreateBinaryExpression(string operation, Expression left, Expression right)
        {
            return operation switch
            {
                "+" => Expression.Add(left, right),
                "-" => Expression.Subtract(left, right),
                "*" => Expression.Multiply(left, right),
                "/" => Expression.Divide(left, right),
                _ => throw new InvalidOperationException($"Operation '{operation}' is not supported")
            };
        }
        private static readonly List<char> Operations = new() { '+', '-', '/', '*' };
        private static bool IsOperation(char symbol) => Operations.Contains(symbol);

        private static IEnumerable<Token> GetTokens(string expression)
        {
            var i = 0;
            while (i < expression.Length)
            {
                Token token;
                var symbol = expression[i];
                if (char.IsNumber(symbol))
                    token = GetNumberToken(expression, i);

                else if (symbol == '(')
                    token = new Token("(", TokenType.OpenBracket);

                else if (symbol == ')')
                    token = new Token(")", TokenType.CloseBracket);

                else if (IsOperation(symbol))
                    token = new Token(symbol.ToString(), TokenType.Operation);
                else
                    throw new ArgumentException($"Invalid expression: {expression}");
                i += token.Value.Length;
                yield return token;
            }
        }

        private static Token GetNumberToken(string expression, int position)
        {
            var length = 0;
            while (position + ++length < expression.Length && char.IsDigit(expression, position + length));
            return new Token(expression.Substring(position, length), TokenType.Number);
        }
    }
}