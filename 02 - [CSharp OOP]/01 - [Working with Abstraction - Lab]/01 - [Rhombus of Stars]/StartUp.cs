using System;

namespace RhombusOfStars
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            PrintUpperHalf(n);
            PrintLowerHalf(n);
        }

        private static void PrintLowerHalf(int n)
        {
            for (int i = n - 1; i >= 1; i--)
            {
                PrintRow(n, i);
            }
        }

        private static void PrintUpperHalf(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                PrintRow(n, i);
            }
        }

        public static void PrintRow(int size, int count)
        {
            for (int i = 0; i < size - count; i++)
            {
                Console.Write(" ");
            }

            for (int i = 0; i < count; i++)
            {
                Console.Write("* ");
            }

            Console.WriteLine();
        }
    }
}
