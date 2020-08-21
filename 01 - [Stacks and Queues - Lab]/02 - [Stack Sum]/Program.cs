using System;
using System.Collections.Generic;
using System.Linq;

namespace StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var stack = new Stack<int>(numbers);

            string input;
            while ((input = Console.ReadLine().ToLower()) != "end")
            {
                var splittedInput = input
                    .ToLower()
                    .Split()
                    .ToList();

                string command = splittedInput[0];

                switch (command)
                {
                    case "add":

                        int firstNumber = int.Parse(splittedInput[1]);
                        int secondNumber = int.Parse(splittedInput[2]);

                        stack.Push(firstNumber);
                        stack.Push(secondNumber);
                        break;
                    case "remove":
                        int indexes = int.Parse(splittedInput[1]);

                        if (stack.Count >= indexes)
                        {
                            for (int i = 0; i < indexes; i++)
                            {
                                stack.Pop();
                            }
                        }
                        break;
                }
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
