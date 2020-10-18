using System;
using System.Collections.Generic;

namespace Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            var matrix = new char[size, size];

            FillingUpTheMatrix(matrix);

            int currentBeeRow = 0;
            int currentBeeCol = 0;

            FindingStartingIndexesOfTheBee(matrix, ref currentBeeRow, ref currentBeeCol);

            int prevBeeRow = 0;
            int prevBeeCol = 0;

            int pollinatedFlowersCount = 0;
            bool isOut = false;

            string input = "";
            while ((input = Console.ReadLine()) != "End")
            {
                KeepingPreviousPositions(currentBeeRow, currentBeeCol, out prevBeeRow, out prevBeeCol);

                MovingTheBee(ref currentBeeRow, ref currentBeeCol, input);

                isOut = ValidateBeePosition(matrix, currentBeeRow, currentBeeCol, isOut);
                matrix[prevBeeRow, prevBeeCol] = '.';
                if (isOut)
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }

                if (matrix[currentBeeRow, currentBeeCol] == 'f')
                {
                    matrix[currentBeeRow, currentBeeCol] = 'B';
                    pollinatedFlowersCount++;
                }
                else if (matrix[currentBeeRow, currentBeeCol] == 'O')
                {
                    KeepingPreviousPositions(currentBeeRow, currentBeeCol, out prevBeeRow, out prevBeeCol);

                    MovingTheBee(ref currentBeeRow, ref currentBeeCol, input);

                    isOut = ValidateBeePosition(matrix, currentBeeRow, currentBeeCol, isOut);
                    matrix[prevBeeRow, prevBeeCol] = '.';
                    if (isOut)
                    {
                        Console.WriteLine("The bee got lost!");
                        break;
                    }

                    if (matrix[currentBeeRow, currentBeeCol] == 'f')
                    {
                        pollinatedFlowersCount++;
                    }

                    matrix[currentBeeRow, currentBeeCol] = 'B';
                }
                else
                {
                    matrix[prevBeeRow, prevBeeCol] = '.';
                    matrix[currentBeeRow, currentBeeCol] = 'B';
                }
            }

            Console.WriteLine(pollinatedFlowersCount >= 5
                ? $"Great job, the bee managed to pollinate {pollinatedFlowersCount} flowers!"
                : $"The bee couldn't pollinate the flowers, she needed {5 - pollinatedFlowersCount} flowers more");

            PrintingTheMatrix(matrix);
        }

        private static void KeepingPreviousPositions(int currentBeeRow, int currentBeeCol, out int prevBeeRow, out int prevBeeCol)
        {
            prevBeeRow = currentBeeRow;
            prevBeeCol = currentBeeCol;
        }

        private static void MovingTheBee(ref int currentBeeRow, ref int currentBeeCol, string input)
        {
            switch (input)
            {
                case "up":
                    currentBeeRow--;
                    break;
                case "down":
                    currentBeeRow++;
                    break;
                case "left":
                    currentBeeCol--;
                    break;
                case "right":
                    currentBeeCol++;
                    break;
            }
        }

        private static bool ValidateBeePosition(char[,] matrix, int currentBeeRow, int currentBeeCol, bool isOut)
        {
            if ((currentBeeRow < 0 || currentBeeRow >= matrix.GetLength(0)) ||
                (currentBeeCol < 0 || currentBeeCol >= matrix.GetLength(1)))
            {
                isOut = true;
            }

            return isOut;
        }

        private static void FindingStartingIndexesOfTheBee(char[,] matrix, ref int currentBeeRow, ref int currentBeeCol)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        currentBeeRow = row;
                        currentBeeCol = col;
                    }
                }
            }
        }

        private static void PrintingTheMatrix(char[,] matrix)
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
    }
}
