using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            Func<List<int>, int> minFunc = x =>
             {
                 int minValue = int.MaxValue;

                 foreach (var num in x)
                 {
                     if (num < minValue)
                     {
                         minValue = num;
                     }
                 }

                 return minValue;
             };

            Console.WriteLine(minFunc(names));
        }
    }
}
