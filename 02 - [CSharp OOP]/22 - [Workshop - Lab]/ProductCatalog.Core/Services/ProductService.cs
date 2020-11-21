using System;
using System.Collections.Generic;
using System.Linq;
using ProductCatalog.Core.Contracts;
using ProductCatalog.Infrastructure.Data.Common;
using ProductCatalog.Infrastructure.Data.Model;

namespace ProductCatalog.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository repo;

        public ProductService(IRepository repo)
        {
            this.repo = repo;
        }

        public IEnumerable<Product> GetProducts()
        {
            return this.repo
                .All<Product>()
                .AsEnumerable();
        }

        public void Save(Product product)
        {
            if (product.Id == 0)
            {
                this.repo.Add(product);
            }
            else
            {
                repo.Update(product);
            }

            repo.SaveChanges();
        }
    }
}
