using System;
using System.Diagnostics;

namespace Homework8
{
    public class DefaultCalculator : ICalculator
    {
        public double Calculate(double arg1, Operation operation, double arg2)
        {
            return operation switch
            {
                Operation.Plus => arg1 + arg2,
                Operation.Minus => arg1 - arg2,
                Operation.Multiply => arg1 * arg2,
                Operation.Divide => arg1 / arg2
            };
        }
    }
}