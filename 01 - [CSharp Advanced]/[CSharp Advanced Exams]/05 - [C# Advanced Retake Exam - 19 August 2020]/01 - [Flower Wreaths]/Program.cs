using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstSequence = Console
                .ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToList();

            var secondSequence = Console
                .ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToList();

            var lilies = new Stack<int>(secondSequence);
            var roses = new Queue<int>(firstSequence);

            int wreathsCount = 0;
            int storedFlowers = 0;

            while (lilies.Any() && roses.Any())
            {
                int firstLilie = lilies.Peek();
                int firstRose = roses.Peek();

                int flowersSum = firstLilie + firstRose;

                if (flowersSum == 15)
                {
                    lilies.Pop();
                    roses.Dequeue();

                    wreathsCount++;
                }
                else if (flowersSum >= 15)
                {
                    lilies.Push(lilies.Pop() - 2);
                }
                else
                {
                    storedFlowers += lilies.Pop() + roses.Dequeue();
                }
            }

            wreathsCount += storedFlowers / 15;

            Console.WriteLine(wreathsCount >= 5 ?
                $"You made it, you are going to the competition with {wreathsCount} wreaths!" :
                $"You didn't make it, you need {5 - wreathsCount} wreaths more!");
        }
    }
}
