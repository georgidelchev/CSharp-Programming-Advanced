namespace P03._ShoppingCart_After
{
    using System.Collections.Generic;
    using Contracts;

    public class Cart
    {
        private readonly List<OrderItem> items;
        private readonly IPricingCalculator pricingCalculator;

        public Cart() : this(new PricingCalculator())
        {}

        public Cart(IPricingCalculator pricingCalculator)
        {
            this.pricingCalculator = pricingCalculator;
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
                total += this.pricingCalculator.CalculatePrice(item);
            }

            return total;
        }
    }
}
