using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            var jagged = new double[rows][];

            FillingUpTheJaggedArray(rows, jagged);

            AnalyzingTheJaggedArray(jagged);

            string input = "";

            while ((input = Console.ReadLine()) != "End")
            {
                var splittedInpiut = input
                    .Split()
                    .ToList();

                string command = splittedInpiut[0];

                int row = int.Parse(splittedInpiut[1]);
                int col = int.Parse(splittedInpiut[2]);
                int value = int.Parse(splittedInpiut[3]);

                if (row < 0 || row > rows ||
                    col < 0 || col > jagged[row].Length - 1)
                {
                    continue;
                }

                ManipulatingTheJaggedArray(jagged, command, row, col, value);
            }

            PrintingTheJaggedArray(jagged);
        }

        private static void ManipulatingTheJaggedArray(double[][] jagged, string command, int row, int col, int value)
        {
            switch (command)
            {
                case "Add":
                    jagged[row][col] += value;
                    break;
                case "Subtract":
                    jagged[row][col] -= value;
                    break;
            }
        }

        private static void FillingUpTheJaggedArray(int rows, double[][] jagged)
        {
            for (int row = 0; row < rows; row++)
            {
                var elements = Console
                    .ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToList();

                jagged[row] = new double[elements.Count];

                for (int col = 0; col < elements.Count; col++)
                {
                    jagged[row][col] = elements[col];
                }
            }
        }

        private static void PrintingTheJaggedArray(double[][] jagged)
        {
            foreach (var item in jagged)
            {
                Console.Write(string.Join(" ", item));
                
                Console.WriteLine();
            }
        }

        private static void AnalyzingTheJaggedArray(double[][] jagged)
        {
            for (int i = 0; i < jagged.Length - 1; i++)
            {
                int firstRowLength = jagged[i].Length;
                int secondRowLength = jagged[i + 1].Length;

                if (firstRowLength == secondRowLength)
                {
                    jagged[i] = jagged[i].Select(x => x * 2).ToArray();

                    jagged[i + 1] = jagged[i + 1].Select(x => x * 2).ToArray();
                }
                else
                {
                    jagged[i] = jagged[i].Select(x => x / 2).ToArray();

                    jagged[i + 1] = jagged[i + 1].Select(x => x / 2).ToArray();
                }
            }
        }
    }
}
