using System;
using System.Linq;

namespace TronRacers
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            var matrix = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                var input = Console
                    .ReadLine()
                    .ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int startingFirstPlayerRow = 0;
            int startingFirstPlayerCol = 0;
            FindingStartingIndexesOfThePlayer(matrix, 'f', ref startingFirstPlayerRow, ref startingFirstPlayerCol);

            int startingSecondPlayerRow = 0;
            int startingSecondPlayerCol = 0;
            FindingStartingIndexesOfThePlayer(matrix, 's', ref startingSecondPlayerRow, ref startingSecondPlayerCol);

            while (true)
            {
                var commands = Console
                    .ReadLine()
                    .Split()
                    .ToList();

                string firstPlayerMove = commands[0];

                MovingCurrentPlayer(firstPlayerMove, ref startingFirstPlayerRow, ref startingFirstPlayerCol);
                ValidatePlayersPositions(matrix, ref startingFirstPlayerRow, ref startingFirstPlayerCol);

                if (ChangingTheMatrix(matrix, 'f', startingFirstPlayerRow, startingFirstPlayerCol))
                {
                    break;
                }

                string secondPlayerMove = commands[1];

                MovingCurrentPlayer(secondPlayerMove, ref startingSecondPlayerRow, ref startingSecondPlayerCol);
                ValidatePlayersPositions(matrix, ref startingSecondPlayerRow, ref startingSecondPlayerCol);

                if (ChangingTheMatrix(matrix, 's', startingSecondPlayerRow, startingSecondPlayerCol))
                {
                    break;
                }
            }

            PrintMatrix(matrix);
        }

        private static bool ChangingTheMatrix(char[,] matrix, char symbol, int startingPlayerRow, int startingPlayerCol)
        {
            if (matrix[startingPlayerRow, startingPlayerCol] == '*')
            {
                matrix[startingPlayerRow, startingPlayerCol] = symbol;
            }
            else
            {
                matrix[startingPlayerRow, startingPlayerCol] = 'x';
                return true;
            }

            return false;
        }

        private static void MovingCurrentPlayer(string playerMove, ref int startinPlayerRow, ref int startinPlayerCol)
        {
            switch (playerMove)
            {
                case "up":
                    startinPlayerRow--;
                    break;
                case "down":
                    startinPlayerRow++;
                    break;
                case "left":
                    startinPlayerCol--;
                    break;
                case "right":
                    startinPlayerCol++;
                    break;
            }

        }

        private static void ValidatePlayersPositions(char[,] matrix, ref int startinPlayerRow, ref int startinPlayerCol)
        {
            if (startinPlayerRow < 0)
            {
                startinPlayerRow = matrix.GetLength(0) - 1;
            }

            if (startinPlayerRow >= matrix.GetLength(1))
            {
                startinPlayerRow = 0;
            }

            if (startinPlayerCol < 0)
            {
                startinPlayerCol = matrix.GetLength(1) - 1;
            }

            if (startinPlayerCol >= matrix.GetLength(1))
            {
                startinPlayerCol = 0;
            }
        }

        private static void FindingStartingIndexesOfThePlayer(char[,] matrix, char playerSymbol, ref int startingPlayerRow, ref int startingPlayerCol)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == playerSymbol)
                    {
                        startingPlayerRow = row;
                        startingPlayerCol = col;
                    }
                }
            }
        }

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
    }
}
