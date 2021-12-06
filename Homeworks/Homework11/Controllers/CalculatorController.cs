using System;
using System.Globalization;
using Homework11.ExceptionHandler;
using Homework11.Services;
using Microsoft.AspNetCore.Mvc;

namespace Homework11.Controllers
{
    public class CalculatorController
    {
        private readonly ICalculator calculator;
        private readonly IExceptionHandler handler;

        public CalculatorController(ICalculator calculator, IExceptionHandler handler)
        {
            this.calculator = calculator;
            this.handler = handler;
        }
        [HttpGet]
        public string Calculate(string expression)
        {
            try
            {
                return calculator.Calculate(expression.GetUrlWithPluses()).ToString(CultureInfo.InvariantCulture);
            }
            catch (Exception e)
            {
                handler.Handle(e);
                return "";
            }
        }
    }
}