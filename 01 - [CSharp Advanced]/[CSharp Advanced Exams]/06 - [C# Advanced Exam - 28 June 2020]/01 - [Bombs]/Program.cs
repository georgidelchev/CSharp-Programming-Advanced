using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            var bombEffects = Console
                .ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToList();

            var bombCasings = Console
                .ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToList();

            var bombEffectsQueue = new Queue<int>(bombEffects);
            var bombCasingsStack = new Stack<int>(bombCasings);

            var bombsList = new List<Bomb>
            {
                new Bomb("Datura Bombs", 40),
                new Bomb("Cherry Bombs", 60),
                new Bomb("Smoke Decoy Bombs", 120)
            };

            bool isAllBombsFilled = false;

            while (bombEffectsQueue.Any() && bombCasingsStack.Any())
            {
                int currentBombEffect = bombEffectsQueue.Peek();
                int currentBombCasing = bombCasingsStack.Peek();

                int sum = currentBombEffect + currentBombCasing;

                if (bombsList.Any(x => x.BombDamage == sum))
                {
                    bombsList.First(x => x.BombDamage == sum).BombsCount++;

                    bombEffectsQueue.Dequeue();
                    bombCasingsStack.Pop();
                }
                else
                {
                    bombCasingsStack.Push(bombCasingsStack.Pop() - 5);
                }

                if (bombsList.All(x => x.BombsCount >= 3))
                {
                    isAllBombsFilled = true;
                    
                    break;
                }
            }

            Console.WriteLine(isAllBombsFilled ?
                "Bene! You have successfully filled the bomb pouch!" :
                "You don't have enough materials to fill the bomb pouch.");

            Console.Write("Bomb Effects: ");
            Console.WriteLine(bombEffectsQueue.Any() ?
                string.Join(", ", bombEffectsQueue) :
                "empty");

            Console.Write("Bomb Casings: ");
            Console.WriteLine(bombCasingsStack.Any() ?
                string.Join(", ", bombCasingsStack) :
                "empty");

            foreach (var item in bombsList
                .OrderBy(x => x.BombName))
            {
                Console.WriteLine($"{item.BombName}: {item.BombsCount}");
            }
        }
    }

    class Bomb
    {
        public Bomb(string bombName, int bombDamage)
        {
            this.BombName = bombName;
            this.BombDamage = bombDamage;
        }

        public string BombName { get; set; }

        public int BombDamage { get; set; }

        public int BombsCount { get; set; }
    }
}
