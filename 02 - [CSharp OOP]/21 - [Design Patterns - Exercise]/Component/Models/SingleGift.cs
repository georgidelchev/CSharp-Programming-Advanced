using System;
using System.Collections.Generic;
using System.Text;

namespace Component.Models
{
    public class SingleGift : GiftBase
    {
        public SingleGift(string name, int price)
            : base(name, price)
        {
        }

        public override int CalculateTotalPrice()
        {
            Console.WriteLine($"{this.name} with the price {this.price}");

            return price;
        }
    }
}
