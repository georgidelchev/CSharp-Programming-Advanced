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
                try
                {
                    var cmdArgs = Console
                    .ReadLine()
                    .Split();

                    string firstName = cmdArgs[0];
                    string lastName = cmdArgs[1];
                    int age = int.Parse(cmdArgs[2]);
                    decimal salary = decimal.Parse(cmdArgs[3]);

                    var person = new Person(firstName, lastName, age, salary);

                    persons.Add(person);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Sorting(persons);

            int percentage = int.Parse(Console.ReadLine());

            Printing(persons, percentage);
        }

        private static void Sorting(List<Person> persons)
                 => persons
                     .OrderBy(p => p.FirstName)
                     .ThenBy(p => p.Age)
                     .ToList();

        private static void Printing(List<Person> persons, int percentage)
        {
            foreach (var item in persons)
            {
                IncreaseSalaries(percentage, item);

                Console.WriteLine(item.ToString());
            }
        }

        private static void IncreaseSalaries(int percentage, Person item)
                => item
                    .IncreaseSalary(percentage);
    }
}
