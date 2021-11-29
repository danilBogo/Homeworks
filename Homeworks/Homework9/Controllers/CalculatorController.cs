using System;
using System.Globalization;
using System.Threading.Tasks;
using Homework9.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Homework9.Controllers
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