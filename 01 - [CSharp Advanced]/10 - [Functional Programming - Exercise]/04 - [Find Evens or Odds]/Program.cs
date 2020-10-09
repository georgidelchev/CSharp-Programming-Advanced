using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace FindEvensOrOdds
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

            var criteria = Console.ReadLine();

            int start = numbers[0];
            int end = numbers[1];

            Func<int, int, List<int>> addingNumbers = (x, y) =>
              {
                  var list = new List<int>();

                  for (int i = x; i <= y; i++)
                  {
                      list.Add(i);
                  }

                  return list;
              };

            var currentNumbers = addingNumbers(start, end);

            Func<int, bool> func = criteria switch
            {
                "odd" => x => x % 2 != 0,
                "even" => x => x % 2 == 0,
            };

            Console.WriteLine(string.Join(" ", currentNumbers.Where(func)));
        }
    }
}
