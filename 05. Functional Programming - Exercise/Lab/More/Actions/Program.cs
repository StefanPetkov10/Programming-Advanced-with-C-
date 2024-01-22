using System;

namespace Actions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<int> printVar = Print;

            printVar(5);

            void Print(int x)
            {
                Console.WriteLine("Hello" + x);
            }
        }
    }
}
