using System;
using System.Collections.Generic;
using System.Linq;

namespace MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrixParameters = Reading();

            int rows = matrixParameters[0];
            int cols = matrixParameters[1];

            var matrix = new string[rows, cols];

            FillingUpTheMatrix(matrix);

            string input = "";

            while ((input = Console.ReadLine()) != "END")
            {
                var splittedInput = input
                    .Split()
                    .ToList();

                if (splittedInput.Count != 5)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                string command = splittedInput[0];

                int firstRow = int.Parse(splittedInput[1]);
                int firstCol = int.Parse(splittedInput[2]);
                int secondRow = int.Parse(splittedInput[3]);
                int secondCol = int.Parse(splittedInput[4]);

                if (firstRow < 0 || firstCol > matrix.GetLength(0) ||
                    secondRow < 0 || secondCol > matrix.GetLength(1) || command != "swap")
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                string temp = matrix[firstRow, firstCol];
                matrix[firstRow, firstCol] = matrix[secondRow, secondCol];
                matrix[secondRow, secondCol] = temp;

                PrintingMatrix(matrix);
            }
        }

        private static void PrintingMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void FillingUpTheMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var elements = Console
                    .ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = elements[col];
                }
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
