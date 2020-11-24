using System;

namespace Computers.Tests
{
    using NUnit.Framework;

    public class ComputerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor_Should_Set_Properties_Correctly()
        {
            var computer = new Computer("Asus");

            Assert.IsNotNull(computer.Parts);
            Assert.That(computer.Name, Is.EqualTo("Asus"));
            Assert.That(computer.Parts.Count, Is.EqualTo(0));
        }

        [Test]
        public void Name_Should_Throw_An_Exception_If_The_Name_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(
                () => new Computer(null),
                "The name is not null.");
        }

        [Test]
        public void Name_Should_Throw_An_Exception_If_The_Name_Is_Whitespace()
        {
            Assert.Throws<ArgumentNullException>(
                () => new Computer(" "),
                "The name is not whitespace.");
        }

        [Test]
        public void Name_Should_Throw_An_Exception_If_The_Name_Is_Empty()
        {
            Assert.Throws<ArgumentNullException>(
                () => new Computer(""),
                "The name is not empty.");
        }

        [Test]
        public void Total_Price_Should_Be_Calculated_Correctly()
        {
            var computer = new Computer("Asus");

            var result = computer.TotalPrice;

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void Total_Price_Should_Be_Calculated_Correctly_With_Values()
        {
            var computer = new Computer("Asus");

            computer.AddPart(new Part("CPU", 15));
            computer.AddPart(new Part("GPU", 35));
            computer.AddPart(new Part("RAM", 100));

            var result = computer.TotalPrice;

            Assert.That(result, Is.EqualTo(150));
        }

        [Test]
        public void Add_Should_Add_Parts_Correctly()
        {
            var computer = new Computer("Asus");

            computer.AddPart(new Part("RAM", 100));

            Assert.That(computer.Parts.Count, Is.EqualTo(1));
        }

        [Test]
        public void Add_Should_Throw_An_Exception_If_The_Part_Is_Null()
        {
            var computer = new Computer("Asus");

            Assert.Throws<InvalidOperationException>(
                () => computer.AddPart(null),
                "The part is not null.");
        }

        [Test]
        public void Remove_Should_Remove_Part_Correctly()
        {
            var computer = new Computer("Asus");

            computer.AddPart(new Part("CPU", 100));

            var result = computer.RemovePart(computer.GetPart("CPU"));

            Assert.IsTrue(result);
        }

        [Test]
        public void Remove_Should_Not_Remove_Part_If_Not_Existing()
        {
            var computer = new Computer("Asus");

            computer.AddPart(new Part("CPU", 100));

            var result = computer.RemovePart(computer.GetPart("GPU"));

            Assert.IsFalse(result);
        }

        [Test]
        public void Get_Part_Should_Return_Part_Correctly()
        {
            var computer = new Computer("Asus");

            computer.AddPart(new Part("CPU", 100));

            var result = computer.GetPart("CPU");

            Assert.That(result.Name, Is.EqualTo("CPU"));
            Assert.That(result.Price, Is.EqualTo(100));
        }
    }
}