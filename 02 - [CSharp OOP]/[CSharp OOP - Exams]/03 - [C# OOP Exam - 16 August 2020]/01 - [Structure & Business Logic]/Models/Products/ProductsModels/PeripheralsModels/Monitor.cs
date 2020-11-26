namespace OnlineShop.Models.Products.ProductsModels.PeripheralsModels
{
    public class Monitor : Peripheral
    {
        public Monitor(int id, string manufacturer, string model, decimal price, double overallPerformance, string connectionType) 
            : base(id, manufacturer, model, price, overallPerformance, connectionType)
        {
        }
    }
}