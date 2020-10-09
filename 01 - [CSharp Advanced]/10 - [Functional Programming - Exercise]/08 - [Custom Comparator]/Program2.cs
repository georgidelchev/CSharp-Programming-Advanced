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
            x % 2 == 0 && y % 2 != 0 ? -1 : 
            x % 2 != 0 && y % 2 == 0 ? 1 : 
            x.CompareTo(y));

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
