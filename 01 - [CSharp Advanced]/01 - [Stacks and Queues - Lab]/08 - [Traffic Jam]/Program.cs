using System;
using System.Collections.Generic;
using System.Text;

namespace TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int passCarsCount = int.Parse(Console.ReadLine());
            var queue = new Queue<string>();
            var sb = new StringBuilder();

            int carsCounter = 0;
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                if (input == "green")
                {
                    for (int i = 0; i < passCarsCount; i++)
                    {
                        if (queue.Count >= 1)
                        {
                            sb.AppendLine($"{queue.Dequeue()} passed!");
                            carsCounter++;
                        }
                    }
                }
                else
                {
                    queue.Enqueue(input);
                }
            }

            Console.Write(sb);
            Console.WriteLine($"{carsCounter} cars passed the crossroads.");
        }
    }
}
