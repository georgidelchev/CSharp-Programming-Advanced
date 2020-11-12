namespace P03._ShoppingCart_After.Contracts
{
    public interface IPricingCalculator
    {
        decimal CalculatePrice(OrderItem item);
    }
}