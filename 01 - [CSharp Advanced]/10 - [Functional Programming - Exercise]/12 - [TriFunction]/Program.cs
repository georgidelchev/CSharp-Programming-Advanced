using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int minSum = int.Parse(Console.ReadLine());

            var names = Console
                .ReadLine()
                .Split()
                .ToList();

            Func<string, int, bool> nameSum = (x, y) => x.Select(c => (int)c).Sum() >= y;

            Func<List<string>, Func<string, int, bool>, string> name = (x, y) =>
            {
                string result = " ";

                for (int i = 0; i < x.Count; i++)
                {
                    if (y(x[i], minSum))
                    {
                        result = x[i];
                        break;
                    }
                }

                return result;
            };

            Console.WriteLine(name(names, nameSum));
        }
    }
}
