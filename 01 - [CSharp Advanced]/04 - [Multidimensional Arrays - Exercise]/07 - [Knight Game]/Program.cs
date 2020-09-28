using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.Linq;

namespace KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            var matrix = new char[size, size];

            FillingUpTheMatrix(size, matrix);

            int counter = 0;

            while (true)
            {
                int maxAmountOfAttackedKnights = 0;
                int maxRow = -1;
                int maxCol = -1;

                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        CheckingDoesTheKnightExistingAtTheCurrentCell(matrix, ref maxAmountOfAttackedKnights, ref maxRow, ref maxCol, row, col);
                    }
                }

                if (maxAmountOfAttackedKnights == 0)
                {
                    break;
                }

                matrix[maxRow, maxCol] = '0';

                counter++;
            }

            Console.WriteLine(counter);
        }

        private static void CheckingDoesTheKnightExistingAtTheCurrentCell(char[,] matrix, ref int maxAmountOfAttackedKnights, ref int maxRow, ref int maxCol, int row, int col)
        {
            if (matrix[row, col] == 'K')
            {
                int currentAmountOfAttackedKnights = AmountOfAttackedKnights(matrix, row, col);

                if (currentAmountOfAttackedKnights > maxAmountOfAttackedKnights)
                {
                    maxAmountOfAttackedKnights = currentAmountOfAttackedKnights;
                    maxRow = row;
                    maxCol = col;
                }
            }
        }

        private static int AmountOfAttackedKnights(char[,] matrix, int row, int col)
        {
            int counter = 0;

            if (IsKnightInCell(row - 2, col + 1, matrix) && matrix[row - 2, col + 1] == 'K')
            {
                counter++;
            }
            if (IsKnightInCell(row - 2, col - 1, matrix) && matrix[row - 2, col - 1] == 'K')
            {
                counter++;
            }
            if (IsKnightInCell(row + 2, col + 1, matrix) && matrix[row + 2, col + 1] == 'K')
            {
                counter++;
            }
            if (IsKnightInCell(row + 2, col - 1, matrix) && matrix[row + 2, col - 1] == 'K')
            {
                counter++;
            }
            if (IsKnightInCell(row + 1, col + 2, matrix) && matrix[row + 1, col + 2] == 'K')
            {
                counter++;
            }
            if (IsKnightInCell(row - 1, col + 2, matrix) && matrix[row - 1, col + 2] == 'K')
            {
                counter++;
            }
            if (IsKnightInCell(row + 1, col - 2, matrix) && matrix[row + 1, col - 2] == 'K')
            {
                counter++;
            }
            if (IsKnightInCell(row - 1, col - 2, matrix) && matrix[row - 1, col - 2] == 'K')
            {
                counter++;
            }

            return counter;
        }

        private static void FillingUpTheMatrix(int size, char[,] matrix)
        {
            for (int row = 0; row < size; row++)
            {
                var input = Console
                    .ReadLine()
                    .ToCharArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }

        public static bool IsKnightInCell(int row, int col, char[,] matrix)
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
