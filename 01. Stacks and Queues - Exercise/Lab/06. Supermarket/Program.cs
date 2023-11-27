using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queueName = new Queue<string>();
            int nameCount = 0;

            string newName;
            while ((newName = Console.ReadLine()) != "End")
            {  

                if(newName != "Paid")
                {
                    queueName.Enqueue(newName);
                    nameCount++;

                }
                else
                {
                    for (int i = 0; i < queueName.Count;)
                    {
                        Console.WriteLine(queueName.Dequeue());
                    }
                    nameCount = 0;
                }
            }
            Console.WriteLine($"{nameCount} people remaining.");
        }
    }
}
