using System;
using System.Collections.Generic;
using System.Text;
using ConsoleTables;
using ProductCatalog.Core.Contracts;
using ProductCatalog.Infrastructure.Data.Model;
using ProductCatalog.Utilities;

namespace ProductCatalog.Pages
{
    public class ProductPage
    {
        private readonly IProductService productService;

        public ProductPage(IProductService productService)
        {
            this.productService = productService;
        }

        public void Show(Menu menu)
        {
            bool running = true;

            while (running)
            {
                running = menu.ProductMenu();
            }
        }

        public void List()
        {
            var products = this.productService
                .GetProducts();

            ConsoleTable.From(products)
                .Configure(o => o.NumberAlignment = Alignment.Right)
                .Write();
        }

        public void Add()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Quantity: ");
            string qty = Console.ReadLine();

            Console.Write("Price: ");
            string price = Console.ReadLine();

            try
            {
                Product product = new Product()
                {
                    Name = name,
                    Quantity = int.Parse(qty),
                    Price = decimal.Parse(price),
                };

                this.productService.Save(product);

                Console.WriteLine("Successfully added product!");
            }
            catch (Exception)
            {
                Console.WriteLine("Product not added!");
            }
        }
    }
}
