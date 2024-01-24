using System;
using System.Collections.Generic;

namespace FuncsAndLambdas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4 };


            Func<string, int, float, int> isOdd = (string s, int x, float y) => x % 2;
        }
    }
}
