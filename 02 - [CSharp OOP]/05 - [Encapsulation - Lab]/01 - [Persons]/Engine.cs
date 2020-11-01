using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class Engine
    {
        public void Proceed()
        {
            var lines = int.Parse(Console.ReadLine());

            var persons = new List<Person>();

            for (int i = 1; i <= lines; i++)
            {
                var cmdArgs = Console
                    .ReadLine()
                    .Split();

                string firstName = cmdArgs[0];
                string lastName = cmdArgs[1];
                int age = int.Parse(cmdArgs[2]);

                var person = new Person(firstName, lastName, age);

                persons.Add(person);
            }

            Sorting(persons);

            Printing(persons);
        }

        private static void Sorting(List<Person> persons)
                 => persons
                     .OrderBy(p => p.FirstName)
                     .ThenBy(p => p.Age)
                     .ToList();

        private static void Printing(List<Person> persons)
        {
            foreach (var item in persons)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
