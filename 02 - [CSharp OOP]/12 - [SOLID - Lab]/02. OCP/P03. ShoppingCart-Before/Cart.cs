namespace P03._ShoppingCart
{
    using System.Collections.Generic;

    public class Cart
    {
        private readonly List<OrderItem> items;

        public Cart()
        {
            this.items = new List<OrderItem>();
        }

        public IEnumerable<OrderItem> Items
        {
            get { return new List<OrderItem>(this.items); }
        }

        public string CustmerEmail { get; set; }

        public void Add(OrderItem orderItem)
        {
            this.items.Add(orderItem);
        }

        public decimal TotalAmount()
        {
            decimal total = 0m;

            foreach (var item in this.items)
            {
                if (item.Sku.StartsWith("EACH"))
                {
                    total += item.Quantity * 5m;
                }
                else if (item.Sku.StartsWith("WEIGHT"))
                {
                    // quantity is in grams, price is per kg
                    total += item.Quantity * 4m / 1000;
                }
                else if (item.Sku.StartsWith("SPECIAL"))
                {
                    // $0.40 each; 3 for $1.00
                    total += item.Quantity * .4m;
                    int setsOfThree = item.Quantity / 3;
                    total -= setsOfThree * .2m;
                }

                // more rules are coming!
            }

            return total; 
        }
    }
}
