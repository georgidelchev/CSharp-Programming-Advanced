using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Person person = null;
            var listOfPersons = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                var input = Console
                    .ReadLine()
                    .Split()
                    .ToList();

                string name = input[0];
                int age = int.Parse(input[1]);

                person = new Person(name, age);
                listOfPersons.Add(person);
            }

            listOfPersons = listOfPersons.Where(x => x.Age > 30).OrderBy(x => x.Name).ToList();

            foreach (var item in listOfPersons)
            {
                string name = item.Name;
                int age = item.Age;

                Console.WriteLine($"{name} - {age}");
            }
        }
    }
}
