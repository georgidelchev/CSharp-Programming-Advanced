namespace OnlineShop.Models.Products.ProductsModels.PeripheralsModels
{
    public class Headset : Peripheral
    {
        public Headset(int id, string manufacturer, string model, decimal price, double overallPerformance, string connectionType) 
            : base(id, manufacturer, model, price, overallPerformance, connectionType)
        {
        }
    }
}