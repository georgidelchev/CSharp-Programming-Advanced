using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WildFarm.Interfaces;
using WildFarm.Interfaces.Animals;
using WildFarm.Interfaces.IO;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IAnimalFactory animalFactory;
        private readonly IFoodFactory foodFactory;
        private readonly List<IAnimal> animalsList;

        public Engine(IReader reader, IWriter writer, IAnimalFactory animalFactory, IFoodFactory foodFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.animalFactory = animalFactory;
            this.foodFactory = foodFactory;
            this.animalsList = new List<IAnimal>();
        }

        private IReadOnlyCollection<IAnimal> AnimalsList => this.animalsList;

        public void Proceed()
        {
            IAnimal animal = null;
            IFood food = null;

            var input = "";
            while ((input = this.reader.ReadLine()) != "End")
            {
                var animalData = input
                    .Split()
                    .ToArray();

                var foodData = this.reader
                    .ReadLine()
                    .Split()
                    .ToArray();

                animal = this.animalFactory.CreateAnimal(animalData);

                this.animalsList.Add(animal);

                food = this.foodFactory.CreateFood(foodData);

                this.writer.WriteLine(animal.ProduceSound());

                try
                {
                    animal.Eat(food);
                }
                catch (ArgumentException e)
                {
                    this.writer.WriteLine(e.Message);
                }
            }

            Print();
        }

        private void Print()
        {
            foreach (var item in this.AnimalsList)
            {
                this.writer.WriteLine(item.ToString());
            }
        }
    }
}
