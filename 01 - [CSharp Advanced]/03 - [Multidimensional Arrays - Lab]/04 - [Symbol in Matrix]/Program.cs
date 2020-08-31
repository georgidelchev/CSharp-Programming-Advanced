namespace SymbolInMatrix
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            var matrix = new char[matrixSize, matrixSize];
            FillingUpTheMatrix(matrixSize, matrix);

            char symbol = char.Parse(Console.ReadLine());
            bool flag = false;

            flag = CheckingDidCurrentSymbolIsExisting(matrixSize, matrix, symbol, flag);

            if (!flag)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
        }
        private static void FillingUpTheMatrix(int matrixSize, char[,] matrix)
        {
            for (int row = 0; row < matrixSize; row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }

        private static bool CheckingDidCurrentSymbolIsExisting(int matrixSize, char[,] matrix, char symbol, bool flag)
        {
            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        flag = true;
                        break;
                    }
                }

                if (flag)
                {
                    break;
                }
            }

            return flag;
        }
    }
}
