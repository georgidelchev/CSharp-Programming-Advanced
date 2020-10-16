using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DatingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var males = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .Where(x => x % 25 != 0)
                .Where(x => x > 0)
                .ToList();

            var females = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .Where(x => x % 25 != 0)
                .Where(x => x > 0)
                .ToList();

            var femalesQueue = new Queue<int>(females);
            var malesStack = new Stack<int>(males);

            int matchesCount = 0;

            while (femalesQueue.Any() && malesStack.Any())
            {
                if (femalesQueue.Any() && malesStack.Any())
                {
                    if (femalesQueue.Peek() == malesStack.Peek())
                    {
                        femalesQueue.Dequeue();
                        malesStack.Pop();

                        matchesCount++;
                    }
                    else
                    {
                        femalesQueue.Dequeue();

                        if (malesStack.Peek() - 2 <= 0)
                        {
                            malesStack.Pop();
                        }
                        else
                        {
                            malesStack.Push(malesStack.Pop() - 2);
                        }
                    }
                }
            }

            Console.WriteLine($"Matches: {matchesCount}");

            Console.Write("Males left: ");
            Console.WriteLine(malesStack.Any() ? string.Join(", ", malesStack) : "none");

            Console.Write("Females left: ");
            Console.WriteLine(femalesQueue.Any() ? string.Join(", ", femalesQueue) : "none");
        }
    }
}
