namespace Store
{
    public class Product
    {
        public Product(string name, int quantity, decimal price)
        {
            this.Name = name;
            this.Quantity = quantity;
            this.Price = price;
        }

        public string Name { get; }

        public int Quantity { get; set; }

        public decimal Price { get; }
    }
}