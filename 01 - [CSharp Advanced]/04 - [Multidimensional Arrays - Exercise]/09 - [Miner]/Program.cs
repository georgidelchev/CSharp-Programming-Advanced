using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.Linq;

namespace Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizes = int.Parse(Console.ReadLine());

            var directions = Reading();

            var matrix = new char[sizes, sizes];

            FillingUpTheMatrix(sizes, matrix);

            int startRowIndex = 0;
            int startColIndex = 0;

            int coalsCount = CountingAmountOfCoal(matrix);

            FindingStartingIndexes(matrix, ref startRowIndex, ref startColIndex);

            int collectedCoalCounter = 0;

            while (true)
            {
                if (collectedCoalCounter == coalsCount)
                {
                    Console.WriteLine($"You collected all coals! ({startRowIndex}, {startColIndex})"); //TODO
                    break;
                }
                else if (directions.Count == 0)
                {
                    Console.WriteLine($"{CountingAmountOfCoal(matrix)} coals left. ({startRowIndex}, {startColIndex})");
                    break;
                }

                string currentDirection = directions[0];
                directions.RemoveAt(0);

                int currRow = startRowIndex;
                int currCol = startColIndex;

                MovingToGivenDirection(currentDirection, ref currRow, ref currCol);

                if (IsCellValid(currRow, currCol, matrix))
                {
                    if (matrix[currRow, currCol] == 'e')
                    {
                        Console.WriteLine($"Game over! ({currRow}, {currCol})");
                        break;
                    }
                    else if (matrix[currRow, currCol] == 'c')
                    {
                        collectedCoalCounter++;
                    }

                    matrix[startRowIndex, startColIndex] = '*';
                    matrix[currRow, currCol] = 's';

                    startRowIndex = currRow;
                    startColIndex = currCol;
                }
            }
        }

        private static void MovingToGivenDirection(string currentDirection, ref int currRow, ref int currCol)
        {
            switch (currentDirection)
            {
                case "up":
                    currRow--;
                    break;
                case "down":
                    currRow++;
                    break;
                case "left":
                    currCol--;
                    break;
                case "right":
                    currCol++;
                    break;
            }
        }

        private static int CountingAmountOfCoal(char[,] matrix)
        {
            int coalsCount = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'c')
                    {
                        coalsCount++;
                    }
                }
            }

            return coalsCount;
        }

        private static void FindingStartingIndexes(char[,] matrix, ref int startRowIndex, ref int startColIndex)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 's')
                    {
                        startRowIndex = row;
                        startColIndex = col;
                    }
                }
            }
        }

        private static List<string> Reading()
            => Console
                .ReadLine()
                .Split()
                .ToList();

        private static void PrintMatrix(int sizes, char[,] matrix)
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

        private static void FillingUpTheMatrix(int size, char[,] matrix)
        {
            for (int row = 0; row < size; row++)
            {
                var input = Console
                    .ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToList();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }

        public static bool IsCellValid(int row, int col, char[,] matrix)
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
