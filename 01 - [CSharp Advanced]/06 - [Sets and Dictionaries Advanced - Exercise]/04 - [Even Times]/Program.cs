using System;
using System.Collections.Generic;
using System.Linq;

namespace EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<int, int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (!dict.ContainsKey(num))
                {
                    dict[num] = 0;
                }

                dict[num]++;
            }

            dict = dict
                .Where(x => x.Value % 2 == 0)
                .ToDictionary(x => x.Key, x => x.Value);
            
            Console.WriteLine(string.Join(" ", dict.Keys));
        }
    }
}
