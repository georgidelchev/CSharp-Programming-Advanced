using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new SortedDictionary<string, Dictionary<string, double>>();

            string input = "";
            while ((input = Console.ReadLine()) != "Revision")
            {
                var splittedInput = input
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string shopName = splittedInput[0];
                string productName = splittedInput[1];
                double productPrice = double.Parse(splittedInput[2]);

                if (!dict.ContainsKey(shopName))
                {
                    dict[shopName] = new Dictionary<string, double>();
                }

                dict[shopName][productName] = productPrice;
            }

            foreach (var shopNames in dict)
            {
                string shopName = shopNames.Key;

                Console.WriteLine($"{shopName}->");

                foreach (var productNames in shopNames.Value)
                {
                    string productName = productNames.Key;
                    double productPrice = productNames.Value;

                    Console.WriteLine($"Product: {productName}, Price: {productPrice}");
                }
            }
        }
    }
}
