using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            int petrolPumpsCount = int.Parse(Console.ReadLine());

            var queue = new Queue<List<int>>();

            for (int i = 0; i < petrolPumpsCount; i++)
            {
                var pumpInfo = Console
                    .ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToList();

                pumpInfo.Add(i);

                queue.Enqueue(pumpInfo);
            }

            while (true)
            {
                bool isCompleted = true;
                int totalFuel = 0;

                foreach (var item in queue)
                {
                    totalFuel += item[0];

                    if (totalFuel >= item[1])
                    {
                        totalFuel -= item[1];
                    }
                    else
                    {
                        isCompleted = false;
                        break;
                    }
                }

                if (isCompleted)
                {
                    break;
                }

                queue.Enqueue(queue.Dequeue());
            }

            var currentPump = queue.Dequeue().ToList()[2];

            Console.WriteLine(currentPump);
        }
    }
}
