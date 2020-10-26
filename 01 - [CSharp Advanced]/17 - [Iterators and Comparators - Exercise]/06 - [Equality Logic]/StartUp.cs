using System;
using System.Collections.Generic;
using System.Linq;

namespace EqualityLogic
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var sortedSet = new SortedSet<Person>();
            var set = new HashSet<Person>();

            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console
                    .ReadLine()
                    .Split()
                    .ToList();

                var name = input[0];
                var age = int.Parse(input[1]);

                sortedSet.Add(new Person(name, age));
                set.Add(new Person(name, age));
            }

            Console.WriteLine(sortedSet.Count);
            Console.WriteLine(set.Count);
        }
    }
}
