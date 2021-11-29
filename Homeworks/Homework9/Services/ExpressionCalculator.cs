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
            var buildedExpression = ExpressionTreeBuilder.BuildExpression(expression);
            return Visit(buildedExpression) is ConstantExpression constantExpression
                ? (decimal)constantExpression.Value : 
                throw new ArgumentException($"Invalid expression: {expression}");
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            var leftNodeTask = Task.Run(() => (decimal)((ConstantExpression)Visit(node.Left)).Value);
            var rightNodeTask = Task.Run(() => (decimal)((ConstantExpression)Visit(node.Right)).Value);
            Thread.Sleep(1000);
            Task.WhenAll(leftNodeTask, rightNodeTask);
            var leftNode = leftNodeTask.Result;
            var rightNode = rightNodeTask.Result;

            return node.NodeType switch
            {
                ExpressionType.Add => Expression.Constant(leftNode + rightNode, typeof(decimal)),
                ExpressionType.Subtract => Expression.Constant(leftNode - rightNode, typeof(decimal)),
                ExpressionType.Multiply => Expression.Constant(leftNode * rightNode, typeof(decimal)),
                ExpressionType.Divide => Expression.Constant(leftNode / rightNode, typeof(decimal))
            };
        }
    }
}