using System;
using System.Collections.Generic;

namespace HashSet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> uniqueNumbers = new HashSet<int>();

            uniqueNumbers.Add(0);
            uniqueNumbers.Add(1);
            uniqueNumbers.Add(2);
            uniqueNumbers.Add(3);
            uniqueNumbers.Add(3);
            uniqueNumbers.Add(3);
            uniqueNumbers.Add(3);
            uniqueNumbers.Add(3);
            uniqueNumbers.Add(3);
            uniqueNumbers.Add(3);
            uniqueNumbers.Add(3);
            uniqueNumbers.Add(3);
            uniqueNumbers.Add(3);
            uniqueNumbers.Add(3);
            uniqueNumbers.Add(4);

            uniqueNumbers.Remove(4);

            Console.WriteLine(uniqueNumbers.Contains(3));


            Console.WriteLine(uniqueNumbers.Count);

            foreach (var item in uniqueNumbers)
            {
                Console.WriteLine(item);
            }
        }
    }
}
