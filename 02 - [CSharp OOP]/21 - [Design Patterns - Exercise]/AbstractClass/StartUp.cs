using System;
using AbstractClass.Models;

namespace AbstractClass
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var sandwichMenu = new SandwichMenu();

            sandwichMenu["BLT"] = new Sandwich("Wheat", "Bacon", "", "Lettuce, Tomato");
            sandwichMenu["PB&J"] = new Sandwich("White", "", "", "Peanut Butter, Jelly");
            sandwichMenu["Turkey"] = new Sandwich("Rye", "Turkey", "Swiss", "Lettuce, Onion, Tomato");

            var sandwich1 = sandwichMenu["BLT"].Clone() as Sandwich;
            var sandwich2 = sandwichMenu["PB&J"].Clone() as Sandwich;
            var sandwich3 = sandwichMenu["Turkey"].Clone() as Sandwich;
        }
    }
}
