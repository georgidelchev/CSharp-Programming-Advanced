using System;
using System.Linq;
using NUnit.Framework;

namespace Computers.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor_Should_Initialize_The_List_Correctly()
        {
            var computerManager = new ComputerManager();

            Assert.IsNotNull(computerManager.Computers);
            Assert.That(computerManager.Computers.Count, Is.EqualTo(0));
        }

        [Test]
        public void Count_Should_Return_Correct_Value_Without_Items()
        {
            var computerManager = new ComputerManager();

            Assert.That(computerManager.Count, Is.EqualTo(0));
        }

        [Test]
        public void Count_Should_Return_Correct_Value_With_Items()
        {
            var computerManager = new ComputerManager();

            computerManager.AddComputer(new Computer("Asus", "Rog", 2000));
            computerManager.AddComputer(new Computer("Asus1", "Rog1", 20020));

            Assert.That(computerManager.Count, Is.EqualTo(2));
        }

        [Test]
        public void Add_Method_Should_Add_Correctly()
        {
            var computerManager = new ComputerManager();

            computerManager.AddComputer(new Computer("Abcd", "dcba", 20000));

            Assert.That(computerManager.Count, Is.EqualTo(1));
            Assert.That(computerManager.Computers.Count, Is.EqualTo(1));
        }

        [Test]
        public void Add_Method_Should_Throw_An_Exception_If_We_Try_To_Add_Existing_Computer()
        {
            var computerManager = new ComputerManager();
            var computer = new Computer("Abcd", "dcba", 20000);

            computerManager.AddComputer(computer);

            Assert.Throws<ArgumentException>(
                () => computerManager.AddComputer(new Computer("Abcd", "dcba", 19)),
                "This computer is not existing.");
        }

        [Test]
        public void Add_Method_Should_Throw_An_Exception_If_The_Computer_Is_Null()
        {
            var computerManager = new ComputerManager();

            Assert.Throws<ArgumentNullException>(
                () => computerManager.AddComputer(null),
                "Value is not null.");
        }

        [Test]
        public void Remove_Method_Should_Remove_Correctly()
        {
            var computerManager = new ComputerManager();

            computerManager.AddComputer(new Computer("1", "1", 20000));
            computerManager.AddComputer(new Computer("2", "2", 200000));

            var computer = computerManager.RemoveComputer("1", "1");

            Assert.That(computerManager.Computers.Count, Is.EqualTo(1));
            Assert.That(computerManager.Count, Is.EqualTo(1));

            Assert.That(computer.Manufacturer, Is.EqualTo("1"));
            Assert.That(computer.Model, Is.EqualTo("1"));
            Assert.That(computer.Price, Is.EqualTo(20000));
        }

        [Test]
        public void Remove_Method_Should_Throw_An_Exception_If_The_Manufacturer_Is_Null()
        {
            var computerManager = new ComputerManager();

            Assert.Throws<ArgumentNullException>(
                () => computerManager.RemoveComputer(null, "10"),
                "Value is not null.");
        }

        [Test]
        public void Get_Computer_Method_Should_Throw_An_Exception_If_Computer_Is_Null()
        {
            var computerManager = new ComputerManager();

            Assert.Throws<ArgumentException>(
                () => computerManager.GetComputer("1", "1"),
                "This computer is not null.");
        }

        [Test]
        public void Get_Computers__Method_Should_Throw_An_Exception_If_The_Manufacturer_Is_Null()
        {
            var computerManager = new ComputerManager();

            Assert.Throws<ArgumentNullException>(
                () => computerManager.GetComputer(null, "10"),
                "Value is not null.");
        }

        [Test]
        public void Get_Computers__Method_Should_Throw_An_Exception_If_The_Model_Is_Null()
        {
            var computerManager = new ComputerManager();

            Assert.Throws<ArgumentNullException>(
                () => computerManager.GetComputer("10", null),
                "Value is not null.");
        }

        [Test]
        public void Get_Computers_By_Manufacturer_Method_Should_Return_Correct_Result()
        {
            var computerManager = new ComputerManager();

            computerManager.AddComputer(new Computer("1", "1", 20000));
            computerManager.AddComputer(new Computer("2", "2", 100));
            computerManager.AddComputer(new Computer("2", "3", 200));
            computerManager.AddComputer(new Computer("2", "4", 300));

            var computers = computerManager
                .GetComputersByManufacturer("2")
                .ToList();

            Assert.That(computers.Count, Is.EqualTo(3));

            Assert.That(computers[0].Manufacturer, Is.EqualTo("2"));
            Assert.That(computers[1].Manufacturer, Is.EqualTo("2"));
            Assert.That(computers[2].Manufacturer, Is.EqualTo("2"));

            Assert.That(computers[0].Model, Is.EqualTo("2"));
            Assert.That(computers[1].Model, Is.EqualTo("3"));
            Assert.That(computers[2].Model, Is.EqualTo("4"));

            Assert.That(computers[0].Price, Is.EqualTo(100));
            Assert.That(computers[1].Price, Is.EqualTo(200));
            Assert.That(computers[2].Price, Is.EqualTo(300));
        }

        [Test]
        public void Get_Computers_By_Manufacturer_Method_Should_Return_Empty_Collection()
        {
            var computerManager = new ComputerManager();

            computerManager.AddComputer(new Computer("1", "1", 20000));
            computerManager.AddComputer(new Computer("2", "2", 100));
            computerManager.AddComputer(new Computer("2", "3", 200));
            computerManager.AddComputer(new Computer("2", "4", 300));

            var computers = computerManager
                .GetComputersByManufacturer("51")
                .ToList();

            Assert.IsEmpty(computers);
            Assert.That(computers.Count, Is.EqualTo(0));
        }

        [Test]
        public void Get_Computers_By_Manufacturer_Method_Should_Throw_An_Exception_If_The_Manufacturer_Is_Null()
        {
            var computerManager = new ComputerManager();

            Assert.Throws<ArgumentNullException>(
                () => computerManager.GetComputersByManufacturer(null),
                "Value is not null.");
        }
    }
}