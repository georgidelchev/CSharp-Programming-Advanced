using System;
using CarManager;
using NUnit.Framework;

public class CarTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Constructor_Will_Set_Fuel_Amount_To_Zero()
    {
        // Arrange
        var car = new Car("Audi", "A4", 1, 100);

        // Act
        var actualResult = car.FuelAmount;
        var expectedResult = 0;

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Car_Should_Return_Correctly_Make()
    {
        // Arrange
        var car = new Car("Audi", "A4", 1, 100);

        // Act
        var actualResult = car.Make;
        var expectedResult = "Audi";

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [TestCase(null)]
    [TestCase("")]
    public void Car_Should_Throw_An_Exception_If_The_Make_Is_Null_Or_Empty(string make)
    {
        // Assert
        Assert.Throws<ArgumentException>(
            () => new Car(make, "A4", 1, 100), // Act
            "Car make is not null or empty");
    }

    [Test]
    public void Car_Should_Return_Correctly_Model()
    {
        // Arrange
        var car = new Car("Audi", "A4", 1, 100);

        // Act
        var actualResult = car.Model;
        var expectedResult = "A4";

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [TestCase(null)]
    [TestCase("")]
    public void Car_Should_Throw_An_Exception_If_The_Model_Is_Null_Or_Empty(string model)
    {
        // Assert
        Assert.Throws<ArgumentException>(
            () => new Car("Audi", "", 1, 100), // Act
            "Car model is not null or empty");
    }

    [Test]
    public void Car_Should_Return_Correctly_Fuel_Consumption()
    {
        // Arrange
        var car = new Car("Audi", "A4", 1, 100);

        // Act
        var actualResult = car.FuelConsumption;
        var expectedResult = 1;

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [TestCase(0)]
    [TestCase(-10)]
    public void Car_Should_Throw_An_Exception_If_The_Fuel_Consumption_Is_Less_Than_Or_Equal_To_Zero(double fuelConsumption)
    {
        // Assert
        Assert.Throws<ArgumentException>(
            () => new Car("Audi", "А4", fuelConsumption, 100), // Act
            "Car fuel consumption is not less than zero");
    }

    [Test]
    public void Car_Should_Return_Correctly_Fuel_Capacity()
    {
        // Arrange
        var car = new Car("Audi", "A4", 1, 100);

        // Act
        var actualResult = car.FuelCapacity;
        var expectedResult = 100;

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [TestCase(0)]
    [TestCase(-10)]
    public void Car_Should_Throw_An_Exception_If_The_Fuel_Capacity_Is_Less_Than_Or_Equal_To_Zero(double fuelCapacity)
    {
        // Assert
        Assert.Throws<ArgumentException>(
            () => new Car("Audi", "А4", 10, fuelCapacity), // Act
            "Car fuel capacity is not less than zero");
    }

    [TestCase(0)]
    [TestCase(-10)]
    public void Car_Should_Throw_An_Exception_If_The_Refuel_Amount_Is_Less_Than_Or_Equal_To_Zero(double refuelAmount)
    {
        // Arrange
        var car = new Car("Audi", "A3", 100, 100);

        // Assert
        Assert.Throws<ArgumentException>(
            () => car.Refuel(refuelAmount), // Act
            "Refuel amount is not zero or less than zero");
    }

    [Test]
    public void Fuel_Amount_Should_Increase_With_Given_Refuel_Amount_Correctly()
    {
        // Arrange
        var car = new Car("Audi", "RS4", 100, 500);

        // Act
        car.Refuel(200);

        var actualResult = car.FuelAmount;
        var expectedResult = 200;

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Fuel_Amount_Should_Not_Increase_More_Than_The_Fuel_Capacity_With_Given_Refuel_Amount_Correctly()
    {
        // Arrange
        var car = new Car("Audi", "RS4", 100, 100);

        // Act
        car.Refuel(200);

        var actualResult = car.FuelAmount;
        var expectedResult = 100;

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Needed_Fuel_Must_Be_Calculated_Correctly_By_Given_Distance()
    {
        // Arrange
        var car = new Car("Audi", "A1", 20, 200);

        // Act
        var expectedFuel = 10;

        car.Refuel(20);
        car.Drive(50);

        var actualResult = car.FuelAmount;

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedFuel));
    }

    [Test]
    public void Throw_An_Exception_If_The_Needed_Fuel_Is_More_Than_The_Fuel_Amount()
    {
        // Arrange
        var car = new Car("BMW", "Trash5", 20, 100);

        car.Refuel(10);

        // Assert
        Assert.Throws<InvalidOperationException>(
            () => car.Drive(300),
            "You have enough fuel.");
    }
}