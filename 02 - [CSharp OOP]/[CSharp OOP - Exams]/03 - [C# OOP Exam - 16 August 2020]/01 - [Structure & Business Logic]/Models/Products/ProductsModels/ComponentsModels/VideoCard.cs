namespace OnlineShop.Models.Products.ProductsModels.ComponentsModels
{
    public class VideoCard : Component
    {
        private const double MULTIPLIER = 1.15;

        public VideoCard(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation) 
            : base(id, manufacturer, model, price, overallPerformance * MULTIPLIER, generation)
        {
        }
    }
}