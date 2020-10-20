using System;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var matrix = new char[n, n];

            int startingSnakeRow = 0;
            int startingSnakeCol = 0;

            FillingTheMatrix(n, matrix, ref startingSnakeRow, ref startingSnakeCol);


            int foodCount = 0;
            while (foodCount < 10)
            {
                string command = Console.ReadLine();

                int currentSnakeRow = startingSnakeRow;
                int currentSnakeCol = startingSnakeCol;
                matrix[startingSnakeRow, startingSnakeCol] = '.';

                switch (command)
                {
                    case "up":
                        currentSnakeRow--;
                        break;
                    case "down":
                        currentSnakeRow++;
                        break;
                    case "left":
                        currentSnakeCol--;
                        break;
                    case "right":
                        currentSnakeCol++;
                        break;
                }

                if (currentSnakeRow < 0 || currentSnakeRow >= matrix.GetLength(0) ||
                    currentSnakeCol < 0 || currentSnakeCol >= matrix.GetLength(1))
                {
                    break;
                }

                if (matrix[currentSnakeRow, currentSnakeCol] == '*')
                {
                    foodCount++;
                }
                else if (matrix[currentSnakeRow, currentSnakeCol] == 'B')
                {
                    matrix[currentSnakeRow, currentSnakeCol] = '.';

                    int burrowRow = 0;
                    int burrowCol = 0;

                    FindingSecondBurrow(matrix, ref burrowRow, ref burrowCol);

                    currentSnakeRow = burrowRow;
                    currentSnakeCol = burrowCol;
                }

                matrix[currentSnakeRow, currentSnakeCol] = 'S';
                startingSnakeRow = currentSnakeRow;
                startingSnakeCol = currentSnakeCol;
            }

            Console.WriteLine(foodCount == 10 ?
                $"You won! You fed the snake.{Environment.NewLine}Food eaten: {foodCount}" :
                $"Game over!{Environment.NewLine}Food eaten: {foodCount}");

            PrintingTheMatrix(matrix);
        }

        private static void FindingSecondBurrow(char[,] matrix, ref int burrowRow, ref int burrowCol)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                bool isFound = false;

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        burrowRow = row;
                        burrowCol = col;

                        isFound = false;
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

        private static void FillingTheMatrix(int n, char[,] matrix, ref int startingSnakeRow, ref int startingSnakeCol)
        {
            for (int row = 0; row < n; row++)
            {
                var input = Console
                    .ReadLine()
                    .ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];

                    if (matrix[row, col] == 'S')
                    {
                        startingSnakeRow = row;
                        startingSnakeCol = col;
                    }
                }
            }
        }
    }
}
