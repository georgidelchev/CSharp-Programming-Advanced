using System;

namespace ReVolt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int commandCount = int.Parse(Console.ReadLine());

            var matrix = new char[n, n];

            FillingUpTheMatrix(n, matrix);

            int startingPlayerRow = 0;
            int startingPlayerCol = 0;

            FindingPositionOfThePlayer(matrix, ref startingPlayerRow, ref startingPlayerCol);
            bool isWon = false;
            for (int i = 0; i < commandCount; i++)
            {
                var command = Console.ReadLine();

                int currentPlayerRow = startingPlayerRow;
                int currentPlayerCol = startingPlayerCol;

                MovingThePlayer(ref startingPlayerRow, ref startingPlayerCol, command);
                ValidatePlayerPosition(matrix, ref startingPlayerRow, ref startingPlayerCol);

                if (matrix[startingPlayerRow, startingPlayerCol] == 'B')
                {
                    MovingThePlayer(ref startingPlayerRow, ref startingPlayerCol, command);
                }

                ValidatePlayerPosition(matrix, ref startingPlayerRow, ref startingPlayerCol);
                
                if (matrix[startingPlayerRow, startingPlayerCol] == 'T')
                {
                    switch (command)
                    {
                        case "up":
                            startingPlayerRow++;
                            break;
                        case "down":
                            startingPlayerRow--;
                            break;
                        case "left":
                            startingPlayerCol++;
                            break;
                        case "right":
                            startingPlayerCol--;
                            break;
                    }
                }

                ValidatePlayerPosition(matrix, ref startingPlayerRow, ref startingPlayerCol);
                
                if (matrix[startingPlayerRow, startingPlayerCol] == 'F')
                {
                    matrix[startingPlayerRow, startingPlayerCol] = 'f';
                    ChangeTheField(matrix, startingPlayerRow, startingPlayerCol, currentPlayerRow, currentPlayerCol);
                    isWon = true;
                    break;
                }

                ValidatePlayerPosition(matrix, ref startingPlayerRow, ref startingPlayerCol);

                if (matrix[startingPlayerRow, startingPlayerCol] == '-')
                {
                    ChangeTheField(matrix, startingPlayerRow, startingPlayerCol, currentPlayerRow, currentPlayerCol);
                }
            }

            Console.WriteLine(isWon ?
                "Player won!" :
                "Player lost!");

            PrintingTheMatrix(matrix);
        }

        private static void ChangeTheField(char[,] matrix, int startingPlayerRow, int startingPlayerCol, int currentPlayerRow, int currentPlayerCol)
        {
            matrix[currentPlayerRow, currentPlayerCol] = '-';
            matrix[startingPlayerRow, startingPlayerCol] = 'f';
        }

        private static void ValidatePlayerPosition(char[,] matrix, ref int startingPlayerRow, ref int startingPlayerCol)
        {
            if (startingPlayerRow < 0)
            {
                startingPlayerRow = matrix.GetLength(0) - 1;
            }
            if (startingPlayerRow >= matrix.GetLength(0))
            {
                startingPlayerRow = 0;
            }
            if (startingPlayerCol < 0)
            {
                startingPlayerCol = matrix.GetLength(1) - 1;
            }
            if (startingPlayerCol >= matrix.GetLength(1))
            {
                startingPlayerCol = 0;
            }
        }

        private static void MovingThePlayer(ref int startingPlayerRow, ref int startingPlayerCol, string command)
        {
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
        }

        private static void FindingPositionOfThePlayer(char[,] matrix, ref int startingPlayerRow, ref int startingPlayerCol)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                bool isFound = false;

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'f')
                    {
                        startingPlayerRow = row;
                        startingPlayerCol = col;

                        isFound = true;
                        break;
                    }
                }

                if (isFound)
                {
                    break;
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

        private static void FillingUpTheMatrix(int n, char[,] matrix)
        {
            for (int row = 0; row < n; row++)
            {
                var input = Console
                    .ReadLine()
                    .ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
    }
}
