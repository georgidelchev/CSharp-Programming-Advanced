using System;
using NUnit.Framework;

namespace Tests
{
    public class ArenaTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor_Creates_New_List_Correctly()
        {
            // Arrange
            var arena = new Arena();

            // Assert
            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void Count_Should_Return_Correctly()
        {
            // Arrange
            var arena = new Arena();

            // Act
            var actualResult = arena.Count;
            var expectedResult = 0;

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Enroll_Should_Throw_An_Exception_If_There_Are_Two_Players_With_Same_Names()
        {
            // Arrange
            var arena = new Arena();
            var warrior = new Warrior("Stavri", 10, 10);
            var warrior2 = new Warrior("Stavri", 101, 110);

            arena.Enroll(warrior);

            // Assert
            Assert.Throws<InvalidOperationException>(
                () => arena.Enroll(warrior2), // Act
                "There are no players with same names.");
        }

        [Test]
        public void Enroll_Should_Work_Correctly_When_Enroll_New_Unique_Warrior()
        {
            var arena = new Arena();
            var warriorToEnroll = new Warrior("Peter", 100, 100);
            int expectedCount = 1;

            arena.Enroll(warriorToEnroll);

            Assert.That(arena.Count, Is.EqualTo(expectedCount));
            Assert.That(arena.Warriors, Has.Member(warriorToEnroll));

        }

        [Test]
        public void Enroll_Should_Throw_Exception_Adding_An_Existing_Warrior()
        {
            var arena = new Arena();
            var warrior = new Warrior("Peter", 100, 100);

            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(warrior);
            });
        }

        [Test]
        public void Enroll_Should_Add_Warriors_Correctly()
        {
            // Arrange
            var arena = new Arena();
            var warrior = new Warrior("Stavri", 10, 10);

            // Act
            arena.Enroll(warrior);

            // Assert
            Assert.That(arena.Warriors, Has.Member(warrior));
        }

        [Test]
        public void Fight_Should_Throw_An_Exception_If_Attacker_Is_Missing()
        {
            // Arrange
            var arena = new Arena();

            var fighter = new Warrior("Stavri", 10, 10);
            var defender = new Warrior("Iliq", 12, 11);

            // Act
            arena.Enroll(defender);

            // Assert
            Assert.Throws<InvalidOperationException>(
                () => arena.Fight(fighter.Name, defender.Name),
                "There is fighter already.");
        }

        [Test]
        public void Fight_Should_Throw_An_Exception_If_Defender_Is_Missing()
        {
            // Arrange
            var arena = new Arena();

            var fighter = new Warrior("Stavri", 10, 10);
            var defender = new Warrior("Iliq", 12, 11);

            // Act
            arena.Enroll(fighter);

            // Assert
            Assert.Throws<InvalidOperationException>(
                () => arena.Fight(fighter.Name, defender.Name),
                "There is defender already.");
        }

        [Test]
        public void Fight_Should_Return_Correct_Results()
        {
            // Arrange
            var arena = new Arena();

            var attacker = new Warrior("Stavri", 10, 80);
            var defender = new Warrior("Iliq", 5, 50);

            // Act
            var attackerHealth = attacker.HP - defender.Damage;
            var defenderHealth = defender.HP - attacker.Damage;

            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight(attacker.Name,defender.Name);

            // Assert
            Assert.That(attacker.HP,Is.EqualTo(attackerHealth));
            Assert.That(defender.HP,Is.EqualTo(defenderHealth));
        }
    }
}
