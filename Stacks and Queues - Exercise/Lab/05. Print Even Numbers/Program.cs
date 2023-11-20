using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;

namespace _05._Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] digits = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> evenDigits = new Queue<int>();

            for (int i = 0; i < digits.Length; i++)
            {
                if (digits[i] % 2 == 0)
                {
                    evenDigits.Enqueue(digits[i]);
                }
            }

            Console.WriteLine(string.Join(", ", evenDigits.ToArray()));
            
        }
    }
}
