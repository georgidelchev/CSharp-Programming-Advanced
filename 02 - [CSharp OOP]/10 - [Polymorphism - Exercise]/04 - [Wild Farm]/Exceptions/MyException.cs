using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WildFarm.Exceptions
{
    public class MyException
    {
        public static void CheckFood(string animalType, string foodType, IReadOnlyCollection<string> favouriteFoods)
        {
            if (!favouriteFoods.Contains(foodType))
            {
                throw new ArgumentException($"{animalType} does not eat {foodType}!");
            }
        }
    }
}
