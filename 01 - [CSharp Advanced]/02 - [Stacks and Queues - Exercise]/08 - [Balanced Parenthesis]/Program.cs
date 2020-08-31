using System;
using System.Collections.Generic;
using System.Linq;

namespace BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var stack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                char ch = input[i];

                if (stack.Any())
                {
                    if (((ch == ')' && stack.Peek() == '(') ||
                        (ch == '}' && stack.Peek() == '{') ||
                        (ch == ']' && stack.Peek() == '[')))
                    {
                        stack.Pop();
                        continue;
                    }
                }

                stack.Push(ch);
            }

            if (!stack.Any())
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
