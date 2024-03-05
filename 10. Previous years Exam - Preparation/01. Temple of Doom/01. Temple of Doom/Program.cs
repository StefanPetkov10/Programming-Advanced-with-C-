using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Temple_of_Doom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputTools = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] inputSubstance = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> tools = new(inputTools);

            Stack<int> substances = new(inputSubstance);

            List<int> challenges = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                int currentTool = tools.Peek();
                int currentSubstances = substances.Peek();

                int theMultiplied = currentSubstances * currentTool;

                if (challenges.Contains(theMultiplied))
                {

                    tools.Dequeue();
                    substances.Pop();
                    challenges.Remove(theMultiplied);

                    if (challenges.Count == 0)
                    {
                        Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");
                        break;
                    }
                }
                else
                {
                    tools.Enqueue(tools.Dequeue() + 1);
                    substances.Push(substances.Pop() - 1);

                    if (substances.Peek() == 0)
                    {
                        substances.Pop();
                    }

                    if (substances.Count == 0)
                    {
                        Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");
                        break;
                    }
                }

            }
            if (tools.Count != 0)
            {
                Console.WriteLine($"Tools: {string.Join(", ", tools)}");
            }
            if (substances.Count != 0)
            {
                Console.WriteLine($"Substances: {string.Join(", ", substances)}");
            }
            if (challenges.Count != 0)
            {
                Console.WriteLine($"Challenges: {string.Join(", ", challenges)}");
            }
        }
    }
}
