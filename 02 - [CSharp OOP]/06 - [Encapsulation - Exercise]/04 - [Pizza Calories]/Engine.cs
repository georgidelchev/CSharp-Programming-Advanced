using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Engine
    {
        public void Proceed()
        {
            try
            {
                var pizzaArgs = Reading();

                var pizzaName = pizzaArgs[1];

                var doughArgs = Reading();

                var doughFlourType = doughArgs[1];
                var doughBakingTechnique = doughArgs[2];
                var doughWeight = double.Parse(doughArgs[3]);

                var dough = new Dough(doughFlourType, doughBakingTechnique, doughWeight);

                var pizza = new Pizza(pizzaName, dough);

                var input = "";
                while ((input = Console.ReadLine()) != "END")
                {
                    var toppingArgs = input
                        .ToLower()
                        .Split()
                        .ToList();

                    var toppingType = toppingArgs[1];
                    var toppingWeight = double.Parse(toppingArgs[2]);

                    var topping = new Topping(toppingType, toppingWeight);

                    pizza.AddTopping(topping);
                }

                Console.WriteLine(pizza);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static List<string> Reading()
                => Console
                   .ReadLine()
                   .ToLower()
                   .Split()
                   .ToList();
    }
}
