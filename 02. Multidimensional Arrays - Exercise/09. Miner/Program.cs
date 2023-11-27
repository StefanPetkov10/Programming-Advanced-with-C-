using System;
using System.Linq;

namespace _09._Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int[,] field = new int[size, size];

            int playerRow = 0;
            int playerCol = 0;

            int coal = 0;

            for (int row = 0; row < size; row++)
            {
                char[] characters = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < size; col++)
                {
                    field[row, col] = characters[col];

                    if (characters[col] == 's')
                    {
                        playerRow = row;
                        playerCol = col;
                    }

                    if (characters[col] == 'c')
                    {
                        coal++;
                    }
                }
            }

            bool isFailed = false;

            for (int i = 0; i < command.Length; i++)
            {
                PlayrMoves(command, field, ref playerRow, ref playerCol, i);

                if (field[playerRow, playerCol] == 'c')
                {
                    field[playerRow, playerCol] = '*';
                    coal--;
                    if (coal == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({playerRow}, {playerCol})");
                    }
                }

                if (field[playerRow, playerCol] == 'e')
                {
                    isFailed = true;
                    Console.WriteLine($"Game over! ({playerRow}, {playerCol})");
                }
            }
            if (isFailed == false && coal > 0)
            {
                Console.WriteLine($"{coal} coals left. ({playerRow}, {playerCol})");
            }
        }

        private static void PlayrMoves(string[] command, int[,] field, ref int playerRow, ref int playerCol, int i)
        {
            if (command[i] == "up" && playerRow > 0)
            {
                playerRow--;
            }

            if (command[i] == "right" && playerCol < field.GetLength(1) - 1)
            {
                playerCol++;
            }

            if (command[i] == "left" && playerCol > 0)
            {
                playerCol--;
            }

            if (command[i] == "down" && playerRow < field.GetLength(0) - 1)
            {
                playerRow++;
            }
        }
    }
}




