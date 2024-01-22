using System;

namespace Funcs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int, bool> isOddVariable = IsOdd;

            bool isFiveOdd = isOddVariable(5);

            bool IsOdd(int x)
            {
                return x % 2 == 0;
            }
        }
    }
}
