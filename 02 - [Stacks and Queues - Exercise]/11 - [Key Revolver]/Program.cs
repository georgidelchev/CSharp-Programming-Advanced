using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());

            var bullets = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var locks = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int intelligenceValue = int.Parse(Console.ReadLine());

            var bulletsStack = new Stack<int>(bullets);
            var locksQueue = new Queue<int>(locks);

            int shotedBulletsCount = 0;
            int totalShotedBulletsCount = 0;

            while (true)
            {
                int currentBullet = bulletsStack.Peek();
                int currentLock = locksQueue.Peek();

                if (currentBullet <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    locksQueue.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                shotedBulletsCount++;
                totalShotedBulletsCount++;
                bulletsStack.Pop();

                if (shotedBulletsCount == gunBarrelSize && bulletsStack.Any())
                {
                    Console.WriteLine("Reloading!");
                    shotedBulletsCount = 0;
                }

                if (!bulletsStack.Any() && locksQueue.Any())
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count()}");
                    break;
                }

                if (!locksQueue.Any())
                {
                    int moneyEarned = intelligenceValue - (totalShotedBulletsCount * bulletPrice);
                    Console.WriteLine($"{bulletsStack.Count} bullets left. Earned ${moneyEarned}");
                    break;
                }
            }
        }
    }
}
