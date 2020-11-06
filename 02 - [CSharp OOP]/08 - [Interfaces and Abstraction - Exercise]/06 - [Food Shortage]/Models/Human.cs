using FoodShortage.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{

    public class Human : Citizen, ICheckable, IBirthdate, IBuyer
    {
        private const int FOOD_INCREASE_COUNT = 10;

        public Human(string name, int age, string id, string birthdate)
            : base(name, id)
        {
            this.Age = age;
            this.Birthdate = birthdate;
        }

        public int Age { get; private set; }

        public string Birthdate { get; }

        public int Food { get; set; }

        public double BuyFood()
        {
            return this.Food += FOOD_INCREASE_COUNT;
        }
    }
}
