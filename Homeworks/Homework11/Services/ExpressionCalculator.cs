namespace Homework11.Services
{
    public class ExpressionCalculator : ICalculator
    {
        private readonly MyExpressionVisitor visitor = new();

        public decimal Calculate(string expression)
        {
            return visitor.Visit((dynamic)ExpressionTreeBuilder.BuildExpression(expression));
        }
    }
}