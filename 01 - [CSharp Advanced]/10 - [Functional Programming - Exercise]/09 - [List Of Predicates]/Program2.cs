using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());

            var nums = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            Func<int, int, bool> valdateDivisible = (x, y) => x % y != 0;

            Func<int, List<int>, List<int>> addNumbersFunc = (x, y) =>
            {
                List<int> list = AddingNumbers(y, end, valdateDivisible);

                return list;
            };

            var numsList = addNumbersFunc(end, nums);


            Console.WriteLine(string.Join(" ", numsList));
        }

        private static List<int> AddingNumbers(List<int> y, int end, Func<int, int, bool> valdateDivisible)
        {
            var list = new List<int>();

            for (int i = 1; i <= end; i++)
            {
                bool isValid = true;

                for (int j = 0; j < y.Count; j++)
                {
                    if (valdateDivisible(i, y[j]))
                    {
                        isValid = false;
                        break;
                    }
                }

                if (isValid)
                {
                    list.Add(i);
                }
            }

            return list;
        }
    }
}
