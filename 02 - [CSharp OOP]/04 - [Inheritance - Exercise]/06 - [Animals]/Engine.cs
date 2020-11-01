using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animals
{
    public class Engine
    {
        public void Proceed()
        {
            Animal animal = null;

            var sb = new StringBuilder();

            string input = "";
            while ((input = Console.ReadLine()) != "Beast!")
            {
                var animalType = input;

                var animalArgs = Console
                    .ReadLine()
                    .Split()
                    .ToList();

                var animalName = animalArgs[0];
                var animalAge = int.Parse(animalArgs[1]);
                var animalGender = animalArgs[2];

                if (animalAge <= 0)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                animal = CreatingAnimal(animal, animalType, animalName, animalAge, animalGender);

                sb.AppendLine(animal.ToString());
            }

            Console.WriteLine(sb.ToString());
        }

        private static Animal CreatingAnimal(Animal animal, string animalType, string animalName, int animalAge, string animalGender)
        {
            switch (animalType)
            {
                case "Dog":
                    animal = new Dog(animalName, animalAge, animalGender);
                    break;
                case "Frog":
                    animal = new Frog(animalName, animalAge, animalGender);
                    break;
                case "Cat":
                    animal = new Cat(animalName, animalAge, animalGender);
                    break;
                case "Kitten":
                    animal = new Kitten(animalName, animalAge);
                    break;
                case "Tomcat":
                    animal = new Tomcat(animalName, animalAge);
                    break;
            }

            return animal;
        }
    }
}
