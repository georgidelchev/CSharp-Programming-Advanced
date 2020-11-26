using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Models.Products.ProductsModels.PeripheralsModels
{
    public abstract class Peripheral : Product, IPeripheral
    {
        protected Peripheral(int id, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.ConnectionType = connectionType;
        }

        public string ConnectionType { get; private set; }

        public override string ToString()
        {
            return
            $"{base.ToString()} " +
            $"Connection Type: {this.ConnectionType}";
        }
    }
}