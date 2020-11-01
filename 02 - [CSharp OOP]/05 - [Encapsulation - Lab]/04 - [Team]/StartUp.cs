using System;
using System.Collections.Generic;

namespace PersonsInfo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var persons = new List<Person>();

            Team team = new Team("SoftUni");

            var lines = int.Parse(Console.ReadLine());

            for (int i = 1; i <= lines; i++)
            {
                var cmdArgs = Console
                    .ReadLine()
                    .Split();

                var firstName = cmdArgs[0];
                var lastName = cmdArgs[1];
                var age = int.Parse(cmdArgs[2]);
                var salary = decimal.Parse(cmdArgs[3]);

                var person = new Person(firstName, lastName, age, salary);

                persons.Add(person);
            }

            foreach (Person person in persons)
            {
                team.AddPlayer(person);
            }

            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
        }
    }
}
