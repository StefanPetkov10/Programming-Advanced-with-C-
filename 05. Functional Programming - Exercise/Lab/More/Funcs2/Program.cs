using System;

namespace Funcs2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int, float, float> addFunc = Add;

            float Add(int a, float b)
            {

                return a + b;
            }
        }
    }
}
