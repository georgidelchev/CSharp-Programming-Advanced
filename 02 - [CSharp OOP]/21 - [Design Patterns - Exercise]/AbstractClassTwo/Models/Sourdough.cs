using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractClassTwo.Models
{
    public class Sourdough:Bread
    {
        public override void MixIngredients()
        {
            Console.WriteLine("Gathering Ingredients for Sourdough Bread.");
        }

        public override void Bake()
        {
            Console.WriteLine("Baking the Sourdoigh Bread. (20 minutes)");
        }
    }
}
