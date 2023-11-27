using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;

namespace _08._Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];


            for (int row = 0; row < size; row++)
            {
                int[] elements = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            string[] bombCells = Console.ReadLine()
                  .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var bombCellsIndex in bombCells)
            {
                int[] indices = bombCellsIndex
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(i => int.Parse(i))
                    .ToArray();

                int row = indices[0];
                int col = indices[1];

                BombDamage(matrix, row, col);
            }

            int activeCells = 0;
            int sum = 0;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row,col] > 0)
                    {
                        activeCells++;
                        sum += matrix[row,col]; 
                    }
                }
            }

            Console.WriteLine($"Alive cells: {activeCells}");
            Console.WriteLine($"Sum: {sum}");

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }

         static void BombDamage(int[,] matrix, int row, int col)
        {
            int valueDamage = matrix[row, col];

            if (valueDamage > 0)
            {
                matrix[row, col] = 0;

                //top left
                if (row > 0 && col > 0 && matrix[row - 1, col - 1] > 0)
                {
                    matrix[row - 1, col - 1] -= valueDamage;
                }

                //top
                if (row > 0 && matrix[row - 1, col] > 0)
                {
                    matrix[row - 1, col] -= valueDamage;
                }

                //top right
                if (row > 0 && col + 1 < matrix.GetLength(1) && matrix[row - 1, col + 1] > 0)
                {
                    matrix[row - 1, col + 1] -= valueDamage;
                }

                //right
                if (col + 1 < matrix.GetLength(1) && matrix[row, col + 1] > 0)
                {
                    matrix[row, col + 1] -= valueDamage;
                }

                //bottom right
                if (row + 1 < matrix.GetLength(0) && col + 1 < matrix.GetLength(1) && matrix[row + 1, col + 1] > 0)
                {
                    matrix[row + 1, col + 1] -= valueDamage;
                }

                //bottom
                if (row + 1 < matrix.GetLength(0) && matrix[row + 1, col] > 0)
                {
                    matrix[row + 1, col] -= valueDamage;
                }

                //bottom left
                if (col > 0 && row + 1 < matrix.GetLength(0) && matrix[row + 1, col - 1] > 0)
                {
                    matrix[row + 1, col - 1] -= valueDamage;
                }

                //left
                if (col > 0 && matrix[row, col - 1] > 0)
                {
                    matrix[row, col - 1] -= valueDamage;
                }
            }           
        }   
    }
}
