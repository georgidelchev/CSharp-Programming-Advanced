using System;
using System.Collections.Generic;
using System.Linq;

namespace AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console
                .ReadLine()
                .Split(", ")
                .Select(double.Parse)
                .Select(x => x * 1.2)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x:f2}"));
        }
    }
}
