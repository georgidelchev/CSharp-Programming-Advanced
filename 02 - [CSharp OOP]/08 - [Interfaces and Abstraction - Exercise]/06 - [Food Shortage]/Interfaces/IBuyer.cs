using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage.Interfaces
{
    public interface IBuyer
    {
        string Name { get; }

        int Food { get; set; }

        double BuyFood();
    }
}
