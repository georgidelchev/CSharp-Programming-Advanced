using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQty = int.Parse(Console.ReadLine());

            var ordersQty = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var queueOrders = new Queue<int>(ordersQty);

            Console.WriteLine(queueOrders.Max());

            while (true)
            {
                if (queueOrders.Any())
                {
                    if (foodQty >= queueOrders.Peek())
                    {
                        foodQty -= queueOrders.Dequeue();
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            if (!queueOrders.Any())
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine("Orders left: " + string.Join(" ", queueOrders));
            }
        }
    }
}
