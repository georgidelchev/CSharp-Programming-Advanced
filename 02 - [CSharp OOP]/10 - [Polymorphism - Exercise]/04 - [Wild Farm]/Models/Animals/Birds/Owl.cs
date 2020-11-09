using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Interfaces;
using WildFarm.Interfaces.Animals;

namespace WildFarm.Models.Animals.Birds
{
    public class Owl : Bird
    {
        private readonly List<string> favouriteFood = new List<string>
        {
            "Meat",
        };

        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override IReadOnlyCollection<string> FavouriteFood => this.favouriteFood;

        public override double WeightIncrease => 0.25;

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
