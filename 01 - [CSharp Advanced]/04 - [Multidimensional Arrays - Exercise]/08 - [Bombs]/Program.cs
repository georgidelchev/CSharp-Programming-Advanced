using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizes = int.Parse(Console.ReadLine());

            var matrix = new int[sizes, sizes];

            FillingUpTheMatrix(sizes, matrix);

            var bombIndexes = Console
                .ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            int detonatedBombsCounter = 0;
            int totalBombsCounter = bombIndexes.Count / 2;

            while (detonatedBombsCounter != totalBombsCounter)
            {
                int row = int.Parse(bombIndexes[0]);
                int col = int.Parse(bombIndexes[1]);

                bombIndexes.RemoveAt(0);
                bombIndexes.RemoveAt(0);

                int bombDamage = matrix[row, col];

                DetonatingBombs(bombDamage, matrix, row, col);

                detonatedBombsCounter++;
            }

            int aliveCellsCounter = 0;
            int aliveCellsSum = 0;

            FindingAliveCellsAndTheirSum(sizes, matrix, ref aliveCellsCounter, ref aliveCellsSum);

            Console.WriteLine($"Alive cells: {aliveCellsCounter}");
            Console.WriteLine($"Sum: {aliveCellsSum}");

            PrintMatrix(sizes, matrix);
        }

        private static void FindingAliveCellsAndTheirSum(int sizes, int[,] matrix, ref int aliveCellsCounter, ref int aliveCellsSum)
        {
            for (int row = 0; row < sizes; row++)
            {
                for (int col = 0; col < sizes; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCellsCounter++;
                        aliveCellsSum += matrix[row, col];
                    }
                }
            }
        }

        private static void PrintMatrix(int sizes, int[,] matrix)
        {
            for (int row = 0; row < sizes; row++)
            {
                for (int col = 0; col < sizes; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void FillingUpTheMatrix(int size, int[,] matrix)
        {
            for (int row = 0; row < size; row++)
            {
                var input = Console
                    .ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }

        private static void DetonatingBombs(int bombDamage, int[,] matrix, int row, int col)
        {
            if (bombDamage > 0)
            {
                if (IsCellValid(row - 1, col + 1, matrix) && matrix[row - 1, col + 1] > 0)
                {
                    matrix[row - 1, col + 1] -= bombDamage;
                }
                if (IsCellValid(row - 1, col - 1, matrix) && matrix[row - 1, col - 1] > 0)
                {
                    matrix[row - 1, col - 1] -= bombDamage;
                }
                if (IsCellValid(row + 1, col + 1, matrix) && matrix[row + 1, col + 1] > 0)
                {
                    matrix[row + 1, col + 1] -= bombDamage;
                }
                if (IsCellValid(row + 1, col - 1, matrix) && matrix[row + 1, col - 1] > 0)
                {
                    matrix[row + 1, col - 1] -= bombDamage;
                }
                if (IsCellValid(row, col + 1, matrix) && matrix[row, col + 1] > 0)
                {
                    matrix[row, col + 1] -= bombDamage;
                }
                if (IsCellValid(row - 1, col, matrix) && matrix[row - 1, col] > 0)
                {
                    matrix[row - 1, col] -= bombDamage;
                }
                if (IsCellValid(row + 1, col, matrix) && matrix[row + 1, col] > 0)
                {
                    matrix[row + 1, col] -= bombDamage;
                }
                if (IsCellValid(row, col - 1, matrix) && matrix[row, col - 1] > 0)
                {
                    matrix[row, col - 1] -= bombDamage;
                }

                matrix[row, col] = 0;
            }

        }

        public static bool IsCellValid(int row, int col, int[,] matrix)
        {
            if (row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }

            return false;
        }
    }
}
