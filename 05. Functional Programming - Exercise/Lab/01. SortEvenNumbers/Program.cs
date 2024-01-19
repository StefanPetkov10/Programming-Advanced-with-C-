using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._SortEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> evenNumbers = Console.ReadLine()
            .Split(", ")
            .Select(int.Parse)
            .Where(x => x % 2 == 0)
            .OrderBy(x => x)
            .ToList();

            Console.WriteLine(String.Join(", ", evenNumbers));
        }
    }
}
