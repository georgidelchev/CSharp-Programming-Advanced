using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace AppliedArithmetics
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

            Action<List<int>> printingNumbers = x => Console.WriteLine(string.Join(" ", x));

            string input = "";
            while ((input = Console.ReadLine()) != "end")
            {
                Func<int, int> func = input switch
                {
                    "add" => x => x + 1,
                    "multiply" => x => x * 2,
                    "subtract" => x => x - 1,
                    _ => null
                };

                if (input == "print")
                {
                    printingNumbers(numbers);
                    continue;
                }

                numbers = numbers.Select(func).ToList();
            }
        }
    }
}
