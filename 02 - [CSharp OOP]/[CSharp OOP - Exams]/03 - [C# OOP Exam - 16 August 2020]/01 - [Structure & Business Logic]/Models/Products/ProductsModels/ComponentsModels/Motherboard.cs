namespace OnlineShop.Models.Products.ProductsModels.ComponentsModels
{
    public class Motherboard : Component
    {
        private const double MULTIPLIER = 1.25;

        public Motherboard(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation) 
            : base(id, manufacturer, model, price, overallPerformance, generation)
        {
        }

        public override double OverallPerformance
            => base.OverallPerformance * MULTIPLIER;
    }
}