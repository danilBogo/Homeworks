using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Homework10.Services
{
    public static class ExpressionExtensions
    {
        public static string GetUrlWithPluses(this string url)
        {
            return url.Replace(" ", "+");
        }

        public static async Task<decimal> Evaluate(this Expression expression)
        {
            if (expression is ConstantExpression { Value: { } } constantExpression)
                return await Task.FromResult((decimal)constantExpression.Value);
            if (expression is not BinaryExpression node) return 0;
            var left = node.Left.Evaluate();
            var right = node.Right.Evaluate();
            Task.WaitAll(left, right);
            var leftValue = left.Result;
            var rightValue = right.Result;
            return node.NodeType switch
            {
                ExpressionType.Add => leftValue + rightValue,
                ExpressionType.Subtract => leftValue - rightValue,
                ExpressionType.Multiply => leftValue * rightValue,
                ExpressionType.Divide => leftValue / rightValue,
                _ => throw new
                    InvalidOperationException($"Operation: {node.Method} not supported")
            };
        }
    }
}