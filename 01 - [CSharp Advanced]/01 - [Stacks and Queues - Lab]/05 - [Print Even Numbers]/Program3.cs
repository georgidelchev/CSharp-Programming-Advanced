using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var queue = new Queue<int>(numbers);
            Console.WriteLine(string.Join(", ", queue.Where(x => x % 2 == 0)));
        }
    }
}
