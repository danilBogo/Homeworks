using System;

namespace Homework1
{
    public static class Extensions
    {
        public static bool TryParseToOperation(this string operation, out Operations result)
        {
            result = operation switch
            {
                "+" => Operations.Plus,
                "-" => Operations.Minus,
                "*" => Operations.Multiply,
                "/" => Operations.Divide,
                _ => Operations.Unknown
            };
            if (result is not Operations.Unknown) return true;
            Console.WriteLine($"{operation} is unknown operation!");
            return false;
        }
    }
}