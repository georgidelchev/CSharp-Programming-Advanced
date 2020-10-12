using System;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Person person = null;
            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                var input = Console
                    .ReadLine()
                    .Split()
                    .ToList();

                string name = input[0];
                int age = int.Parse(input[1]);

                person = new Person(name, age);
                family.AddMember(person);
            }

            Console.WriteLine(family.GetOldestMember().ToString());
        }
    }
}
