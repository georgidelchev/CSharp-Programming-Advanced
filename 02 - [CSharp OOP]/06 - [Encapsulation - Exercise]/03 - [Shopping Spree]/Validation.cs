using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Validation
    {
        public static void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be empty");
            }
        }

        public static void ValidateMoney(decimal money)
        {
            if (money < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
        }
    }
}
