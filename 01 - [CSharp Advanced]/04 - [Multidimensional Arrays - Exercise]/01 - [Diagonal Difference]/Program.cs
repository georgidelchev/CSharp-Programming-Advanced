using System;
using System.Linq;

namespace DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            var matrix = new int[size, size];

            FillingUpIntMatrix(matrix);

            Console.WriteLine(Math.Abs(FindingDiagonalsSums(size, matrix)));
        }

        static void FillingUpIntMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var elements = Console
                    .ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = elements[col];
                }
            }
        }

        static int FindingDiagonalsSums(int size, int[,] matrix)
        {
            int primaryDiagonalSum = 0;
            int secondaryDiagonalSum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                primaryDiagonalSum += matrix[row, row];
                secondaryDiagonalSum += matrix[row, size - row - 1];
            }

            return primaryDiagonalSum - secondaryDiagonalSum;
        }
    }
}
