using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var parameters = Reading();

            int rows = parameters[0];
            int cols = parameters[1];

            var matrix = new int[rows, cols];

            FillingUpIntMatrix(matrix);

            int bestRow = 0;
            int bestCol = 0;
            int bestSum = 0;

            FindingBiggestSumAndBestIndexes(matrix, ref bestRow, ref bestCol, ref bestSum);

            Console.WriteLine($"Sum = {bestSum}");

            PrintingBestMatrix(matrix, bestRow, bestCol);
        }

        static void PrintingBestMatrix(int[,] matrix, int bestRow, int bestCol)
        {
            for (int row = bestRow; row < bestRow + 3; row++)
            {
                for (int col = bestCol; col < bestCol + 3; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        static void FindingBiggestSumAndBestIndexes(int[,] matrix, ref int bestRow, ref int bestCol, ref int bestSum)
        {
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int currentSum =
                        matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                        matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                        matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (currentSum > bestSum)
                    {
                        bestSum = currentSum;
                        bestRow = row;
                        bestCol = col;
                    }
                }
            }
        }

        static List<int> Reading()
            => Console
               .ReadLine()
               .Split()
               .Select(int.Parse)
               .ToList();

        static void FillingUpIntMatrix(int[,] matrix, params char[] ch)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var elements = Console
                    .ReadLine()
                    .Split(ch, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = elements[col];
                }
            }
        }
    }
}
