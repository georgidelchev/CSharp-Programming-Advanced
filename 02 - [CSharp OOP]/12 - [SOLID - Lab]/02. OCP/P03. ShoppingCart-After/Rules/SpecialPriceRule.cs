namespace P03._ShoppingCart_After.Rules
{
    using Contracts;

    public class SpecialPriceRule : IPriceRule
    {
        public decimal CalculatePrice(OrderItem item)
        {
            decimal sum = item.Quantity * .4m;
            int setsOfThree = item.Quantity / 3;
            sum -= setsOfThree * .2m;

            return sum;
        }

        public bool IsMatch(OrderItem item)
        {
            return item.Sku.StartsWith("SPECIAL");
        }
    }
}