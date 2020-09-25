using System;
using System.Collections.Generic;
using System.Linq;

namespace JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrixParams = int.Parse(Console.ReadLine());

            var matrix = new int[matrixParams][];

            for (int row = 0; row < matrix.Length; row++)
            {
                var elements = Reading(' ');

                matrix[row] = new int[matrixParams];

                for (int col = 0; col < matrix.Length; col++)
                {
                    matrix[row][col] = elements[col];
                }
            }

            string input = "";
            while ((input = Console.ReadLine()) != "END")
            {
                var splittedInput = input
                    .Split()
                    .ToList();

                string command = splittedInput[0];
                int row = int.Parse(splittedInput[1]);
                int col = int.Parse(splittedInput[2]);
                int value = int.Parse(splittedInput[3]);

                if (matrix[0].Length - 1 < row || row < 0 || 
                    matrix[1].Length - 1 < col || col < 0)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                if (command == "Add")
                {
                    matrix[row][col] += value;
                }
                else if (command == "Subtract")
                {
                    matrix[row][col] -= value;
                }
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix.Length; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static List<int> Reading(params char[] ch)
            => Console
               .ReadLine()
               .Split(ch, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();
    }
}
