using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class CapitalLetter
    {
        public static char[] MakeCapitalLetter(string value)
        {
            var letters = value
                            .ToCharArray();

            letters[0] = char.ToUpper(letters[0]);

            return letters;
        }
    }
}
