using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Array.Sort(nums, (x, y) =>
            {
                int result = 0;

                if (x % 2 == 0 && y % 2 != 0)
                {
                    result = -1;
                }
                else if (x % 2 != 0 && y % 2 == 0)
                {
                    result = 1;
                }
                else
                {
                    result = x.CompareTo(y);
                }

                return result;
            });

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
