using System;
using System.Collections.Generic;
using System.Text;
using INStock.Contracts;

namespace INStock.Models
{
    public class Product : IProduct
    {
        private string label;
        private decimal price;
        private int quantity;

        public Product(string label, decimal price, int quantity)
        {
            this.Label = label;
            this.Price = price;
            this.Quantity = quantity;
        }

        public string Label
        {
            get
            {
                return this.label;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Label name can not be null or whitespace.");
                }

                this.label = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price can not be less than zero.");
                }

                this.price = value;
            }
        }

        public int Quantity
        {
            get
            {
                return this.quantity;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Qty can not be less than zero.");
                }

                this.quantity = value;
            }
        }

        public int CompareTo(IProduct other)
        {
            var result = this.Price.CompareTo(other.Price);

            return result;
        }
    }
}
