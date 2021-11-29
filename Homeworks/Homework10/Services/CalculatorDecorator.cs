
namespace Homework10.Services
{
    public abstract class CalculatorDecorator: ICalculator
    {
        protected readonly ICalculator Calculator;

        protected CalculatorDecorator(ICalculator calculator)
        {
            Calculator = calculator;
        }
        public virtual decimal Calculate(string expression)
        {
           return Calculator.Calculate(expression);
        }
    }
}