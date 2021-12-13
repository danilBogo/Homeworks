using System;
using Homework2.IL;

namespace Homework2
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            var parsedArguments = Parser.TryParseArguments(args, out var val1, out var val2);
            if (parsedArguments)
            {
                var parsedOperation = args[1].TryParseToOperation(out var operation);
                if (parsedOperation)
                {
                    var result = Calculator.Calculate(val1, operation, val2);
                    Console.WriteLine($"{val1}{args[1]}{val2}={result}");
                    return 0;
                }

                return 2;
            }

            return 1;
        }
    }
}