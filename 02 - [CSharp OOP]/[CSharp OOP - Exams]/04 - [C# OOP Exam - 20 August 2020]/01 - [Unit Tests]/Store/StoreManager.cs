namespace Store
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StoreManager
    {
        private const string NotPositiveQuantityExceptionMessage = "Product count can't be below or equal to zero.";
        private const string NoSuchProductExceptionMessage = "There is no such product.";
        private const string NotEnoughQuantityExceptionMessage = "There is not enough quantity of this product.";

        private readonly List<Product> products;

        public StoreManager()
        {
            this.products = new List<Product>();
        }

        public IReadOnlyCollection<Product> Products => this.products.AsReadOnly();

        public int Count => this.products.Count;

        public void AddProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            if (product.Quantity <= 0)
            {
                throw new ArgumentException(NotPositiveQuantityExceptionMessage);
            }

            this.products.Add(product);
        }

        public decimal BuyProduct(string name, int quantity)
        {
            Product product = this.products.FirstOrDefault(p => p.Name == name);

            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), NoSuchProductExceptionMessage);
            }

            if (product.Quantity < quantity)
            {
                throw new ArgumentException(NotEnoughQuantityExceptionMessage);
            }

            decimal finalPrice = product.Price * quantity;
            product.Quantity -= quantity;
            return finalPrice;
        }

        public Product GetTheMostExpensiveProduct()
        {
            Product product = this.products
                .OrderByDescending(p => p.Price)
                .FirstOrDefault();

            return product;
        }
    }
}