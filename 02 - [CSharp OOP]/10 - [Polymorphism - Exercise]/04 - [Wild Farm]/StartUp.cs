using System;
using WildFarm.Core;
using WildFarm.Factories;
using WildFarm.Interfaces;
using WildFarm.Interfaces.IO;
using WildFarm.IO;

namespace WildFarm
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IReader reader = new Reader();
            IWriter writer = new Writer();

            IAnimalFactory animalFactory = new AnimalFactory();
            IFoodFactory foodFactory = new FoodFactory();

            Engine engine = new Engine(reader, writer, animalFactory, foodFactory);

            engine.Proceed();
        }
    }
}
