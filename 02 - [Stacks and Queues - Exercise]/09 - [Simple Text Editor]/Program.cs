using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int operationsCount = int.Parse(Console.ReadLine());

            var undoCommands = new Stack<string>();

            string text = "";

            for (int i = 0; i < operationsCount; i++)
            {
                var input = Console
                    .ReadLine()
                    .Split()
                    .ToList();

                string command = input[0];

                switch (command)
                {
                    case "1":
                        string str = input[1];

                        undoCommands.Push(text);
                        text += str;
                        break;
                    case "2":
                        int count = int.Parse(input[1]);

                        undoCommands.Push(text);
                        text = text.Substring(0, text.Length - count);
                        break;
                    case "3":
                        int index = int.Parse(input[1]);

                        Console.WriteLine(text[index - 1]);
                        break;
                    case "4":
                        text = undoCommands.Pop();
                        break;
                }
            }
        }
    }
}
