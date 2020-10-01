using System;
using System.Collections.Generic;
using System.Linq;

namespace CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, Dictionary<string, List<string>>>();

            int inputsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputsCount; i++)
            {
                var input = Console
                    .ReadLine()
                    .Split()
                    .ToList();

                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!dict.ContainsKey(continent))
                {
                    dict[continent] = new Dictionary<string, List<string>>();
                }

                if (!dict[continent].ContainsKey(country))
                {
                    dict[continent][country] = new List<string>();
                }

                dict[continent][country].Add(city);
            }

            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key}:");

                foreach (var kvp2 in kvp.Value)
                {
                    Console.WriteLine($"  {kvp2.Key} -> {string.Join(", ", kvp2.Value)}");
                }
            }
        }
    }
}
