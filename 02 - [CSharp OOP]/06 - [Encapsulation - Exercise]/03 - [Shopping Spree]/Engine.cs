using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree
{
    public class Engine
    {
        public void Proceed()
        {
            var people = Reading();

            var products = Reading();

            var peopleList = new List<Person>();
            var productsList = new List<Product>();

            try
            {
                ParsePeopleInput(people, peopleList);
                ParseProductsInput(products, productsList);

                BuyProduct(peopleList, productsList);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static List<string> Reading()
                 => Console
                    .ReadLine()
                    .Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

        private static void ParsePeopleInput(List<string> people, List<Person> peopleList)
        {
            for (int i = 0; i < people.Count; i += 2)
            {
                var name = people[i];
                var money = decimal.Parse(people[i + 1]);

                var person = new Person(name, money);

                peopleList.Add(person);
            }
        }

        private static void ParseProductsInput(List<string> products, List<Product> productsList)
        {
            for (int i = 0; i < products.Count; i += 2)
            {
                var name = products[i];
                var money = decimal.Parse(products[i + 1]);

                var product = new Product(name, money);

                productsList.Add(product);
            }
        }

        private static void BuyProduct(List<Person> peopleList, List<Product> productsList)
        {
            var sb = new StringBuilder();

            var input = "";
            while ((input = Console.ReadLine()) != "END")
            {
                var splitted = input
                    .Split()
                    .ToList();

                var personName = splitted[0];
                var productName = splitted[1];

                var person = peopleList
                    .FirstOrDefault(x => x.Name == personName);

                var product = productsList
                    .FirstOrDefault(x => x.Name == productName);

                sb.AppendLine(person.BuyProduct(product));
            }

            Print(sb, peopleList);
        }

        private static void Print(StringBuilder sb, List<Person> peopleList)
        {
            Console.Write(sb.ToString());

            foreach (var item in peopleList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
