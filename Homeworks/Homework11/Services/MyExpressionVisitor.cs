using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Homework11.Services
{
    public class MyExpressionVisitor
    {
        public decimal Visit(BinaryExpression node)
        {
            var leftNodeTask = Task.Run(() => Visit((dynamic)node.Left));
            var rightNodeTask = Task.Run(() => Visit((dynamic)node.Right));
            Thread.Sleep(1000);
            Task.WhenAll(leftNodeTask, rightNodeTask);
            var leftNode = leftNodeTask.Result;
            var rightNode = rightNodeTask.Result;
            return node.NodeType switch
            {
                ExpressionType.Add => leftNode + rightNode,
                ExpressionType.Subtract => leftNode - rightNode,
                ExpressionType.Multiply => leftNode * rightNode,
                ExpressionType.Divide => leftNode / rightNode,
                _ => throw new InvalidOperationException($"unsupported opperation - {node}")
            };
        }

        public decimal Visit(ConstantExpression constantExpression)
        {
            return constantExpression.Value is decimal value
                ? value
                : throw new InvalidCastException($"can`t cast {constantExpression.Value} to decimal");
        }
    }
}