using System;
using System.Collections.Generic;
using System.Linq;

namespace AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, List<decimal>>();

            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                var input = Console
                    .ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string name = input[0];
                decimal grade = decimal.Parse(input[1]);

                if (!dict.ContainsKey(name))
                {
                    dict[name] = new List<decimal>();
                }

                dict[name].Add(grade);
            }

            foreach (var kvp in dict)
            {
                string name = kvp.Key;
                var grades = kvp.Value;
                decimal averageGrade = grades.Average();

                Console.Write($"{name} -> ");
                
                foreach (var grade in grades)
                {
                    Console.Write($"{grade:f2} ");
                }

                Console.WriteLine($"(avg: {averageGrade:f2})");
            }
        }
    }
}
