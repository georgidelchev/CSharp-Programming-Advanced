using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Interfaces;
using WildFarm.Interfaces.Animals;

namespace WildFarm.Models.Animals.Mammals
{
    public class Dog : Mammal
    {
        private readonly List<string> favouriteFood = new List<string>
        {
            "Meat",
        };

        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override IReadOnlyCollection<string> FavouriteFood => this.favouriteFood;

        public override double WeightIncrease => 0.40;

        public override string ProduceSound()
        {
            return "Woof!";
        }

        public override string ToString()
        {
            return $"{base.ToString()} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
