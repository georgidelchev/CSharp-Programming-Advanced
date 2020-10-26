using System;
using System.Collections.Generic;
using System.Linq;

namespace Garden
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var inputSize = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int n = inputSize[0];
            int m = inputSize[1];

            var matrix = new int[n, m];

            var coordinatesList = new List<Coordinates>();

            string input = "";
            while ((input = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                var coordinates = input
                    .Split()
                    .Select(int.Parse)
                    .ToList();

                int row = coordinates[0];
                int col = coordinates[1];

                if (row < 0 || row >= matrix.GetLength(0) ||
                    col < 0 || col >= matrix.GetLength(1))
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }

                coordinatesList.Add(new Coordinates(row, col));

                matrix[row, col] = -3;
            }

            foreach (var item in coordinatesList)
            {
                int currentRow = item.Row;
                int currentCol = item.Col;

                Spreading(matrix, currentRow, currentCol, "up");
                Spreading(matrix, currentRow, currentCol, "down");
                Spreading(matrix, currentRow, currentCol, "left");
                Spreading(matrix, currentRow, currentCol, "right");
            }

            PrintingTheMatrix(matrix);
        }

        private static void Spreading(int[,] matrix, int currentRow, int currentCol, string position)
        {
            int changingRow = currentRow;
            int changingCol = currentCol;

            while (changingRow >= 0 && changingRow < matrix.GetLength(0) &&
                   changingCol >= 0 && changingCol < matrix.GetLength(1))
            {
                matrix[changingRow, changingCol]++;

                switch (position)
                {
                    case "up":
                        changingRow--;
                        break;
                    case "down":
                        changingRow++;
                        break;
                    case "left":
                        changingCol--;
                        break;
                    case "right":
                        changingCol++;
                        break;
                }
            }
        }

        private static void PrintingTheMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }

    class Coordinates
    {
        public Coordinates(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }

        public int Col { get; set; }
    }
}
