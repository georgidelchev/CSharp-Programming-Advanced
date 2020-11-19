using System;
using System.Linq;
using INStock.Models;
using NUnit.Framework;

namespace INStock.Tests
{
    [TestFixture]
    public class ProductStockTests
    {
        private const string PRODUCT_LABEL = "Label";
        private const string ANOTHER_PRODUCT_LABEL = "Label1";

        private ProductStock productStock;

        private Product firstProduct;
        private Product secondProduct;

        [SetUp]
        public void SetUpProduct()
        {
            // Arrange
            this.productStock = new ProductStock();
            this.firstProduct = new Product(PRODUCT_LABEL, 10, 1);
            this.secondProduct = new Product(ANOTHER_PRODUCT_LABEL, 5, 10);
        }

        [Test]
        public void Count_Should_Return_Correct_Products_Count_1()
        {
            // Act
            this.productStock.Add(this.firstProduct);
            this.productStock.Add(this.secondProduct);

            var actualCount = this.productStock.Count;
            var expectedCount = 2;

            // Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Count_Should_Return_Correct_Products_Count_2()
        {
            // Act
            this.productStock.Add(this.firstProduct);

            var actualCount = this.productStock.Count;
            var expectedCount = 1;

            // Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Add_Product_Should_Add_Correctly()
        {
            // Act
            this.productStock.Add(firstProduct);
            var result = productStock.FindByLabel(PRODUCT_LABEL);

            // Assert
            Assert.That(this.productStock.Count, Is.Not.Null);
            Assert.That(result.Label, Is.EqualTo(this.firstProduct.Label));
            Assert.That(result.Price, Is.EqualTo(this.firstProduct.Price));
            Assert.That(result.Quantity, Is.EqualTo(this.firstProduct.Quantity));
        }

        [Test]
        public void Add_Two_Products_Should_Add_Them_Correctly()
        {
            // Act
            this.productStock.Add(firstProduct);
            this.productStock.Add(secondProduct);

            var firstSearch = productStock.FindByLabel(PRODUCT_LABEL);
            var secondSearch = productStock.FindByLabel(ANOTHER_PRODUCT_LABEL);

            // Assert
            Assert.That(this.productStock.Count, Is.Not.Null);
            Assert.That(firstSearch.Label, Is.EqualTo(this.firstProduct.Label));
            Assert.That(firstSearch.Price, Is.EqualTo(this.firstProduct.Price));
            Assert.That(firstSearch.Quantity, Is.EqualTo(this.firstProduct.Quantity));

            Assert.That(this.productStock.Count, Is.Not.Null);
            Assert.That(secondSearch.Label, Is.EqualTo(this.secondProduct.Label));
            Assert.That(secondSearch.Price, Is.EqualTo(this.secondProduct.Price));
            Assert.That(secondSearch.Quantity, Is.EqualTo(this.secondProduct.Quantity));
        }

        [Test]
        public void Add_Null_Product_Should_Throw_An_Exception()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(
                () => this.productStock.Add(null), // Act
                "The product is not null.");
        }

        [Test]
        public void Add_Duplicated_Products_Should_Throw_An_Exception()
        {
            // Assert
            Assert.Throws<ArgumentException>(
                () =>
                {
                    this.productStock.Add(this.firstProduct);
                    this.productStock.Add(this.firstProduct);
                }, // Act
                "Products are not same.");
        }

        [Test]
        public void Remove_Should_Throw_An_Exception_If_Product_Is_Null()
        {
            // Act
            this.productStock.Add(firstProduct);

            // Assert
            Assert.Throws<ArgumentNullException>(
                () => this.productStock.Remove(null), // Act
                "Product is not null.");
        }

        [Test]
        public void Remove_Should_Throw_An_Exception_If_Product_Is_Not_In_The_Stock()
        {
            // Act
            this.productStock.Add(secondProduct);

            // Assert
            Assert.Throws<ArgumentNullException>(
                () => this.productStock.Remove(this.firstProduct), // Act
                "Product is in the stock.");
        }

        [Test]
        public void Remove_Should_Return_True_If_The_Product_Is_Removes_Successfully()
        {
            // Act
            this.productStock.Add(this.firstProduct);

            var result = this.productStock.Remove(this.firstProduct);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void Contains_Should_Return_True_If_The_Product_Is_Existing()
        {
            // Act
            this.productStock.Add(this.firstProduct);

            var result = this.productStock.Contains(this.firstProduct);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void Contains_Should_Return_False_If_The_Product_Is_Not_Existing()
        {
            // Act
            this.productStock.Add(this.secondProduct);

            var result = this.productStock.Contains(this.firstProduct);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void Contains_Should_Throw_An_Exception_If_The_Product_Is_Null()
        {
            // Act
            this.productStock.Add(this.firstProduct);
            this.productStock.Add(this.secondProduct);

            // Assert
            Assert.Throws<ArgumentNullException>(
                () => this.productStock.Contains(null), // Act
                "The product is not null.");
        }

        [Test]
        public void Find_Should_Return_Correct_Result_By_Index()
        {
            // Act
            this.productStock.Add(this.firstProduct);
            this.productStock.Add(this.secondProduct);

            var result = this.productStock.Find(1);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Label, Is.EqualTo(this.secondProduct.Label));
            Assert.That(result.Price, Is.EqualTo(this.secondProduct.Price));
            Assert.That(result.Quantity, Is.EqualTo(this.secondProduct.Quantity));
        }

        [Test]
        public void Find_Should_Throw_An_Exception_If_The_Index_Is_Out_Of_Range()
        {
            // Act
            this.productStock.Add(this.firstProduct);
            this.productStock.Add(this.secondProduct);

            // Assert
            Assert.Throws<IndexOutOfRangeException>(
                () => this.productStock.Find(3),
                "The index is in range.");
        }

        [Test]
        public void Find_By_Label_Should_Return_Correct_Product_By_Label()
        {
            // Act
            this.productStock.Add(this.firstProduct);
            this.productStock.Add(this.secondProduct);

            var result = this.productStock.FindByLabel(this.secondProduct.Label);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Label, Is.EqualTo(this.secondProduct.Label));
            Assert.That(result.Price, Is.EqualTo(this.secondProduct.Price));
            Assert.That(result.Quantity, Is.EqualTo(this.secondProduct.Quantity));
        }

        [Test]
        public void Find_By_Label_Should_Throw_An_Exception_If_Value_Is_Null()
        {
            // Act
            this.productStock.Add(this.firstProduct);
            this.productStock.Add(this.secondProduct);

            // Assert
            Assert.Throws<ArgumentNullException>(
                () => this.productStock.FindByLabel(null));
        }

        [Test]
        public void Find_By_Label_Should_Throw_An_Exception_If_Value_Is_Empty()
        {
            // Act
            this.productStock.Add(this.firstProduct);
            this.productStock.Add(this.secondProduct);

            // Assert
            Assert.Throws<ArgumentNullException>(
                () => this.productStock.FindByLabel(string.Empty));
        }

        [Test]
        public void Find_By_Label_Should_Throw_An_Exception_If_Value_Is_Whitespace()
        {
            // Act
            this.productStock.Add(this.firstProduct);
            this.productStock.Add(this.secondProduct);

            // Assert
            Assert.Throws<ArgumentNullException>(
                () => this.productStock.FindByLabel(" "));
        }

        [Test]
        public void Find_By_Label_Should_Throw_An_Exception_If_Value_Is_Not_Existing()
        {
            // Act
            this.productStock.Add(this.firstProduct);
            this.productStock.Add(this.secondProduct);

            // Assert
            Assert.Throws<ArgumentException>(
                () => this.productStock.FindByLabel("Banana"));
        }

        [Test]
        public void Find_All_In_Range_Should_Return_Empty_Collection_If_Products_Doesnt_Match()
        {
            // Act
            this.AddMultipleProductsToProductStock();

            var result = this.productStock.FindAllInRange(100, 200);

            // Assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void Find_All_In_Range_Should_Return_Collection_In_Correct_Order_By_Label()
        {
            // Act
            this.AddMultipleProductsToProductStock();

            var result = this.productStock
                .FindAllInRange(1, 11)
                .ToList();

            // Assert
            Assert.That(result.Count, Is.EqualTo(3));

            Assert.That(result[0].Label, Is.EqualTo("1"));
            Assert.That(result[1].Label, Is.EqualTo("2"));
            Assert.That(result[2].Label, Is.EqualTo("4"));
        }

        [Test]
        public void Find_All_In_Range_Should_Return_Collection_In_Correct_Order_By_Price()
        {
            // Act
            this.AddMultipleProductsToProductStock();

            var result = this.productStock
                .FindAllInRange(1, 11)
                .ToList();

            // Assert
            Assert.That(result.Count, Is.EqualTo(3));

            Assert.That(result[0].Price, Is.EqualTo(10));
            Assert.That(result[1].Price, Is.EqualTo(5));
            Assert.That(result[2].Price, Is.EqualTo(3));
        }

        [Test]
        public void Find_All_In_Range_Should_Return_Collection_In_Correct_Order_By_Qty()
        {
            // Act
            this.AddMultipleProductsToProductStock();

            var result = this.productStock
                .FindAllInRange(1, 11)
                .ToList();

            // Assert
            Assert.That(result.Count, Is.EqualTo(3));

            Assert.That(result[0].Quantity, Is.EqualTo(5));
            Assert.That(result[1].Quantity, Is.EqualTo(60));
            Assert.That(result[2].Quantity, Is.EqualTo(18));
        }

        [Test]
        public void Find_All_By_Price_Should_Return_Empty_Collection_If_Products_Doesnt_Match()
        {
            // Act
            this.AddMultipleProductsToProductStock();

            var result = this.productStock
                .FindAllByPrice(161)
                .ToList();

            // Assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void Find_All_By_Price_Should_Return_Collection_With_Matched_Products()
        {
            // Act
            this.AddMultipleProductsToProductStock();

            var result = this.productStock
                .FindAllByPrice(15)
                .ToList();

            // Assert
            Assert.That(result.Count, Is.EqualTo(2));

            Assert.That(result[0].Label, Is.EqualTo("3"));
            Assert.That(result[1].Label, Is.EqualTo("6"));
        }

        [Test]
        public void Find_Most_Expensive_Product_Should_Return_Correct_Result()
        {
            // Arrange
            this.AddMultipleProductsToProductStock();

            // Act
            var result = this.productStock.FindMostExpensiveProduct();

            // Assert
            Assert.That(result, Is.Not.Null);

            Assert.That(result.Label, Is.EqualTo("7"));
            Assert.That(result.Price, Is.EqualTo(50));
            Assert.That(result.Quantity, Is.EqualTo(7));
        }

        [Test]
        public void Find_Most_Expensive_Product_Should_Throw_An_Exception_If_Collection_Is_Empty()
        {
            // Assert
            Assert.Throws<InvalidOperationException>(
                () => this.productStock.FindMostExpensiveProduct(), // Act
                "The collection is not empty.");
        }

        [Test]
        public void Find_All_By_Quantity_Should_Return_Empty_Collection_If_Products_Doesnt_Match()
        {
            // Act
            this.AddMultipleProductsToProductStock();

            var result = this.productStock
                .FindAllByQuantity(16111)
                .ToList();

            // Assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void Find_All_By_Quantity_Should_Return_Collection_In_Correct_Order_By_Label()
        {
            // Act
            this.AddMultipleProductsToProductStock();

            var result = this.productStock
                .FindAllByQuantity(7)
                .ToList();

            // Assert
            Assert.That(result.Count, Is.EqualTo(2));

            Assert.That(result[0].Label, Is.EqualTo("5"));
            Assert.That(result[1].Label, Is.EqualTo("7"));
        }

        [Test]
        public void Find_All_By_Quantity_Should_Return_Collection_In_Correct_Order_By_Price()
        {
            // Act
            this.AddMultipleProductsToProductStock();

            var result = this.productStock
                .FindAllByQuantity(7)
                .ToList();

            // Assert
            Assert.That(result.Count, Is.EqualTo(2));

            Assert.That(result[0].Price, Is.EqualTo(25));
            Assert.That(result[1].Price, Is.EqualTo(50));
        }

        [Test]
        public void Get_Enumerator_Should_Return_All_Products_By_Label()
        {
            // Act
            this.AddMultipleProductsToProductStock();

            var result = this.productStock.GetEnumerator();

            // Assert
            Assert.That(this.productStock[0].Label, Is.EqualTo("1"));
            Assert.That(this.productStock[1].Label, Is.EqualTo("2"));
            Assert.That(this.productStock[2].Label, Is.EqualTo("3"));
            Assert.That(this.productStock[3].Label, Is.EqualTo("4"));
            Assert.That(this.productStock[4].Label, Is.EqualTo("5"));
            Assert.That(this.productStock[5].Label, Is.EqualTo("6"));
            Assert.That(this.productStock[6].Label, Is.EqualTo("7"));
        }

        [Test]
        public void Get_Enumerator_Should_Return_All_Products_By_Price()
        {
            // Act
            this.AddMultipleProductsToProductStock();

            var result = this.productStock.GetEnumerator();

            // Assert
            Assert.That(this.productStock[0].Price, Is.EqualTo(10));
            Assert.That(this.productStock[1].Price, Is.EqualTo(5));
            Assert.That(this.productStock[2].Price, Is.EqualTo(15));
            Assert.That(this.productStock[3].Price, Is.EqualTo(3));
            Assert.That(this.productStock[4].Price, Is.EqualTo(25));
            Assert.That(this.productStock[5].Price, Is.EqualTo(15));
            Assert.That(this.productStock[6].Price, Is.EqualTo(50));
        }

        [Test]
        public void Get_Enumerator_Should_Return_All_Products_By_Quantity()
        {
            // Act
            this.AddMultipleProductsToProductStock();

            var result = this.productStock.GetEnumerator();

            // Assert
            Assert.That(this.productStock[0].Quantity, Is.EqualTo(5));
            Assert.That(this.productStock[1].Quantity, Is.EqualTo(60));
            Assert.That(this.productStock[2].Quantity, Is.EqualTo(20));
            Assert.That(this.productStock[3].Quantity, Is.EqualTo(18));
            Assert.That(this.productStock[4].Quantity, Is.EqualTo(7));
            Assert.That(this.productStock[5].Quantity, Is.EqualTo(3));
            Assert.That(this.productStock[6].Quantity, Is.EqualTo(7));
        }

        [Test]
        public void Get_Index_Should_Return_Correct_Product()
        {
            // Act
            this.AddMultipleProductsToProductStock();

            var result = this.productStock[1];

            // Assert
            Assert.That(result.Label, Is.EqualTo("2"));
            Assert.That(result.Price, Is.EqualTo(5));
            Assert.That(result.Quantity, Is.EqualTo(60));
        }

        [Test]
        public void Get_Index_Should_Throw_An_Exception_If_Index_Is_Under_Zero()
        {
            // Act
            this.productStock.Add(this.firstProduct);
            this.productStock.Add(this.secondProduct);

            // Assert
            Assert.Throws<IndexOutOfRangeException>(
                () =>
                {
                    var result = this.productStock[-5];
                },
                "Index is above zero.");
        }

        [Test]
        public void Get_Index_Should_Throw_An_Exception_If_Index_Is_Above_Than_The_Collection_Size()
        {
            // Act
            this.productStock.Add(this.firstProduct);
            this.productStock.Add(this.secondProduct);

            // Assert
            Assert.Throws<IndexOutOfRangeException>(
                () =>
                {
                    var result = this.productStock[this.productStock.Count + 5];
                },
                "Index is under than the collection size.");
        } 

        [Test]
        public void Set_Index_Should_Change_The_Product()
        {
            // Act
            this.AddMultipleProductsToProductStock();

            this.productStock[3] = new Product("new", 50, 3);
            var result = this.productStock.Find(3);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Label, Is.EqualTo("new"));
            Assert.That(result.Price, Is.EqualTo(50));
            Assert.That(result.Quantity, Is.EqualTo(3));
        }

        [Test]
        public void Set_Index_Should_Throw_An_Exception_If_Index_Is_Under_Zero()
        {
            // Act
            this.AddMultipleProductsToProductStock();

            // Assert
            Assert.Throws<IndexOutOfRangeException>(
                () =>
                {
                    this.productStock[-50] = new Product("aaaa", 50, 50);
                },
                "Index is above zero.");
        }

        [Test]
        public void Set_Index_Should_Throw_An_Exception_If_Index_Is_Above_Than_The_Collection_Size()
        {
            // Act
            this.AddMultipleProductsToProductStock();

            // Assert
            Assert.Throws<IndexOutOfRangeException>(
                () =>
                {
                    this.productStock[this.productStock.Count + 5] = new Product("aaaa", 50, 50);
                },
                "Index is under than the collection size.");
        }


        // Helper Method !
        private void AddMultipleProductsToProductStock()
        {
            this.productStock.Add(new Product("1", 10, 5));
            this.productStock.Add(new Product("2", 5, 60));
            this.productStock.Add(new Product("3", 15, 20));
            this.productStock.Add(new Product("4", 3, 18));
            this.productStock.Add(new Product("5", 25, 7));
            this.productStock.Add(new Product("6", 15, 3));
            this.productStock.Add(new Product("7", 50, 7));
        }
    }
}