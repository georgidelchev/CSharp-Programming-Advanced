using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var stack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i]);
            }

            while (stack.Any())
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
