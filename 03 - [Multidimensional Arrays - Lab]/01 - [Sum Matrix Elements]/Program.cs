namespace SumMatrixElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var matrixArgs = ReadingTheArray();

            int rows = matrixArgs[0];
            int cols = matrixArgs[1];

            var matrix = new int[rows, cols];
            AddingElementsToTheMatrix(rows, cols, matrix);

            int sum = 0;
            foreach (var item in matrix)
            {
                sum = SumTheMatrixElements(sum, item);
            }

            Printing(rows, cols, sum);
        }

        private static void AddingElementsToTheMatrix(int rows, int cols, int[,] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                var currRow = ReadingTheArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }
        }

        private static void Printing(int rows, int cols, int sum) 
            => Console.WriteLine(rows + Environment.NewLine + cols + Environment.NewLine + sum);

        private static int SumTheMatrixElements(int sum, int item)
            => sum += item;

        private static List<int> ReadingTheArray()
            => Console
               .ReadLine()
               .Split(", ")
               .Select(int.Parse)
               .ToList();
    }
}
