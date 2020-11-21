using System;
using CommandPattern.Contracts;
using CommandPattern.Enumerations;
using CommandPattern.Models;

namespace CommandPattern
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var modifyPrice = new ModifyPrice();
            var product = new Product("Nokia 3010", 500);

            Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Increase, 100));

            Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Increase, 50));

            Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Decrease, 25));

            Console.WriteLine(product);
        }

        private static void Execute(Product product, ModifyPrice modifyPrice, ICommand productCommand)
        {
            modifyPrice.SetCommand(productCommand);
            modifyPrice.Invoke();
        }
    }
}
