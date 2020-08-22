using System;
using System.Collections.Generic;
using System.Linq;

namespace HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console
                .ReadLine()
                .Split()
                .ToList();

            int count = int.Parse(Console.ReadLine());

            var queue = new Queue<string>(names);

            int i = 1;

            while (queue.Count > 1)
            {
                if (i == count)
                {
                    Console.WriteLine($"Removed {queue.Dequeue()}");
                    i = 0;
                }
                else
                {
                    queue.Enqueue(queue.Dequeue());
                }

                i++;
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
