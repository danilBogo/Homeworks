using System.Globalization;
using Homework8.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Homework8.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ILogger<CalculatorController> logger;
        private readonly ICalculator calculator;

        public CalculatorController(ILogger<CalculatorController> logger, ICalculator calculator)
        {
            this.logger = logger;
            this.calculator = calculator;
        }

        [HttpGet]
        public string Add(double arg1, double arg2)
        {
            return calculator.Calculate(arg1, Operation.Plus, arg2).ToString(CultureInfo.InvariantCulture);
        }
        [HttpGet]
        public string Minus(double arg1, double arg2)
        {
            return calculator.Calculate(arg1, Operation.Minus, arg2).ToString(CultureInfo.InvariantCulture);
        }
        [HttpGet]
        public string Multiply(double arg1, double arg2)
        {
            return calculator.Calculate(arg1, Operation.Multiply, arg2).ToString(CultureInfo.InvariantCulture);
        }
        [HttpGet]
        public string Divide(double arg1, double arg2)
        {
            return arg2 == 0
                ? "Divide by zero exception"
                : calculator.Calculate(arg1, Operation.Divide, arg2).ToString(CultureInfo.InvariantCulture);
        }
    }
}