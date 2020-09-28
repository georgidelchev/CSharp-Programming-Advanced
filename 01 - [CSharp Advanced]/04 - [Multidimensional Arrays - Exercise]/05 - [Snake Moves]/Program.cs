using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrixParameters = Reading();

            int rows = matrixParameters[0];
            int cols = matrixParameters[1];

            var matrix = new char[rows, cols];

            var input = Console
                .ReadLine()
                .ToCharArray();

            var queue = new Queue<char>(input);

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int counterForReverseAdding = cols - 1;

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    char ch = queue.Dequeue();

                    if (row % 2 == 0)
                    {
                        matrix[row, col] = ch;
                    }
                    else
                    {
                        matrix[row, counterForReverseAdding] = ch;
                        counterForReverseAdding--;
                    }

                    queue.Enqueue(ch);
                }
            }

            PrintingMatrix(rows, cols, matrix);
        }

        private static void PrintingMatrix(int rows, int cols, char[,] matrix)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
        }

        private static List<int> Reading()
            => Console
               .ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();
    }
}
