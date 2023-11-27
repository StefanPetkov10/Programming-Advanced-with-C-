using System;
using System.Linq;

namespace _04._1_MaxSquare_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int rowSquare = int.Parse(Console.ReadLine());
            int colSquare = int.Parse(Console.ReadLine());


            string[] input = Console.ReadLine().Split(", ");

            int rows = int.Parse(input[0]);
            int cols = int.Parse(input[1]);

            int[,] matrix = new int[rows, cols];

            //3, 6
            //7, 1, 3, 3, 2, 1
            //1, 3, 9, 8, 8, 9
            //4, 6, 7, 9, 7, 9


            for (int row = 0; row < rows; row++)
            {
                int[] array = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = array[col];
                }
            }

            int maxSum = int.MinValue;
            int maxRow = 0;
            int maxCol = 0;

            for (int row = 0; row < rows - rowSquare + 1; row++)
            {
                for (int col = 0; col < cols - colSquare + 1; col++) 
                {
                    int currentSum = 0;

                    for (int currRow = row; currRow < row + rowSquare; currRow++)
                    {
                        for (int currCol = col; currCol < col + colSquare; currCol++)
                        {
                            currentSum += matrix[currRow, currCol];
                        }
                    }

                    if (currentSum >= maxSum)
                    {
                        maxRow = row;
                        maxCol = col;
                        maxSum = currentSum;
                    }
                }
            }

            for (int row = maxRow; row < maxRow + rowSquare; row++)
            {
                for (int col = maxCol; col < maxCol + colSquare; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(maxSum);
        }
    }
}
