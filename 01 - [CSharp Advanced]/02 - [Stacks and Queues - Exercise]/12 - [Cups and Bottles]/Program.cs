using System;
using System.Collections.Generic;
using System.Linq;

namespace CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            var cupsCapacity = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var bottlesWithWaterIn = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var bottlesStack = new Stack<int>(bottlesWithWaterIn);
            var cupsQueue = new Queue<int>(cupsCapacity);

            int totalCountOfWastedWater = 0;

            while (true)
            {
                int currentBottle = bottlesStack.Peek();
                int currentCup = cupsQueue.Peek();

                if (currentCup > currentBottle)
                {
                    while (currentCup > 0)
                    {
                        int cupValueBeforeSubstraction = currentCup;

                        currentCup -= currentBottle;
                        currentBottle -= cupValueBeforeSubstraction;

                        if (currentBottle <= 0)
                        {
                            bottlesStack.Pop();

                            if (currentCup > 0)
                            {
                                currentBottle = bottlesStack.Peek();
                            }
                        }
                    }

                    if (currentBottle > 0)
                    {
                        totalCountOfWastedWater += currentBottle;
                        bottlesStack.Pop();
                    }

                    cupsQueue.Dequeue();
                }
                else
                {
                    totalCountOfWastedWater += currentBottle - currentCup;
                    bottlesStack.Pop();
                    cupsQueue.Dequeue();
                }

                if (!cupsQueue.Any())
                {
                    Console.WriteLine($"Bottles: {string.Join(" ", bottlesStack)}");
                    break;
                }

                if (!bottlesStack.Any())
                {
                    Console.WriteLine($"Cups: {string.Join(" ", cupsQueue)}");
                    break;
                }
            }

            Console.WriteLine($"Wasted litters of water: {totalCountOfWastedWater}");
        }
    }
}
