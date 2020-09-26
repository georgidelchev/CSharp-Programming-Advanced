using System;
using System.Collections.Generic;
using System.Linq;

namespace SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var parameters = Reading();

            int rows = parameters[0];
            int cols = parameters[1];

            var matrix = new char[rows, cols];

            FillingUpIntMatrix(matrix);

            Console.WriteLine(CheckingTheNumberOfEqualSquares(matrix));
        }

        static int CheckingTheNumberOfEqualSquares(char[,] matrix)
        {
            int counter = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1] &&
                        matrix[row, col] == matrix[row + 1, col] &&
                        matrix[row, col] == matrix[row + 1, col + 1])
                    {
                        counter++;
                    }
                }
            }

            return counter;
        }

        static List<int> Reading()
            => Console
               .ReadLine()
               .Split()
               .Select(int.Parse)
               .ToList();

        static void FillingUpIntMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var elements = Console
                    .ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToList();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = elements[col];
                }
            }
        }
    }
}
