using FoodShortage.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Engine engine = new Engine();

            engine.Proceed();
        }
    }
}
