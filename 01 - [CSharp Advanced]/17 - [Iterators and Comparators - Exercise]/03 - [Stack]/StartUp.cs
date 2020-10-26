using System;
using System.Linq;

namespace Stack
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var myStack = new CustomStack<int>();

            string input = "";
            while ((input = Console.ReadLine()) != "END")
            {
                var splittedInput = input
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                var command = splittedInput[0];

                switch (command)
                {
                    case "Push":
                        var elements = splittedInput
                            .Skip(1)
                            .ToList();

                        foreach (var item in elements)
                        {
                            myStack.Push(int.Parse(item));
                        }
                        break;
                    case "Pop":
                        if (myStack.Count == 0)
                        {
                            Console.WriteLine("No elements");
                        }
                        else
                        {
                            myStack.Pop();
                        }
                        break;
                }
            }

            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }
            
            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
