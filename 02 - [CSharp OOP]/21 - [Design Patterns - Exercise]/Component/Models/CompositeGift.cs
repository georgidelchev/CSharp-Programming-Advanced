using System;
using System.Collections.Generic;
using System.Text;
using Component.Contracts;

namespace Component.Models
{
    public class CompositeGift : GiftBase, IGiftOperations
    {
        private List<GiftBase> _gifts;

        public CompositeGift(string name, int price)
            : base(name, price)
        {
            this._gifts = new List<GiftBase>();
        }

        public override int CalculateTotalPrice()
        {
            var totalPrice = 0;

            Console.WriteLine($"{this.name} contains the following products with prices:");

            foreach (var giftBase in this._gifts)
            {
                totalPrice += giftBase.CalculateTotalPrice();
            }

            return totalPrice;
        }

        public void Add(GiftBase gift)
        {
            this._gifts.Add(gift);
        }

        public void Remove(GiftBase gift)
        {
            this._gifts.Remove(gift);
        }
    }
}
