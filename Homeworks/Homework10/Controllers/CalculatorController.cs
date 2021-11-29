using System.Globalization;
using Homework10.Services;
using Microsoft.AspNetCore.Mvc;

namespace Homework10.Controllers
{
    public class CalculatorController
    {
        private readonly ICalculator calculator;
        public CalculatorController(ICalculator calculator)
        {
            this.calculator = calculator;
        }
        [HttpGet]
        public string Calculate(string expression)
        {
            return calculator.Calculate(expression.GetUrlWithPluses()).ToString(CultureInfo.InvariantCulture);
        }
    }
}