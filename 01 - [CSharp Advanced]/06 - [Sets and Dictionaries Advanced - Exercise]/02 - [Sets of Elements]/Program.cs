using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var firstSet = new HashSet<int>();
            var secondSet = new HashSet<int>();

            int n = input[0];
            int m = input[1];

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                firstSet.Add(num);
            }

            for (int i = 0; i < m; i++)
            {
                int num = int.Parse(Console.ReadLine());

                secondSet.Add(num);
            }

            var result = firstSet.Where(x => secondSet.Contains(x)).ToList();
            
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
