using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var names = Console
                .ReadLine()
                .Split()
                .ToList();

            Func<string, bool> func = x => x.Length <= n;

            names.Where(func)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
