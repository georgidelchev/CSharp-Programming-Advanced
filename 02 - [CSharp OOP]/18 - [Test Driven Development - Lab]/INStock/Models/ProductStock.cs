using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using INStock.Contracts;

namespace INStock.Models
{
    public class ProductStock : IProductStock
    {
        private readonly List<IProduct> products;

        public ProductStock()
        {
            this.products = new List<IProduct>();
        }

        public int Count => this.products.Count;

        public IEnumerator<IProduct> GetEnumerator() => this.products.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public IProduct this[int index]
        {
            get
            {
                return this.Find(index);
            }
            set
            {
                if (index < 0)
                {
                    throw  new IndexOutOfRangeException("Index is under zero.");
                }
                
                if (index > this.products.Count)
                {
                    throw  new IndexOutOfRangeException("Index is above the collection size.");
                }

                this.products[index] = value;
            }
        }

        public bool Contains(IProduct product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("Product is null");
            }

            var result = this.products.Contains(product);

            return result;
        }

        public void Add(IProduct product)
        {
            if (this.products.Contains(product))
            {
                throw new ArgumentException("This product is already existing.");
            }

            if (product == null)
            {
                throw new ArgumentNullException("This product is null.");
            }

            this.products.Add(product);
        }

        public bool Remove(IProduct product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("This product is null.");
            }

            if (!this.products.Contains(product))
            {
                throw new ArgumentNullException("This product is not in the store.");
            }

            return this.products.Remove(product); ;
        }

        public IProduct Find(int index)
        {
            if (index < 0 || index > this.products.Count)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            var product = this.products[index];

            return product;
        }

        public IProduct FindByLabel(string label)
        {
            if (label == null)
            {
                throw new ArgumentNullException("Label is null.");
            }

            if (label == string.Empty)
            {
                throw new ArgumentNullException("Label is empty.");
            }

            if (label == " ")
            {
                throw new ArgumentNullException("Label is whitespace.");
            }

            if (!this.products.Any(pr => pr.Label == label))
            {
                throw new ArgumentException("Label not found.");
            }

            var result = this.products
                .FirstOrDefault(pr => pr.Label == label);

            return result;
        }

        public IProduct FindMostExpensiveProduct()
        {
            var result = this.products
                .OrderByDescending(x => x.Price)
                .First();

            return result;
        }

        public IEnumerable<IProduct> FindAllInRange(double lo, double hi)
        {
            var result = new List<IProduct>();

            foreach (var item in this.products)
            {
                if ((double)item.Price >= lo && (double)item.Price <= hi)
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public IEnumerable<IProduct> FindAllByPrice(double price)
        {
            var result = this.products.FindAll(pr => pr.Price == (decimal)price);

            return result;
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            var result = this.products.FindAll(pr => pr.Quantity == quantity);

            return result;
        }
    }
}