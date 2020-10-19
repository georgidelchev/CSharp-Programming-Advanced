using System;
using System.Linq;

namespace PresentDelivery
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int presentsCount = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());

            var matrix = new string[size, size];

            FillingUpTheMatrix(size, matrix);

            int startingSantasRow = 0;
            int startingSantasCol = 0;

            int startingNiceKids = 0;

            startingNiceKids = CountOfNiceKids(matrix);

            FindingSantasIndexes(matrix, ref startingSantasRow, ref startingSantasCol);

            string command = "";

            bool isOutOfPresents = false;

            while ((command = Console.ReadLine()) != "Christmas morning")
            {
                int currentSantasRow = startingSantasRow;
                int currentSantasCol = startingSantasCol;

                MovingSanta(command, ref currentSantasRow, ref currentSantasCol);
                
                matrix[startingSantasRow, startingSantasCol] = "-";

                if (ValidateSantaPosition(matrix, currentSantasRow, currentSantasCol))
                {
                    if (matrix[currentSantasRow, currentSantasCol] == "V")
                    {
                        presentsCount--;
                    }
                    else if (matrix[currentSantasRow, currentSantasCol] == "C")
                    {
                        presentsCount = MovingSantaAround(presentsCount, matrix, currentSantasRow, currentSantasCol);
                    }

                    startingSantasRow = currentSantasRow;
                    startingSantasCol = currentSantasCol;

                    matrix[currentSantasRow, currentSantasCol] = "S";
                }

                if (!CheckingPresentsCount(presentsCount))
                {
                    isOutOfPresents = true;

                    break;
                }
            }

            int currentNiceKidsCount = 0;

            currentNiceKidsCount = CountOfNiceKids(matrix);

            if (isOutOfPresents && command != "Christmas morning")
            {
                Console.WriteLine("Santa ran out of presents!");
            }

            PrintingTheMatrix(size, matrix);

            Console.WriteLine(currentNiceKidsCount == 0 ?
                $"Good job, Santa! {startingNiceKids} happy nice kid/s." :
                $"No presents for {currentNiceKidsCount} nice kid/s.");
        }

        private static int MovingSantaAround(int presentsCount, string[,] matrix, int currentSantasRow, int currentSantasCol)
        {
            if (matrix[currentSantasRow - 1, currentSantasCol] == "V" ||
                                        matrix[currentSantasRow - 1, currentSantasCol] == "X")
            {
                matrix[currentSantasRow - 1, currentSantasCol] = "-";
                
                presentsCount--;
            }
            if (matrix[currentSantasRow + 1, currentSantasCol] == "V" ||
                matrix[currentSantasRow + 1, currentSantasCol] == "X")
            {
                matrix[currentSantasRow + 1, currentSantasCol] = "-";
                
                presentsCount--;
            }
            if (matrix[currentSantasRow, currentSantasCol + 1] == "V" ||
                matrix[currentSantasRow, currentSantasCol + 1] == "X")
            {
                matrix[currentSantasRow, currentSantasCol + 1] = "-";
                
                presentsCount--;
            }
            if (matrix[currentSantasRow, currentSantasCol - 1] == "V" ||
                matrix[currentSantasRow, currentSantasCol - 1] == "X")
            {
                matrix[currentSantasRow, currentSantasCol - 1] = "-";
                
                presentsCount--;
            }

            return presentsCount;
        }

        private static void MovingSanta(string command, ref int currentSantasRow, ref int currentSantasCol)
        {
            switch (command)
            {
                case "up":
                    currentSantasRow--;
                    break;
                case "down":
                    currentSantasRow++;
                    break;
                case "right":
                    currentSantasCol++;
                    break;
                case "left":
                    currentSantasCol--;
                    break;
            }
        }

        private static bool CheckingPresentsCount(int presentsCount)
        {
            bool result = true;

            if (presentsCount <= 0)
            {
                result = false;
            }

            return result;
        }

        private static bool ValidateSantaPosition(string[,] matrix, int currentSantasRow, int currentSantasCol)
        {
            bool isInside = true;

            if ((currentSantasRow < 0 || currentSantasRow >= matrix.GetLength(0)) ||
                (currentSantasCol < 0 || currentSantasCol >= matrix.GetLength(1)))
            {
                isInside = false;
            }

            return isInside;
        }

        private static int CountOfNiceKids(string[,] matrix)
        {
            int niceKidsCount = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == "V")
                    {
                        niceKidsCount++;
                    }
                }
            }

            return niceKidsCount;
        }

        private static void FindingSantasIndexes(string[,] matrix, ref int startingSantasRow, ref int startingSantasCol)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                bool isFound = false;

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == "S")
                    {
                        startingSantasRow = row;
                        startingSantasCol = col;

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

        private static void PrintingTheMatrix(int size, string[,] matrix)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void FillingUpTheMatrix(int size, string[,] matrix)
        {
            for (int row = 0; row < size; row++)
            {
                var input = Console
                    .ReadLine()
                    .Split()
                    .ToList();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
    }
}
