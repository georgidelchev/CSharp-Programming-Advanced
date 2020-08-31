using System;
using System.Collections.Generic;
using System.Linq;

namespace SumMatrixColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrixArgs = ReadingMatrix(',', ' ');

            int rows = matrixArgs[0];
            int cols = matrixArgs[1];

            var matrix = new int[rows, cols];

            AddingElementsToTheMatrix(rows, cols, matrix);
            CalculatingSumOfEveryCol(rows, cols, matrix);
        }
        public static List<int> ReadingMatrix(params char[] splitChars)
            => Console
               .ReadLine()
               .Split(splitChars, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();

        private static void AddingElementsToTheMatrix(int rows, int cols, int[,] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                var input = ReadingMatrix(' ');

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
        
        private static void CalculatingSumOfEveryCol(int rows, int cols, int[,] matrix)
        {
            for (int col = 0; col < cols; col++)
            {
                int currentColumnSum = 0;

                for (int row = 0; row < rows; row++)
                {
                    currentColumnSum += matrix[row, col];
                }

                Console.WriteLine(currentColumnSum);
            }
        }
    }
}
