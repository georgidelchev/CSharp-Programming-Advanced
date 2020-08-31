using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int n = list[0];
            int s = list[1];
            int x = list[2];

            var queue = new Queue<int>();

            var numbers = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            for (int i = 0; i < s; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(x))
            {
                Console.WriteLine(true.ToString().ToLower());
            }
            else
            {
                if (queue.Any())
                {
                    Console.WriteLine(queue.Min());
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
        }
    }
}
