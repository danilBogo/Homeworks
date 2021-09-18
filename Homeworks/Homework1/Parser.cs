using System;
using System.Linq;

namespace Homework1
{
    public static class Parser
    {
        public static bool TryParseArguments(string[] args, out int val1, out int val2)
        {
            var isVal1Int = int.TryParse(args[0], out val1);
            var isVal2Int = int.TryParse(args[2], out val2);
            if (!isVal1Int || !isVal2Int)
            {
                Console.WriteLine($"{args[0]}{args[1]}{args[2]} is not a valid calculate syntax");
                {
                    return false;
                }
            }
            return true;
        }
    }
}