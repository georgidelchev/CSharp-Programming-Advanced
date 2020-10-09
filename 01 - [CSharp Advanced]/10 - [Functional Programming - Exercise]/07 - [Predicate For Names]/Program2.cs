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

            Console
                .ReadLine()
                .Split()
                .Where(x => x.Length <= n)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
