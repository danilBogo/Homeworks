using Homework10.Models;


namespace Homework10.Services
{
    public class CacheCalculator : CalculatorDecorator
    {
        private readonly ExpressionCacheService expressionCacheService;

        public CacheCalculator(ICalculator calculator, ExpressionCacheService expressionCacheService) : base(calculator)
        {
            this.expressionCacheService = expressionCacheService;
        }

        public override decimal Calculate(string expression)
        {
            var cachedExpression = expressionCacheService.Get(expression);
            if (cachedExpression != null)
                return cachedExpression.Result;
            var result = Calculator.Calculate(expression);
            expressionCacheService.Add(new CalculatorExpression() { Input = expression, Result = result });
            return result;
        }
    }
}