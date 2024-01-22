using System;

namespace ForCycles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine("Hello");
            //}

            Print(10);

            void Print(int times)
            {

                if (times == 0)
                {
                    return;
                }
                Console.WriteLine("Hello");

                Print(times - 1);
            }
        }
    }
}
