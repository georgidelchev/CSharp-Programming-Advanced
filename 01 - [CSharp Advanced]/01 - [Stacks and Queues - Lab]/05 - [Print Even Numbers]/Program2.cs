using System;
using System.Collections.Generic;
using System.Linq;

namespace PrintEvenNumbersSecondVersion
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .Where(x => x % 2 == 0)
                .ToList();

            var evenNumbers = new Queue<int>(numbers);
            Console.WriteLine(string.Join(", ", evenNumbers));
        }
    }
}
