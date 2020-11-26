namespace OnlineShop.Models.Products.ProductsModels.ComputersModels
{
    public class Laptop : Computer
    {
        private const int OVERALL_PERFORMANCE = 10;

        public Laptop(int id, string manufacturer, string model, decimal price)
            : base(id, manufacturer, model, price, OVERALL_PERFORMANCE)
        {
        }
    }
}