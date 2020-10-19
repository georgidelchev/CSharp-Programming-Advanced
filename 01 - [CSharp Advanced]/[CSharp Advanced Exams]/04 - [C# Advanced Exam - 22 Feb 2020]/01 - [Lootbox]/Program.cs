using System;
using System.Collections.Generic;
using System.Linq;

namespace Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstLootBox = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var secondLootBox = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var firstBoxQueue = new Queue<int>(firstLootBox);
            var secondBoxStack = new Stack<int>(secondLootBox);

            var claimedItems = new List<int>();

            while (firstBoxQueue.Any() && secondBoxStack.Any())
            {
                int firstBoxItem = firstBoxQueue.Peek();
                int secondBoxItem = secondBoxStack.Peek();

                int itemsSum = firstBoxItem + secondBoxItem;

                if (itemsSum % 2 == 0)
                {
                    claimedItems.Add(itemsSum);

                    firstBoxQueue.Dequeue();
                    secondBoxStack.Pop();
                }
                else
                {
                    secondBoxStack.Pop();
                    firstBoxItem.Equals(secondBoxItem);
                }
            }

            if (!firstBoxQueue.Any())
            {
                Console.WriteLine("First lootbox is empty");
            }
            else if (!secondBoxStack.Any())
            {
                Console.WriteLine("Second lootbox is empty");
            }

            int claimedItemsSum = claimedItems.Sum();

            Console.WriteLine(claimedItemsSum >= 100 ?
                $"Your loot was epic! Value: {claimedItemsSum}" :
                $"Your loot was poor... Value: {claimedItemsSum}");
        }
    }
}
