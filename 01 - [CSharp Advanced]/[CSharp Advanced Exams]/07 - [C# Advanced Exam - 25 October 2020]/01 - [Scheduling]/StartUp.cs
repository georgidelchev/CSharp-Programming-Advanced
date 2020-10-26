using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstProblem
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var tasks = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToList();

            var threads = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var taskToKill = int.Parse(Console.ReadLine());

            var threadsQueue = new Queue<int>(threads);
            var tasksStack = new Stack<int>(tasks);

            while (threadsQueue.Any() && tasksStack.Any())
            {
                int currentThread = threadsQueue.Peek();
                int currentTask = tasksStack.Peek();

                if (currentTask == taskToKill)
                {
                    Console.WriteLine($"Thread with value {currentThread} killed task {taskToKill}");
                    Console.WriteLine(string.Join(" ", threadsQueue));
                    break;
                }

                if (currentThread >= currentTask)
                {
                    threadsQueue.Dequeue();
                    tasksStack.Pop();
                }
                else
                {
                    threadsQueue.Dequeue();
                }
            }
        }
    }
}
