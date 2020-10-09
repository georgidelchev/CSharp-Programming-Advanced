using System;
using System.Collections.Generic;
using System.Linq;

namespace KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console
                .ReadLine()
                .Split()
                .Select(x => $"Sir {x}")
                .ToList();

            Action<List<string>> print = n => n.ForEach(Console.WriteLine);
            print(names);
        }
    }
}
