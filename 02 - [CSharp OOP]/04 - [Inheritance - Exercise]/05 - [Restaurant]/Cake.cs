using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private const double defaultGrams = 250;
        private const double defaultCalories = 1000;
        private const decimal defaultCakePrice = 5;

        public Cake(string name)
            : base(name, defaultCakePrice, defaultGrams, defaultCalories)
        {
        }
    }
}
