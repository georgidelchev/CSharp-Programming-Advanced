using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Interfaces;
using WildFarm.Interfaces.Animals;
using WildFarm.Models;
using WildFarm.Models.Animals.Birds;
using WildFarm.Models.Animals.Mammals;
using WildFarm.Models.Animals.Mammals.Felines;

namespace WildFarm.Factories
{
    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal CreateAnimal(string[] animalData)
        {
            IAnimal animal = null;

            var type = animalData[0];
            var name = animalData[1];
            var weight = double.Parse(animalData[2]);

            switch (type)
            {
                case "Owl":
                case "Hen":
                    var wingSize = double.Parse(animalData[3]);

                    if (type == "Owl")
                    {
                        animal = new Owl(name, weight, wingSize);
                    }
                    else if (type == "Hen")
                    {
                        animal = new Hen(name, weight, wingSize);
                    }
                    break;
                case "Mouse":
                case "Dog":
                case "Cat":
                case "Tiger":
                    var livingRegion = animalData[3];

                    if (type == "Mouse")
                    {
                        animal = new Mouse(name, weight, livingRegion);
                    }
                    else if (type == "Dog")
                    {
                        animal = new Dog(name, weight, livingRegion);
                    }
                    else if (type == "Cat" || type == "Tiger")
                    {
                        var breed = animalData[4];

                        if (type == "Cat")
                        {
                            animal = new Cat(name, weight, livingRegion, breed);
                        }
                        else if (type == "Tiger")
                        {
                            animal = new Tiger(name, weight, livingRegion, breed);
                        }
                    }
                    break;
            }

            return animal;
        }
    }
}
