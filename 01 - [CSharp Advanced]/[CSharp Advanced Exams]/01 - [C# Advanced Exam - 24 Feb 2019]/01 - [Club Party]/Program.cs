using System;
using System.Collections.Generic;
using System.Linq;

namespace ClubParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int hallsMaxCapacity = int.Parse(Console.ReadLine());

            var input = Console
                .ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var elements = new Stack<string>(input);
            var hallsList = new Queue<string>();

            var nums = new List<int>();

            int capacity = 0;

            while (elements.Any())
            {
                string currentElement = elements.Pop();
                int currentReservationCount = 0;

                bool isNumber = int.TryParse(currentElement, out currentReservationCount);

                if (!isNumber)
                {
                    hallsList.Enqueue(currentElement);
                }
                else
                {
                    if (!hallsList.Any())
                    {
                        continue;
                    }

                    if (capacity + currentReservationCount > hallsMaxCapacity)
                    {
                        Console.WriteLine($"{hallsList.Dequeue()} -> {string.Join(", ", nums)}");
                        capacity = 0;
                        nums.Clear();
                    }

                    if (hallsList.Any())
                    {
                        capacity += currentReservationCount;
                        nums.Add(currentReservationCount);
                    }
                }
            }
        }
    }
}
