using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Interfaces;
using WildFarm.Models.Foods;

namespace WildFarm.Factories
{
    class FoodFactory : IFoodFactory
    {
        public IFood CreateFood(string[] foodData)
        {
            IFood food = null;

            var type = foodData[0];
            var quantity = int.Parse(foodData[1]);

            switch (type)
            {
                case "Vegetable":
                    food = new Vegetable(quantity);
                    break;
                case "Fruit":
                    food = new Fruit(quantity);
                    break;
                case "Meat":
                    food = new Meat(quantity);
                    break;
                case "Seeds":
                    food = new Seeds(quantity);
                    break;
            }

            return food;
        }
    }
}
