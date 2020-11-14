using System;
using System.Collections.Generic;
using System.Text;
using ValidationAttributes.Models;

namespace ValidationAttributes.Core
{
    public class Engine : IEngine
    {
        public void Proceed()
        {
            Person person = null;
            bool isValidEntity = false;
            var value = 0;

            var random = new Random();

            for (int i = 1; i <= 50; i++)
            {
                value = random.Next(-100, 200);

                person = new Person("Stavri", value);

                isValidEntity = Validator.IsValid(person);

                Console.WriteLine($"Person:{person.FullName}{Environment.NewLine}" +
                    $"Age:{person.Age}{Environment.NewLine}" +
                    $"State:{isValidEntity}");

                Console.WriteLine();
            }
        }
    }
}
