using System;
using System.Collections.Generic;
using System.Linq;

namespace ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console
                .ReadLine()
                .Split()
                .ToList();

            Action<List<string>> print = n => n.ForEach(Console.WriteLine);
            print(names);
        }
    }
}
