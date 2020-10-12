using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var person = new Person();
            Console.WriteLine(person.Name + " " + person.Age);

            var forthPerson = new Person();
            forthPerson.Name = "Pesho";
            forthPerson.Age = 20;
            Console.WriteLine(forthPerson.Name + " " + forthPerson.Age);

            var secondPerson = new Person()
            {
                Name = "Gosho",
                Age = 18
            };
            Console.WriteLine(secondPerson.Name + " " + secondPerson.Age);

            var thirdPerson = new Person("Stamat", 43);
            Console.WriteLine(thirdPerson.Name + " " + thirdPerson.Age);

        }
    }
}
