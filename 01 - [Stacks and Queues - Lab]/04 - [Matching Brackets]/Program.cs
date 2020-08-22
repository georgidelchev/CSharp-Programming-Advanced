using System;
using System.Collections.Generic;
using System.Linq;

namespace MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();

            var stack = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    stack.Push(i);
                }
                else if (expression[i] == ')')
                {
                    int currIndex = i;
                    int openingBracket = stack.Pop();

                    string sub = expression.Substring(openingBracket, currIndex - openingBracket + 1);
                    Console.WriteLine(sub);
                }
            }
        }
    }
}
