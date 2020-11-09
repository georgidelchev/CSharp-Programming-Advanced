using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Interfaces;
using WildFarm.Interfaces.Animals;

namespace WildFarm.Models.Animals.Mammals.Felines
{
    public class Cat : Feline
    {
        private readonly List<string> favouriteFood = new List<string>
        {
            "Meat",
            "Vegetable",
        };

        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override IReadOnlyCollection<string> FavouriteFood => this.favouriteFood;

        public override double WeightIncrease => 0.30;

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
