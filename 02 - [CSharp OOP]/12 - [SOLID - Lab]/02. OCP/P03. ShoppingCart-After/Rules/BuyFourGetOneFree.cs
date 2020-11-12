namespace P03._ShoppingCart_After.Rules
{
    using Contracts;

    public class BuyFourGetOneFree : IPriceRule
    {
        public decimal CalculatePrice(OrderItem item)
        {
            decimal total = 0m;

            total += item.Quantity * 1m;
            int setsOfFive = item.Quantity / 5;
            total -= setsOfFive * 1m;

            return total;
        }

        public bool IsMatch(OrderItem item)
        {
            return item.Sku.StartsWith("BFGO");
        }
    }
}