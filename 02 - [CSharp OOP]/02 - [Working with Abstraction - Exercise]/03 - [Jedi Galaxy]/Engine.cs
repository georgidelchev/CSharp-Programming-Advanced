using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P03_JediGalaxy
{
    public class Engine
    {
        public void Proceed()
        {
            int[] matrixDimensions = ReadingInput();

            int n = matrixDimensions[0];
            int m = matrixDimensions[1];

            int[,] matrix = new int[n, m];

            FillingUpTheMatrix(matrix);

            string command = "";
            long totalPoints = 0;

            while ((command = Console.ReadLine()) != "Let the Force be with you")
            {
                int[] playerCoordinates = command
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int[] evilPowerCoordinates = ReadingInput();

                MovingEvilPower(matrix, evilPowerCoordinates);

                totalPoints = MovingPlayer(matrix, totalPoints, playerCoordinates);
            }

            Console.WriteLine(totalPoints);
        }

        private static int[] ReadingInput()
               => Console
                  .ReadLine()
                  .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                  .Select(int.Parse)
                  .ToArray();

        private static void FillingUpTheMatrix(int[,] matrix)
        {
            int value = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = value;
                    value++;
                }
            }
        }

        private static long MovingPlayer(int[,] matrix, long totalPoints, int[] playerCoordinates)
        {
            int playerRow = playerCoordinates[0];
            int playerCol = playerCoordinates[1];

            while (playerRow >= 0 && playerCol < matrix.GetLength(1))
            {
                if (playerRow >= 0 && playerRow < matrix.GetLength(0) && playerCol >= 0 && playerCol < matrix.GetLength(1))
                {
                    totalPoints += matrix[playerRow, playerCol];
                }

                playerCol++;
                playerRow--;
            }

            return totalPoints;
        }

        private static void MovingEvilPower(int[,] matrix, int[] evilPowerCoordinates)
        {
            int evilRow = evilPowerCoordinates[0];
            int evilCol = evilPowerCoordinates[1];

            while (evilRow >= 0 && evilCol >= 0)
            {
                if (evilRow >= 0 && evilRow < matrix.GetLength(0) &&
                    evilCol >= 0 && evilCol < matrix.GetLength(1))
                {
                    matrix[evilRow, evilCol] = 0;
                }

                evilRow--;
                evilCol--;
            }
        }
    }
}
