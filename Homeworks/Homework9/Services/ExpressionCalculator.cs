using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Homework9.Services
{
    public class ExpressionCalculator : ExpressionVisitor, ICalculator
    {
        public decimal Calculate(string expression)
        {
            Thread.Sleep(1000);
            var buildedExpression = ExpressionTreeBuilder.BuildExpression(expression.GetUrlWithPluses());
            return Visit(buildedExpression) is ConstantExpression constantExpression
                ? (decimal) constantExpression.Value
                : throw new Exception($"Invalid expression: {expression}");
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            var left = Task.Run(() => node.Left.Evaluate()) ;
            var right = Task.Run(()=> node.Right.Evaluate());
            Task.WaitAll(left, right);
            var leftValue = left.Result;
            var rightValue = right.Result;
            return node.NodeType switch
            {
                ExpressionType.Add => Expression.Constant(leftValue + rightValue),
                ExpressionType.Subtract => Expression.Constant(leftValue - rightValue),
                ExpressionType.Multiply => Expression.Constant(leftValue * rightValue),
                ExpressionType.Divide => Expression.Constant(leftValue / rightValue),
                _ => throw new
                    InvalidOperationException($"Operation: {node.Method} not supported")
            };
        }
    }
}