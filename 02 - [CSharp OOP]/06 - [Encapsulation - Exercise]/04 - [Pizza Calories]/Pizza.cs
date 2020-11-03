using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private const int MINIMUM_PIZZA_NAME_SYMBOLS = 1;
        private const int MAXIMUM_PIZZA_NAME_SYMBOLS = 15;

        private const int MINIMUM_TOPPINGS_COUNT = 0;
        private const int MAXIMUM_TOPPINGS_COUNT = 10;

        private readonly List<Topping> toppingsList;

        private string name;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;

            this.toppingsList = new List<Topping>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) ||
                    value.Length < MINIMUM_PIZZA_NAME_SYMBOLS ||
                    value.Length > MAXIMUM_PIZZA_NAME_SYMBOLS)
                {
                    throw new ArgumentException($"Pizza name should be between {MINIMUM_PIZZA_NAME_SYMBOLS} and {MAXIMUM_PIZZA_NAME_SYMBOLS} symbols.");
                }

                this.name = value;
            }
        }

        public Dough Dough { get; set; }

        public Topping Topping { get; private set; }

        public IReadOnlyCollection<Topping> ToppingsList => this.toppingsList;

        public double TotalCalories => this.Dough.TotalCalories() + this.TotalToppingsCalories();

        public void AddTopping(Topping topping)
        {
            if (this.ToppingsList.Count < MINIMUM_TOPPINGS_COUNT ||
                this.ToppingsList.Count > MAXIMUM_TOPPINGS_COUNT)
            {
                throw new ArgumentException($"Number of toppings should be in range [{MINIMUM_TOPPINGS_COUNT}..{MAXIMUM_TOPPINGS_COUNT}].");
            }

            this.toppingsList.Add(topping);
        }

        private double TotalToppingsCalories()
        {
            double totalToppingsCalories = 0;

            foreach (var item in this.toppingsList)
            {
                totalToppingsCalories += item.TotalCalories();
            }

            return totalToppingsCalories;
        }

        public override string ToString()
        {
            this.Name = new string(CapitalLetter.MakeCapitalLetter(this.Name));

            return $"{this.Name} - {this.TotalCalories:f2} Calories.";
        }
    }
}
