using System;
using INStock.Models;
using NUnit.Framework;

namespace INStock.Tests
{
    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void Constructor_Should_Set_Values_Correctly()
        {
            // Arrange
            var product = new Product("Label", 10, 10);

            // Act
            var actualLabel = product.Label;
            var actualPrice = product.Price;
            var actualQty = product.Quantity;

            var expectedLabel = "Label";
            var expectedPrice = 10;
            var expectedQty = 10;

            // Assert
            Assert.That(actualLabel, Is.EqualTo(expectedLabel));
            Assert.That(actualPrice, Is.EqualTo(expectedPrice));
            Assert.That(actualQty, Is.EqualTo(expectedQty));
        }

        [Test]
        public void Throw_An_Exception_If_Label_Name_Is_Null()
        {
            // Arrange & Assert
            Assert.Throws<ArgumentException>(
                () => new Product(null, 10, 20));
        }

        [Test]
        public void Throw_An_Exception_If_Label_Name_Empty()
        {
            // Arrange & Assert
            Assert.Throws<ArgumentException>(
                () => new Product(string.Empty, 10, 10));
        }

        [Test]
        public void Throw_An_Exception_If_Label_Name_Is_Whitespace()
        {
            // Arrange & Assert
            Assert.Throws<ArgumentException>(
                () => new Product("", 10, 10));
        }

        [Test]
        public void Throw_An_Exception_If_Price_Is_Less_Than_Zero()
        {
            // Arrange & Assert
            Assert.Throws<ArgumentException>(
                () => new Product("Label", -100, 10));
        }

        [Test]
        public void Throw_An_Exception_If_Qty_Is_Less_Than_Zero()
        {
            // Arrange & Assert
            Assert.Throws<ArgumentException>(
                () => new Product("Label", 100, -10));
        }

        [Test]
        public void Comparing_Two_Products_By_Price_Must_Be_Compared_Correctly()
        {
            // Arrange
            var firstProduct = new Product("Label", 100, 10);
            var secondProduct = new Product("Label", 50, 10);

            // Act
            var result = firstProduct.CompareTo(secondProduct);

            // Assert
            Assert.That(result > 0, Is.True);
        }
    }
}