using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.Linq;

namespace RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            var sizes = Reading();

            int rows = sizes[0];
            int cols = sizes[1];

            var matrix = new char[rows, cols];

            FillingUpTheMatrix(matrix);

            var commands = Console
                .ReadLine()
                .ToCharArray()
                .ToList();

            int startingRowIndex = 0;
            int startingColIndex = 0;

            FindingStartingIndexes(matrix, ref startingRowIndex, ref startingColIndex);

            var bunniesIndexes = new List<int>();

            while (true)
            {
                string currentCommand = commands[0].ToString();
                commands.RemoveAt(0);

                int currRow = startingRowIndex;
                int currCol = startingColIndex;

                MovingToGivenDirection(currentCommand, ref currRow, ref currCol);

                if (IsCellValid(currRow, currCol, matrix))
                {
                    matrix[startingRowIndex, startingColIndex] = '.';

                    startingRowIndex = currRow;
                    startingColIndex = currCol;

                    if (matrix[startingRowIndex, startingColIndex] == 'B')
                    {
                        FindingBunniesIndexes(matrix, bunniesIndexes);
                        SpreadingTheBunnies(matrix, bunniesIndexes);
                        PrintMatrix(matrix);

                        Console.WriteLine($"dead: {startingRowIndex} {startingColIndex}");
                        break;
                    }
                    else
                    {
                        matrix[startingRowIndex, startingColIndex] = 'P';

                        FindingBunniesIndexes(matrix, bunniesIndexes);
                        SpreadingTheBunnies(matrix, bunniesIndexes);

                        bool isPlayerAlive = false;
                        for (int i = 0; i < matrix.GetLength(0); i++)
                        {
                            for (int j = 0; j < matrix.GetLength(1); j++)
                            {
                                if (matrix[i, j] == 'P')
                                {
                                    isPlayerAlive = true;

                                    break;
                                }
                            }

                            if (isPlayerAlive)
                            {
                                break;
                            }
                        }

                        if (!isPlayerAlive)
                        {
                            PrintMatrix(matrix);

                            Console.WriteLine($"dead: {startingRowIndex} {startingColIndex}");
                            break;
                        }
                    }

                }
                else
                {
                    matrix[startingRowIndex, startingColIndex] = '.';
                    
                    FindingBunniesIndexes(matrix, bunniesIndexes);
                    SpreadingTheBunnies(matrix, bunniesIndexes);
                    PrintMatrix(matrix);
                    
                    Console.WriteLine($"won: {startingRowIndex} {startingColIndex}");
                    break;
                }
            }
        }

        private static void FindingBunniesIndexes(char[,] matrix, List<int> bunniesIndexes)
        {
            bunniesIndexes.Clear();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        bunniesIndexes.Add(row);
                        bunniesIndexes.Add(col);
                    }
                }
            }
        }

        private static void SpreadingTheBunnies(char[,] matrix, List<int> bunniesIndexes)
        {
            for (int i = 0; i < bunniesIndexes.Count; i += 2)
            {
                int firstBunnyIndex = bunniesIndexes[i];
                int secondBunnyIndex = bunniesIndexes[i + 1];

                if (IsCellValid(firstBunnyIndex + 1, secondBunnyIndex, matrix))
                {
                    matrix[firstBunnyIndex + 1, secondBunnyIndex] = 'B';
                }
                if (IsCellValid(firstBunnyIndex, secondBunnyIndex + 1, matrix))
                {
                    matrix[firstBunnyIndex, secondBunnyIndex + 1] = 'B';
                }
                if (IsCellValid(firstBunnyIndex - 1, secondBunnyIndex, matrix))
                {
                    matrix[firstBunnyIndex - 1, secondBunnyIndex] = 'B';
                }
                if (IsCellValid(firstBunnyIndex, secondBunnyIndex - 1, matrix))
                {
                    matrix[firstBunnyIndex, secondBunnyIndex - 1] = 'B';
                }
            }
        }

        private static void MovingToGivenDirection(string currentDirection, ref int currRow, ref int currCol)
        {
            switch (currentDirection)
            {
                case "U":
                    currRow--;
                    break;
                case "D":
                    currRow++;
                    break;
                case "L":
                    currCol--;
                    break;
                case "R":
                    currCol++;
                    break;
            }
        }

        private static void FindingStartingIndexes(char[,] matrix, ref int startRowIndex, ref int startColIndex)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'P')
                    {
                        startRowIndex = row;
                        startColIndex = col;

                        break;
                    }
                }
            }
        }

        private static List<int> Reading()
            => Console
                .ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static void FillingUpTheMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console
                    .ReadLine()
                    .ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
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
