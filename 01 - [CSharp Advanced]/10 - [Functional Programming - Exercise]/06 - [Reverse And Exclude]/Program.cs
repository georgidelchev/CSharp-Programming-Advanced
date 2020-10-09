using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int n = int.Parse(Console.ReadLine());

            Func<int, bool> func = x => x % n != 0;

            numbers = numbers
                .Where(func)
                .Reverse()
                .ToList();

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
