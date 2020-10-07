using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var persons = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                var input = Console
                    .ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string name = input[0];
                int age = int.Parse(input[1]);

                Person person = new Person(name, age);

                persons.Add(person);
            }

            string condition = Console.ReadLine();
            int ageFormat = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<Person, bool> conditionFilter = condition switch
            {
                "younger" => p => p.Age < ageFormat,
                "older" => p => p.Age >= ageFormat,
                _ => null
            };

            Func<Person, string> formatFilter = format switch
            {
                "name" => f => $"{f.Name}",
                "age" => f => $"{f.Age}",
                "name age" => f => $"{f.Name} - {f.Age}",
                _ => null
            };

            persons
                .Where(conditionFilter)
                .Select(formatFilter)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }

    class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
}
