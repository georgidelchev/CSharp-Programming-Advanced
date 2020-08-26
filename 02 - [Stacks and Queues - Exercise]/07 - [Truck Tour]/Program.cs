using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int pumpsCount = int.Parse(Console.ReadLine());

            var queue = new Queue<List<int>>();

            for (int i = 0; i < pumpsCount; i++)
            {
                var pumpArgs = Console
                    .ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToList();

                queue.Enqueue(pumpArgs);
            }

            int counter = 0;

            while (true)
            {
                int fuelAmount = 0;
                bool isFound = true;

                foreach (var item in queue)
                {
                    fuelAmount += item[0];

                    if (fuelAmount >= item[1])
                    {
                        fuelAmount -= item[1];
                    }
                    else
                    {
                        isFound = false;
                        break;
                    }
                }

                if (isFound)
                {
                    break;
                }

                counter++;

                queue.Enqueue(queue.Dequeue());
            }

            Console.WriteLine(counter);
        }
    }
}
