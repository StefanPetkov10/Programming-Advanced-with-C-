using System;
using System.Collections.Generic;

namespace _09._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = string.Empty;
            Stack<string> changes = new();

            int operationsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < operationsCount; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int command = int.Parse(tokens[0]);

                switch (command)
                {
                    case 1:
                        changes.Push(text);
                        text += tokens[1];
                        break;
                    case 2:
                        changes.Push(text);
                        int count = int.Parse(tokens[1]);
                        text = text.Remove(text.Length - count);
                        break;
//    else if (commands[0] == "2")
//    {
//        states.push(text);
//        int count = int.parse(commands[1]);
//        text = text.substring(0, text.length - count);
//    }
                    case 3:
                        int index = int.Parse(tokens[1]) - 1;
                        Console.WriteLine(text[index]);
                        break;
                    case 4:
                        text = changes.Pop();
                        break;
                }
            }
        }
    }
}
//int n = int.parse(console.readline());

//string text = string.empty; //todo: add stringbuilder

//stack<string> states = new stack<string>();

//for (int i = 0; i < n; i++)
//{
//    string[] commands = console.readline()
//        .split();

//    if (commands[0] == "1")
//    {
//        states.push(text);
//        text += commands[1];
//    }
//    else if (commands[0] == "2")
//    {
//        states.push(text);
//        int count = int.parse(commands[1]);
//        text = text.substring(0, text.length - count);
//    }
//    else if (commands[0] == "3")
//    {
//        int index = int.parse(commands[1]) - 1;
//        console.writeline(text[index]);
//    }
//    else if (commands[0] == "4")
//    {
//        text = states.pop();
//    }
//}