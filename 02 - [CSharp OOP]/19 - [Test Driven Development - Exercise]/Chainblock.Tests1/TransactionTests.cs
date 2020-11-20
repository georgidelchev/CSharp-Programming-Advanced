using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Chainblock.Contracts;
using Chainblock.Models;
using NUnit.Framework;

namespace Chainblock.Tests
{
    [TestFixture]
    public class TransactionTests
    {
        [Test]
        public void Constructor_Should_Set_Properties_Correctly()
        {
            // Arrange
            var transaction =
                new Transaction(10, "Ivan", "Stavri", 50, TransactionStatus.Successfull);

            // Act
            var actualId = transaction.Id;
            var actualFrom = transaction.From;
            var actualTo = transaction.To;
            var actualAmount = transaction.Amount;

            var actualTransactionStatus = transaction.Status;

            var expectedId = 10;
            var expectedFrom = "Ivan";
            var expectedTo = "Stavri";
            var expectedAmount = 50;

            var expectedTransactionStatus = TransactionStatus.Successfull;

            // Assert
            Assert.That(actualId, Is.EqualTo(expectedId));
            Assert.That(actualFrom, Is.EqualTo(expectedFrom));
            Assert.That(actualTo, Is.EqualTo(expectedTo));
            Assert.That(actualAmount, Is.EqualTo(expectedAmount));

            Assert.That(actualTransactionStatus, Is.EqualTo(expectedTransactionStatus));
        }

        [Test]
        public void Id_Should_Throw_An_Exception_If_It_Is_Bellow_Zero()
        {
            // Assert
            Assert.Throws<ArgumentException>(
                () => new Transaction(-10, "Ivan", "Samuil", 50, TransactionStatus.Aborted), // Act
                "The id is not bellow zero.");
        }

        [Test]
        public void From_Should_Throw_An_Exception_If_It_Is_Under_Three_Symbols()
        {
            // Assert
            Assert.Throws<ArgumentException>(
                () => new Transaction(10, "Ha", "Ivan", 10, TransactionStatus.Aborted), // Act
                "From is not under 3 symbols.");
        }

        [Test]
        public void From_Should_Throw_An_Exception_If_It_Is_Null()
        {
            // Assert
            Assert.Throws<ArgumentException>(
                () => new Transaction(10, null, "Ivan", 10, TransactionStatus.Aborted), // Act
                "From is not under null.");
        }

        [Test]
        public void To_Should_Throw_An_Exception_If_It_Is_Under_Three_Symbols()
        {
            // Assert
            Assert.Throws<ArgumentException>(
                () => new Transaction(10, "Ivan", "Ha", 10, TransactionStatus.Aborted), // Act
                "From is not under 3 symbols.");
        }

        [Test]
        public void To_Should_Throw_An_Exception_If_It_Is_Null()
        {
            // Assert
            Assert.Throws<ArgumentException>(
                () => new Transaction(10, "Ivan", null, 10, TransactionStatus.Aborted), // Act
                "From is not under null.");
        }

        [Test]
        public void Amount_Should_Throw_An_Exception_If_It_Is_Bellow_Zero()
        {
            // Assert
            Assert.Throws<ArgumentException>(
                () => new Transaction(10, "Ivan", "Samuil", -50, TransactionStatus.Aborted), // Act
                "The amount is not bellow zero.");
        }
    }
}
