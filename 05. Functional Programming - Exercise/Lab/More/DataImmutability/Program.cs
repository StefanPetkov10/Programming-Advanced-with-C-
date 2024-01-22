using System;

namespace DataImmutability
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int Add(int a, int b)
            {
                a = 5;
                a++;
                int n = 10;
                n = 3;

                return a + b;
            }
        }
    }
}
