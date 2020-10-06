using System;
using System.Collections.Generic;
using System.Linq;

namespace SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> func = int.Parse;

            var nums = Console
                .ReadLine()
                .Split(", ")
                .Select(func)
                .ToList();

            Console.WriteLine(nums.Count());
            Console.WriteLine(nums.Sum());
        }
    }
}
