namespace OnlineShop.Models.Products.ProductsModels.PeripheralsModels
{
    public class Mouse : Peripheral
    {
        public Mouse(int id, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
            : base(id, manufacturer, model, price, overallPerformance, connectionType)
        {
        }
    }
}