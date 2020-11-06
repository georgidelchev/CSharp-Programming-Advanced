using FoodShortage.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage.Models
{
    public class Rebel : IBuyer
    {
        private const int FOOD_INCREASE_COUNT = 5;

        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
        }

        public string Name { get; private set; }

        public int Age { get; }

        public string Group { get; private set; }

        public int Food { get; set; }

        public double BuyFood()
        {
            return this.Food += FOOD_INCREASE_COUNT;
        }
    }
}
