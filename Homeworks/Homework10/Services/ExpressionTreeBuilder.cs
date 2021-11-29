using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace Homework10.Services
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
            foreach (var token in Tokenizer.Tokenize(expression))
            {
                if (token.TokenType == TokenType.Number)
                    output.Push(Expression.Constant(decimal.Parse(token.Value)));
                else if (token.TokenType == TokenType.Operation)
                {
                    while (operators.TryPop(out var upper))
                        if (upper.TokenType != TokenType.LeftParenthesis
                            && PrecedenceOf(token.Value) <= PrecedenceOf(upper.Value))
                            ApplyOperator(output, upper.Value);
                        else
                        {
                            operators.Push(upper);
                            break;
                        }

                    operators.Push(token);
                }
                else if (token.TokenType == TokenType.LeftParenthesis)
                    operators.Push(token);
                else if (token.TokenType == TokenType.RightParenthesis)
                {
                    while (operators.TryPop(out var upper) && upper.TokenType != TokenType.LeftParenthesis)
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
    }
}