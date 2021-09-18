using System;

namespace Homework1
{
    public enum Operations
    {
        Plus,Minus,Multiply,Divide,Unknown  
    }
    public static class Calculator
    {
        public static double Calculate(int val1, Operations operation, int val2)
        {
            return operation switch
            {
                Operations.Plus => val1 + val2,
                Operations.Minus => val1 - val2,
                Operations.Multiply => val1 * val2,
                Operations.Divide => (double)val1 / val2
            };
        }
    }
}