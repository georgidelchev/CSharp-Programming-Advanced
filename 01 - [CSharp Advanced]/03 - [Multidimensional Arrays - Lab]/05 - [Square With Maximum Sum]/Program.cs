using System;
using System.Collections.Generic;
using System.Linq;

namespace SquareWithMaximumSum

{
    class Program
    {
        static void Main(string[] args)
        {
            var matrixParams = Reading(',');

            int rows = matrixParams[0];
            int cols = matrixParams[1];

            var matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var elements = Reading(',');

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            int biggestSum = int.MinValue;
            int biggestRow = 0;
            int biggestCol = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int sum = matrix[row, col]
                        + matrix[row + 1, col]
                        + matrix[row, col + 1]
                        + matrix[row + 1, col + 1];

                    if (sum > biggestSum)
                    {
                        biggestSum = sum;
                        biggestRow = row;
                        biggestCol = col;
                    }
                }
            }

            Printing(matrix, biggestSum, biggestRow, biggestCol);
        }

        private static void Printing(int[,] matrix, int biggestSum, int biggestRow, int biggestCol)
        {
            Console.WriteLine(matrix[biggestRow, biggestCol]
                                    + " " + matrix[biggestRow, biggestCol + 1]
                                    + Environment.NewLine
                                    + matrix[biggestRow + 1, biggestCol]
                                    + " " + matrix[biggestRow + 1, biggestCol + 1]);

            Console.WriteLine(biggestSum);
        }

        private static List<int> Reading(params char[] ch)
            => Console
               .ReadLine()
               .Split(ch, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();
    }
}
