using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            var clothesList = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int rackCapacity = int.Parse(Console.ReadLine());

            var stack = new Stack<int>(clothesList);

            int racksCount = 1;
            int clothes = 0;

            while (stack.Any())
            {
                if (rackCapacity < (clothes + stack.Peek()))
                {
                    clothes = 0;
                    racksCount++;
                }

                clothes += stack.Pop();
            }

            Console.WriteLine(racksCount);
        }
    }
}
