using System;
using System.Linq;

namespace BookWorm
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            int size = int.Parse(Console.ReadLine());

            var matrix = new char[size, size];

            int startingPlayerRow = 0;
            int startingPlayerCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console
                    .ReadLine()
                    .ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];

                    if (matrix[row, col] == 'P')
                    {
                        startingPlayerRow = row;
                        startingPlayerCol = col;
                    }
                }
            }

            string command = "";
            while ((command = Console.ReadLine()) != "end")
            {
                matrix[startingPlayerRow, startingPlayerCol] = '-';

                switch (command)
                {
                    case "up":
                        startingPlayerRow--;
                        break;
                    case "down":
                        startingPlayerRow++;
                        break;
                    case "left":
                        startingPlayerCol--;
                        break;
                    case "right":
                        startingPlayerCol++;
                        break;
                }

                bool isOutside = false;
                ValidatePositions(matrix, ref startingPlayerRow, ref startingPlayerCol, ref isOutside);

                if (isOutside)
                {
                    if (str.Length >= 1)
                    {
                        str = str.Remove(str.Length - 1);
                    }
                }

                if (char.IsLetter(matrix[startingPlayerRow, startingPlayerCol]))
                {
                    str += matrix[startingPlayerRow, startingPlayerCol];
                }

                matrix[startingPlayerRow, startingPlayerCol] = 'P';
            }

            Console.WriteLine(str);

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static void ValidatePositions(char[,] matrix, ref int startingPlayerRow, ref int startingPlayerCol, ref bool isOutside)
        {
            if (startingPlayerRow < 0)
            {
                startingPlayerRow = 0;
                isOutside = true;
            }

            if (startingPlayerRow > matrix.GetLength(0) - 1)
            {
                startingPlayerRow = matrix.GetLength(0) - 1;
                isOutside = true;
            }

            if (startingPlayerCol < 0)
            {
                startingPlayerCol = 0;
                isOutside = true;
            }

            if (startingPlayerCol > matrix.GetLength(1) - 1)
            {
                startingPlayerCol = matrix.GetLength(1) - 1;
                isOutside = true;
            }
        }
    }
}
