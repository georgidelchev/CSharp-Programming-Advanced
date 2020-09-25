using System;

namespace PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrixParams = int.Parse(Console.ReadLine());

            var matrix = new long[matrixParams][];
            int cols = 0;

            for (int row = 0; row < matrix.Length; row++)
            {
                cols++;

                matrix[row] = new long[cols];
                matrix[row][0] = 1;
                matrix[row][matrix[row].Length - 1] = 1;

                if (cols >= 2)
                {
                    for (int col = 1; col < matrix[row].Length - 1; col++)
                    {
                        var prev = matrix[row - 1];

                        long firstNumber = prev[col];
                        long secondNumber = prev[col - 1];

                        matrix[row][col] = firstNumber + secondNumber;
                    }
                }
            }

            foreach (var item in matrix)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }
    }
}
