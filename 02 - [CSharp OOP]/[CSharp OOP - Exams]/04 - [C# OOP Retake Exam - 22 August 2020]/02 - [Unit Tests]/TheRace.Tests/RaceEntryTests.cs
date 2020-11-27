using System;
using NUnit.Framework;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor_Should_Create_Dictionary_Correctly()
        {
            var raceEntry = new RaceEntry();

            Assert.That(raceEntry.Counter, Is.EqualTo(0));
        }

        [Test]
        public void Add_Driver_Should_Add_Correctly()
        {
            var raceEntry = new RaceEntry();
            var car = new UnitCar("R8", 100, 2000);
            var driver = new UnitDriver("Ivan", car);

            raceEntry.AddDriver(driver);

            Assert.That(raceEntry.Counter, Is.EqualTo(1));
        }

        [Test]
        public void Add_Driver_Should_Throw_An_Exception_If_The_Driver_Is_Null()
        {
            var raceEntry = new RaceEntry();

            Assert.Throws<InvalidOperationException>(
                () => raceEntry.AddDriver(null),
                "The driver is not null.");
        }

        [Test]
        public void Add_Driver_Should_Throw_An_Exception_If_The_Driver_Is_Existing()
        {
            var raceEntry = new RaceEntry();

            var car = new UnitCar("R8", 100, 2000);
            var driver = new UnitDriver("Ivan", car);

            raceEntry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(
                () => raceEntry.AddDriver(driver),
                "The driver is not existing.");
        }

        [Test]
        public void Calculate_Average_Horse_Powers_Should_Be_Calculated_Correctly()
        {
            var raceEntry = new RaceEntry();
            var car1 = new UnitCar("R8", 100, 2000);
            var car2 = new UnitCar("R9", 200, 3000);
            var car3 = new UnitCar("R10", 300, 4000);
            var car4 = new UnitCar("R11", 400, 4000);

            var driver1 = new UnitDriver("Ivan", car1);
            var driver2 = new UnitDriver("Gosho", car2);
            var driver3 = new UnitDriver("Pesho", car3);
            var driver4 = new UnitDriver("Kesho", car4);

            raceEntry.AddDriver(driver1);
            raceEntry.AddDriver(driver2);
            raceEntry.AddDriver(driver3);
            raceEntry.AddDriver(driver4);

            var actualResult = raceEntry.CalculateAverageHorsePower();

            var expectedResult = (car1.HorsePower + car2.HorsePower + car3.HorsePower + car4.HorsePower) / 4;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Calculate_Average_Horse_Powers_Should_Throw_An_Exception_If_The_Drivers_Are_Bellow_Than_Minimum_Participants_Count()
        {
            var raceEntry = new RaceEntry();

            var car = new UnitCar("R8", 100, 2000);
            var driver = new UnitDriver("Ivan", car);

            raceEntry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(
                () => raceEntry.CalculateAverageHorsePower(),
                "Participant count are not bellow than the drivers count.");
        }
    }
}