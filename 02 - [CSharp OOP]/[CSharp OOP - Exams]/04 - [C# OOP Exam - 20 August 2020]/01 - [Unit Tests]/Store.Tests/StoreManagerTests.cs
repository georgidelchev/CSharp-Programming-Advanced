using System;
using NUnit.Framework;

namespace Store.Tests
{
    public class StoreManagerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor_Should_Set_Products_Correctly()
        {
            var storeManager = new StoreManager();

            Assert.IsNotNull(storeManager.Products);
            Assert.That(storeManager.Products.Count, Is.EqualTo(0));
        }

        [Test]
        public void Count_Should_Return_Correct_Result()
        {
            var storeManager = new StoreManager();

            Assert.That(storeManager.Count, Is.EqualTo(0));
        }

        [Test]
        public void Add_Product_Should_Add_Product_Correctly()
        {
            var storeManager = new StoreManager();

            storeManager.AddProduct(new Product("Pizza", 10, 0.1m));

            Assert.That(storeManager.Count, Is.EqualTo(1));
        }

        [Test]
        public void Add_Product_Should_Throw_An_Exception_If_The_Product_Is_Null()
        {
            var storeManager = new StoreManager();

            storeManager.AddProduct(new Product("Pizza", 10, 0.1m));

            Assert.Throws<ArgumentNullException>(
                () => storeManager.AddProduct(null),
                "The product is not null.");
        }

        [Test]
        public void Add_Product_Should_Throw_An_Exception_If_The_Product_Quantity_Is_Equal_To_Zero()
        {
            var storeManager = new StoreManager();

            storeManager.AddProduct(new Product("Pizza", 10, 0.1m));

            Assert.Throws<ArgumentException>(
                () => storeManager.AddProduct(new Product("Pizza", 0, 0.1m)),
                "The product qty is not equal to zero.");
        }

        [Test]
        public void Add_Product_Should_Throw_An_Exception_If_The_Product_Quantity_Is_Bellow_Zero()
        {
            var storeManager = new StoreManager();

            storeManager.AddProduct(new Product("Pizza", 10, 0.1m));

            Assert.Throws<ArgumentException>(
                () => storeManager.AddProduct(new Product("Pizza", -10, 0.1m)),
                "The product qty is not bellow zero.");
        }

        [Test]
        public void Buy_Product_Should_Return_Correct_Product_Price()
        {
            var storeManager = new StoreManager();

            storeManager.AddProduct(new Product("Pizza", 10, 0.1m));

            var price = storeManager.BuyProduct("Pizza", 5);

            Assert.That(price, Is.EqualTo(0.5));
        }

        [Test]
        public void Buy_Product_Should_Throw_An_Exception_If_The_Product_Is_Null()
        {
            var storeManager = new StoreManager();

            storeManager.AddProduct(new Product("Pizza", 10, 0.1m));

            Assert.Throws<ArgumentNullException>(
                () => storeManager.BuyProduct("Salamka", 65),
                "The product is not null.");
        }

        [Test]
        public void Buy_Product_Should_Throw_An_Exception_If_The_Product_Quantity_Is_Bellow_Than_The_Wanted_Quantity()
        {
            var storeManager = new StoreManager();

            storeManager.AddProduct(new Product("Pizza", 10, 0.1m));

            Assert.Throws<ArgumentException>(
                () => storeManager.BuyProduct("Pizza", 46),
                "The product qty is not bellow than the wanted quantity.");
        }

        [Test]
        public void Get_Most_Expensive_Product_Should_Return_The_Correct_Product()
        {
            var storeManager = new StoreManager();

            storeManager.AddProduct(new Product("Pizza", 10, 0.1m));
            storeManager.AddProduct(new Product("Salami", 101, 0.5m));
            storeManager.AddProduct(new Product("Ham", 120, 1m));
            storeManager.AddProduct(new Product("Coke", 104, 3m));

            var product = storeManager.GetTheMostExpensiveProduct();

            Assert.That(product.Name, Is.EqualTo("Coke"));
            Assert.That(product.Quantity, Is.EqualTo(104));
            Assert.That(product.Price, Is.EqualTo(3));
        }
    }
}