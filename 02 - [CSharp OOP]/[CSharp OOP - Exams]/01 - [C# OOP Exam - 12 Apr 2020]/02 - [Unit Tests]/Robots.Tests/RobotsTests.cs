using NUnit.Framework;

namespace Robots.Tests
{
    using System;

    [TestFixture]
    public class RobotsTests
    {
        [Test]
        public void Constructor_Should_Set_Capacity_Correctly()
        {
            var robotManager = new RobotManager(5);

            Assert.That(robotManager.Capacity, Is.EqualTo(5));
        }

        [Test]
        public void Negative_Capacity_Should_Throw_An_Exception()
        {
            Assert.Throws<ArgumentException>(
                () => new RobotManager(-10),
                "Capacity is not negative.");
        }

        [Test]
        public void Constructor_Should_Set_Count_Correctly()
        {
            var robotManager = new RobotManager(5);
            var robot = new Robot("Ivan", 100);

            robotManager.Add(robot);

            Assert.That(robotManager.Count, Is.EqualTo(1));
        }

        [Test]
        public void Add_Method_Should_Add_Robot_Correctly()
        {
            var robotManager = new RobotManager(5);
            var robot = new Robot("Ivan", 100);

            robotManager.Add(robot);

            Assert.That(robotManager.Count, Is.EqualTo(1));
        }

        [Test]
        public void Add_Method_Should_Throw_An_Exception_If_There_Is_Robot_Existing()
        {
            var robotManager = new RobotManager(5);
            var robot = new Robot("Ivan", 100);

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(
                () => robotManager.Add(robot),
                "No robot duplicates.");
        }

        [Test]
        public void Add_Method_Should_Throw_An_Exception_If_There_Is_No_Capacity_Left()
        {
            var robotManager = new RobotManager(1);
            var robot = new Robot("Ivan", 100);

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(
                () => robotManager.Add(new Robot("Sashka", 1000)),
                "There is more capacity");
        }

        [Test]
        public void Remove_Method_Should_Remove_Robot_Correctly()
        {
            var robotManager = new RobotManager(5);
            var robot = new Robot("Ivan", 100);

            robotManager.Add(robot);
            robotManager.Remove("Ivan");

            Assert.That(robotManager.Count, Is.EqualTo(0));
        }

        [Test]
        public void Remove_Method_Should_Throw_An_Exception_If_The_Robot_Is_Null()
        {
            var robotManager = new RobotManager(1);
            var robot = new Robot("Ivan", 100);

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(
                () => robotManager.Remove(null),
                "Robot is not null.");
        }

        [Test]
        public void Work_Method_Should_Throw_An_Exception_If_The_Robot_Is_Null()
        {
            var robotManager = new RobotManager(1);
            var robot = new Robot("Ivan", 100);

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(
                () => robotManager.Work(null, "Kravar", 100),
                "Robot is not null.");
        }

        [Test]
        public void Work_Method_Should_Throw_An_Exception_If_The_Robot_Battery_Is_Bellow_The_Battery_Usage()
        {
            var robotManager = new RobotManager(1);
            var robot = new Robot("Ivan", 100);

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(
                () => robotManager.Work("Ivan", "Kravar", 1000),
                "Robot battery not bellow than the usage.");
        }

        [Test]
        public void Work_Method_Should_Decrease_Battery_Correctly()
        {
            var robotManager = new RobotManager(1);
            var robot = new Robot("Ivan", 100);

            robotManager.Add(robot);
            robotManager.Work("Ivan", "Kravar", 50);

            Assert.That(robot.Battery, Is.EqualTo(50));
        }

        [Test]
        public void Charge_Method_Should_Throw_An_Exception_If_The_Robot_Is_Null()
        {
            var robotManager = new RobotManager(1);
            var robot = new Robot("Ivan", 100);

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(
                () => robotManager.Charge(null),
                "Robot is not null.");
        }

        [Test]
        public void Charge_Method_Should_Charge_The_Robot_Correctly()
        {
            var robotManager = new RobotManager(1);
            var robot = new Robot("Ivan", 100);

            robotManager.Add(robot);
            robotManager.Work("Ivan", "Kravar", 80);
            robotManager.Charge("Ivan");

            Assert.That(robot.Battery, Is.EqualTo(100));
        }
    }
}
