using FoodShortage.Interfaces;
using FoodShortage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodShortage.Core
{
    public class Engine
    {
        public void Proceed()
        {
            var customers = new List<IBuyer>();

            int peopleCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < peopleCount; i++)
            {
                var input = Console
                    .ReadLine()
                    .Split()
                    .ToList();

                var name = input[0];
                var age = int.Parse(input[1]);

                if (input.Count == 4) // citizen
                {
                    var id = input[2];
                    var birthdate = input[3];

                    customers.Add(new Human(name, age, id, birthdate));
                }
                else if (input.Count == 3) // rebel
                {
                    var group = input[2];

                    customers.Add(new Rebel(name, age, group));
                }
            }

            var customerName = "";
            while ((customerName = Console.ReadLine()) != "End")
            {
                if (customers.Any(x => x.Name == customerName))
                {
                    var customer = customers.Find(x => x.Name == customerName);
                    customer.BuyFood();
                }
            }

            var totalFoodBought = 0.0;

            foreach (var item in customers)
            {
                totalFoodBought += item.Food;
            }

            Console.WriteLine(totalFoodBought);
        }
    }
}
