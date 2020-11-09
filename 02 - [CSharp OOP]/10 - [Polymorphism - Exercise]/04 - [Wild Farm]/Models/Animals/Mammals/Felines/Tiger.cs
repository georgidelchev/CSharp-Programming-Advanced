using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Exceptions;
using WildFarm.Interfaces;
using WildFarm.Interfaces.Animals;

namespace WildFarm.Models.Animals.Mammals.Felines
{
    public class Tiger : Feline
    {
        private readonly List<string> favouriteFood = new List<string>
        {
            "Meat",
        };

        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override IReadOnlyCollection<string> FavouriteFood => this.favouriteFood;

        public override double WeightIncrease => 1.00;

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
