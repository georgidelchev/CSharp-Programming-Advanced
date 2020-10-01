using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<double, int>();

            var numbers = Console
                .ReadLine()
                .Split()
                .Select(double.Parse)
                .ToList();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (!dict.ContainsKey(numbers[i]))
                {
                    dict[numbers[i]] = 0;
                }

                dict[numbers[i]]++;
            }

            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}
