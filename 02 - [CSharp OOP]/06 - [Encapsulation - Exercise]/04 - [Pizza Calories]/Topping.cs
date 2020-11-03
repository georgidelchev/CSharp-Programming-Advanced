using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private const double CALORIES_PER_GRAM = 2;
        private const double MINIMUM_TOPPING_WEIGHT = 1;
        private const double MAXIMUM_TOPPING_WEIGHT = 50;

        private string pizzaTopping;
        private double weight;

        private readonly Dictionary<string, double> defaultPizzaToppings = new Dictionary<string, double>
        {
            { "meat", 1.2 },
            { "veggies", 0.8 },
            { "cheese", 1.1 },
            { "sauce", 0.9 }
        };

        public Topping(string topping, double weight)
        {
            this.PizzaTopping = topping;
            this.Weight = weight;
        }

        public IReadOnlyDictionary<string, double> DefaultPizzaToppings => this.defaultPizzaToppings;

        public string PizzaTopping
        {
            get
            {
                return this.pizzaTopping;
            }
            private set
            {
                bool isToppingValid = this.DefaultPizzaToppings.ContainsKey(value.ToLower());

                if (!isToppingValid)
                {
                    throw new ArgumentException($"Cannot place {new string(CapitalLetter.MakeCapitalLetter(value))} on top of your pizza.");
                }

                this.pizzaTopping = value;
            }
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value < MINIMUM_TOPPING_WEIGHT || value > MAXIMUM_TOPPING_WEIGHT)
                {
                    throw new ArgumentException($"{new string(CapitalLetter.MakeCapitalLetter(this.PizzaTopping))} weight should be in the range [{MINIMUM_TOPPING_WEIGHT}..{MAXIMUM_TOPPING_WEIGHT}].");
                }

                this.weight = value;
            }
        }

        public double TotalCalories()
        {
            double totalCalories = this.Weight * this.DefaultPizzaToppings[this.PizzaTopping] * CALORIES_PER_GRAM;

            return totalCalories;
        }

        public override string ToString()
        {
            return $"{this.TotalCalories():f2}";
        }
    }
}
