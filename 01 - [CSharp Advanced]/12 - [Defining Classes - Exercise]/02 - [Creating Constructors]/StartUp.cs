using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var person = new Person();

            Console.WriteLine(person.Name + " " + person.Age);

            var secondPerson = new Person(15);

            Console.WriteLine(secondPerson.Name + " " + secondPerson.Age);

            var thirdPerson = new Person("Dimitrichko", 4);

            Console.WriteLine(thirdPerson.Name + " " + thirdPerson.Age);

        }
    }
}
