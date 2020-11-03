using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private readonly List<Product> bagOfProducts;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bagOfProducts = new List<Product>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                Validation.ValidateName(value);

                this.name = value;
            }
        }

        public decimal Money
        {
            get
            {
                return this.money;
            }
            private set
            {
                Validation.ValidateMoney(value);

                this.money = value;
            }
        }

        public IReadOnlyCollection<Product> BagOfProducts => this.bagOfProducts;

        public string BuyProduct(Product product)
        {
            if (this.Money < product.Cost)
            {
                return $"{this.Name} can't afford {product.Name}";
            }

            this.Money -= product.Cost;
            this.bagOfProducts.Add(product);

            return $"{this.Name} bought {product.Name}";
        }

        public override string ToString()
        {
            var productsOutput = this.BagOfProducts.Count > 0 ?
                string.Join(", ", this.BagOfProducts) :
                "Nothing bought";

            return $"{this.Name} - {productsOutput}";
        }
    }
}
