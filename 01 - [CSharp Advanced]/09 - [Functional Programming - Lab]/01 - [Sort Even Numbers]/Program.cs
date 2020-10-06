using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterByAge​
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console
                .ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .Where(x => x % 2 == 0)
                .OrderBy(x => x)
                .ToList();

            Console.WriteLine(string.Join(", ", nums));
        }
    }
}
