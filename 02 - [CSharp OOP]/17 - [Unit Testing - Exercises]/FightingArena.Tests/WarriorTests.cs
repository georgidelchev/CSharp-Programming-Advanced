using System;
using NUnit.Framework;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor_Should_Work_Correctly()
        {
            // Arrange
            var warrior = new Warrior("Ivan", 99, 1000);

            // Act
            var expecterName = "Ivan";
            var expectedDamage = 99;
            var expectedHP = 1000;

            // Assert
            Assert.That(warrior.Name, Is.EqualTo(expecterName));
            Assert.That(warrior.Damage, Is.EqualTo(expectedDamage));
            Assert.That(warrior.HP, Is.EqualTo(expectedHP));
        }

        [Test]
        public void Warrior_Name_Should_Be_Set_Correctly()
        {
            // Arrange
            var warrior = new Warrior("Filip", 99, 1000);

            // Act
            var expecterName = "Filip";

            // Assert
            Assert.That(warrior.Name, Is.EqualTo(expecterName));
        }

        [TestCase(null)]
        [TestCase(" ")]
        public void Throw_An_Exception_If_The_Name_Is_Null_Or_Whitespace(string name)
        {
            Assert.Throws<ArgumentException>(
                () => new Warrior(name, 10, 1000),
                "The name is not null or whitespace.");
        }

        [Test]
        public void Throw_An_Exception_If_The_Name_Is_Empty()
        {
            Assert.Throws<ArgumentException>(
                () => new Warrior(string.Empty, 10, 1000),
                "The name is not empty.");
        }

        [Test]
        public void Warrior_Damage_Should_Be_Set_Correctly()
        {
            // Arrange
            var warrior = new Warrior("Filip", 99, 1000);

            // Act
            var expecterDamage = 99;

            // Assert
            Assert.That(warrior.Damage, Is.EqualTo(expecterDamage));
        }

        [TestCase(0)]
        [TestCase(-10)]
        public void Throw_An_Exception_If_The_Damage_Is_Less_Or_Equals_To_Zero(int damage)
        {
            Assert.Throws<ArgumentException>(
                () => new Warrior("Stavri", damage, 1000),
                "The damage is not 0 or < 0.");
        }

        [Test]
        public void Warrior_HP_Should_Be_Set_Correctly()
        {
            // Arrange
            var warrior = new Warrior("Filip", 99, 1000);

            // Act
            var expecterHP = 1000;

            // Assert
            Assert.That(warrior.HP, Is.EqualTo(expecterHP));
        }

        [TestCase(-10)]
        public void Throw_An_Exception_If_The_HP_Is_Less_Or_Equals_To_Zero(int hp)
        {
            Assert.Throws<ArgumentException>(
                () => new Warrior("Stavri", 100, hp),
                "The hp is not 0 or < 0.");
        }

        [Test]
        [TestCase(30)]
        [TestCase(20)]
        public void Throw_An_Exception_If_The_Health_Is_Less_Or_Equal_To_Zero_Than_The_Damage(int hp)
        {
            // Arrange
            var warrior = new Warrior("Stavri", 20, hp);
            var enemy = new Warrior("Ivan", 20, 40);

            // Assert
            Assert.Throws<InvalidOperationException>(
                () => warrior.Attack(enemy));
        }

        [Test]
        [TestCase(30)]
        [TestCase(20)]
        public void Throw_An_Exception_If_The_Enemy_Health_Is_Less_Or_Equal_To_Enemy_Damage(int hp)
        {
            // Arrange
            var warrior = new Warrior("Stavri", 20, 40);
            var enemy = new Warrior("Ivan", 20, hp);

            // Assert
            Assert.Throws<InvalidOperationException>(
                () => warrior.Attack(enemy));
        }

        [Test]
        public void Throw_An_Exception_If_The_Health_Is_Less_Or_Equal_To_Zero_Than_The_Enemy_Damage()
        {
            // Arrange
            var warrior = new Warrior("Stavri", 100, 90);
            var enemy = new Warrior("Ivan", 100, 100);

            // Assert
            Assert.Throws<InvalidOperationException>(
                () => warrior.Attack(enemy));
        }

        [Test]
        public void Attack_Should_Decrease_Hp()
        {
            Warrior warrior = new Warrior("Ivan4o", 60, 100);
            Warrior enemy = new Warrior("Vanyusha", 50, 100);

            var expectedHp = warrior.HP - enemy.Damage;
            var expectedEnemyHp = enemy.HP - warrior.Damage;

            warrior.Attack(enemy);

            Assert.That(warrior.HP, Is.EqualTo(expectedHp));
            Assert.That(enemy.HP, Is.EqualTo(expectedEnemyHp));
        }

        [Test]
        public void Attack_Should_Set_Enemy_Hp_Zero_When_Damage_Bigger_Then_Enemy_Hp()
        {
            Warrior warrior = new Warrior("Pesho", 100, 100);
            Warrior enemy = new Warrior("Parker", 50, 95);

            int expectedWarriorHp = warrior.HP - enemy.Damage;
            int expectedEnemyHp = 0;

            warrior.Attack(enemy);

            Assert.That(warrior.HP, Is.EqualTo(expectedWarriorHp));
            Assert.That(enemy.HP, Is.EqualTo(expectedEnemyHp));
        }
    }
}