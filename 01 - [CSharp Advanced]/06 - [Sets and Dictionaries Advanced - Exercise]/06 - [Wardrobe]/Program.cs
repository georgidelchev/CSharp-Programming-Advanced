using System;
using System.Collections.Generic;
using System.Linq;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console
                    .ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                var currClothes = input[1]
                    .Split(",")
                    .ToList();

                string color = input[0];
                if (!dict.ContainsKey(color))
                {
                    dict[color] = new Dictionary<string, int>();
                }

                foreach (var item in currClothes)
                {
                    if (!dict[color].ContainsKey(item))
                    {
                        dict[color][item] = 0;
                    }

                    dict[color][item]++;
                }
            }

            var wantedDress = Console
                .ReadLine()
                .Split()
                .ToList();

            string wantedDressColor = wantedDress[0];
            string wantedDressType = wantedDress[1];

            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key} clothes:");

                foreach (var kvp2 in kvp.Value)
                {
                    Console.Write($"* {kvp2.Key} - {kvp2.Value}");

                    if (kvp.Key == wantedDressColor &&
                        kvp2.Key == wantedDressType)
                    {
                        Console.Write(" (found!)");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
