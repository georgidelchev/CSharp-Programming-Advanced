using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Chainblock.Contracts;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Chainblock.Models;
using NUnit.Framework;

namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainblockTests
    {
        private Transaction firstTransaction;
        private Transaction secondTransaction;

        [SetUp]
        public void SetUp()
        {
            this.firstTransaction = new Transaction(10, "Ivan", "Samuil", 50, TransactionStatus.Successfull);
            this.secondTransaction = new Transaction(10, "Ivancho", "Samuilcho", 501, TransactionStatus.Successfull);
        }

        [Test]
        public void Add_Should_Increase_Count_Correctly_By_One()
        {
            // Arrange
            var chainblock = new Models.Chainblock();

            //Act
            chainblock.Add(this.firstTransaction);

            var actualCount = chainblock.Count;
            var expectedCount = 1;

            // Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Add_Should_Increase_Count_Correctly_By_Two()
        {
            // Arrange
            var chainblock = new Models.Chainblock();

            this.secondTransaction = new Transaction(20, "Ivancho", "Samuilcho", 501, TransactionStatus.Successfull);

            //Act
            chainblock.Add(this.firstTransaction);
            chainblock.Add(this.secondTransaction);

            var actualCount = chainblock.Count;
            var expectedCount = 2;

            // Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Add_Should_Add_Transaction_Correctly()
        {
            // Arrange
            var chainblock = new Models.Chainblock();

            //Act
            chainblock.Add(this.firstTransaction);

            var transactionResult = chainblock.Transactions.Single();

            var actualCount = chainblock.Count;
            var expectedCount = 1;

            // Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount));

            Assert.That(transactionResult.Id, Is.EqualTo(10));
            Assert.That(transactionResult.From, Is.EqualTo("Ivan"));
            Assert.That(transactionResult.To, Is.EqualTo("Samuil"));
            Assert.That(transactionResult.Amount, Is.EqualTo(50));
            Assert.That(transactionResult.Status, Is.EqualTo(TransactionStatus.Successfull));
        }

        [Test]
        public void Add_Existing_Transaction_Should_Not_Change_The_Count()
        {
            // Arrange
            var chainblock = new Models.Chainblock();

            //Act
            chainblock.Add(this.firstTransaction);

            try
            {
                chainblock.Add(this.secondTransaction);
            }
            catch (InvalidOperationException)
            {
                var actualCount = chainblock.Count;
                var expectedCount = 1;

                // Assert
                Assert.That(actualCount, Is.EqualTo(expectedCount));
            }
        }

        [Test]
        public void Add_Existing_Transaction_Should_Throw_An_Exception()
        {
            // Arrange
            var chainblock = new Models.Chainblock();

            //Act
            chainblock.Add(this.firstTransaction);

            // Assert
            Assert.Throws<InvalidOperationException>(
                () => chainblock.Add(this.secondTransaction), // Act
                "Transactions are not same.");
        }

        [Test]
        public void Contains_Transactions_Should_Throw_An_Exception_If_Transaction_Is_Null()
        {
            // Arrange
            var chainblock = new Models.Chainblock();

            // Assert
            Assert.Throws<ArgumentNullException>(
                () => chainblock.Contains(null), // Act
                "Transaction is not null.");
        }

        [Test]
        public void Contains_Transactions_Should_Return_True_If_Existing()
        {
            // Arrange
            var chainblock = new Models.Chainblock();

            // Act
            chainblock.Add(this.firstTransaction);

            var isExisting = chainblock.Contains(this.firstTransaction);

            // Assert
            Assert.That(isExisting, Is.True);
        }

        [Test]
        public void Contains_Transactions_Should_Return_False_If_Not_Existing()
        {
            // Arrange
            var chainblock = new Models.Chainblock();

            // Act
            chainblock.Add(this.firstTransaction);

            var isExisting = chainblock.Contains(this.secondTransaction);

            // Assert
            Assert.That(isExisting, Is.False);
        }

        [Test]
        public void Contains_Id_Should_Throw_An_Exception_If_Id_Is_Under_Zero()
        {
            // Arrange
            var chainblock = new Models.Chainblock();

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(
                () => chainblock.Contains(-10), // Act
                "Id is not under zero");
        }

        [Test]
        public void Contains_Id_Should_Return_True_If_Existing()
        {
            // Arrange
            var chainblock = new Models.Chainblock();

            // Act
            chainblock.Add(this.firstTransaction);

            var isExisting = chainblock.Contains(10);

            // Assert
            Assert.That(isExisting, Is.True);
        }

        [Test]
        public void Contains_Id_Should_Return_False_If_Not_Existing()
        {
            // Arrange
            var chainblock = new Models.Chainblock();

            // Act
            chainblock.Add(this.firstTransaction);

            var isExisting = chainblock.Contains(500);

            // Assert
            Assert.That(isExisting, Is.False);
        }

        [Test]
        public void Change_Transaction_By_Id_Status_Should_Change_Status_Correctly()
        {
            // Arrange
            var chainblock = new Models.Chainblock();

            // Act
            chainblock.Add(this.firstTransaction);

            chainblock.ChangeTransactionStatus(10, TransactionStatus.Aborted);

            var actualStatus = this.firstTransaction.Status;
            var expectedStatus = TransactionStatus.Aborted;

            // Assert
            Assert.That(actualStatus, Is.EqualTo(expectedStatus));
        }

        [Test]
        public void Change_Transaction_By_Id_Status_Should_Throw_An_Exception_If_Id_Is_Under_Zero()
        {
            // Arrange
            var chainblock = new Models.Chainblock();

            // Act
            chainblock.Add(this.firstTransaction);

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(
                () => chainblock.ChangeTransactionStatus(-10, TransactionStatus.Aborted), // Act
                "Id is not under zero.");
        }

        [Test]
        public void Change_Transaction_By_Id_Status_Should_Throw_An_Exception_If_Id_Is_Not_Found()
        {
            // Arrange
            var chainblock = new Models.Chainblock();

            // Act
            chainblock.Add(this.firstTransaction);

            // Assert
            Assert.Throws<InvalidOperationException>(
                () => chainblock.ChangeTransactionStatus(78, TransactionStatus.Aborted), // Act
                "Id is existing.");
        }

        // here
        [Test]
        public void Remove_Transaction_By_Id_Should_Be_Removed_Correctly()
        {
            // Arrange
            var chainblock = new Models.Chainblock();

            // Act
            chainblock.Add(this.firstTransaction);

            chainblock.RemoveTransactionById(10);

            var actualCount = chainblock.Count;
            var expectedCount = 0;

            // Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Remove_Transaction_By_Id_Should_Throw_An_Exception_If_Id_Is_Under_Zero()
        {
            // Arrange
            var chainblock = new Models.Chainblock();

            // Act
            chainblock.Add(this.firstTransaction);

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(
                () => chainblock.RemoveTransactionById(-10), // Act
                "Id is not under zero.");
        }

        [Test]
        public void Remove_Transaction_By_Id_Should_Throw_An_Exception_If_Id_Is_Not_Found()
        {
            // Arrange
            var chainblock = new Models.Chainblock();

            // Act
            chainblock.Add(this.firstTransaction);

            // Assert
            Assert.Throws<InvalidOperationException>(
                () => chainblock.RemoveTransactionById(78), // Act
                "Id is existing.");
        }

        [Test]
        public void Get_By_Id_Should_Return_Transaction_Correctly()
        {
            // Arrange
            var chainblock = new Models.Chainblock();

            // Act
            chainblock.Add(this.firstTransaction);

            var transaction = chainblock.GetById(10);

            // Assert
            Assert.That(transaction, Is.Not.Null);
            Assert.That(transaction.Id, Is.EqualTo(10));
            Assert.That(transaction.From, Is.EqualTo("Ivan"));
            Assert.That(transaction.To, Is.EqualTo("Samuil"));
            Assert.That(transaction.Amount, Is.EqualTo(50));
            Assert.That(transaction.Status, Is.EqualTo(TransactionStatus.Successfull));
        }

        [Test]
        public void Get_By_Id_Should_Throw_An_Exception_If_Id_Is_Not_Existing()
        {
            // Arrange
            var chainblock = new Models.Chainblock();

            // Act
            chainblock.Add(this.firstTransaction);

            // Assert
            Assert.Throws<InvalidOperationException>(
                () => chainblock.GetById(1110), // Act
                "This id is existing.");
        }

        [Test]
        public void Get_By_Id_Should_Throw_An_Exception_If_Id_Is_Under_Zero()
        {
            // Arrange
            var chainblock = new Models.Chainblock();

            // Act
            chainblock.Add(this.firstTransaction);

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(
                () => chainblock.GetById(-100), // Act
                "This id is not zero.");
        }

        [Test]
        public void Get_By_Transaction_Status_Should_Return_Transaction_Correctly_One_Transaction()
        {
            // Arrange
            var chainblock = new Models.Chainblock();

            // Act
            chainblock.Add(this.firstTransaction);

            var transaction = chainblock
                .GetByTransactionStatus(TransactionStatus.Successfull)
                .ToList();

            // Assert
            Assert.That(transaction, Is.Not.Null);
            Assert.That(transaction[0].Id, Is.EqualTo(10));
            Assert.That(transaction[0].From, Is.EqualTo("Ivan"));
            Assert.That(transaction[0].To, Is.EqualTo("Samuil"));
            Assert.That(transaction[0].Amount, Is.EqualTo(50));
            Assert.That(transaction[0].Status, Is.EqualTo(TransactionStatus.Successfull));
        }

        [Test]
        public void Get_By_Transaction_Status_Should_Return_Transaction_Correctly_Two_Transactions()
        {
            // Arrange
            var chainblock = new Models.Chainblock();

            // Act
            chainblock.Add(this.firstTransaction);
            this.secondTransaction = new Transaction(50, "Stavri", "Ivan", 90, TransactionStatus.Successfull);
            chainblock.Add(this.secondTransaction);

            var transaction = chainblock
                .GetByTransactionStatus(TransactionStatus.Successfull)
                .ToList();

            // Assert
            Assert.That(transaction, Is.Not.Null);

            Assert.That(transaction[0].Id, Is.EqualTo(50));
            Assert.That(transaction[1].Id, Is.EqualTo(10));

            Assert.That(transaction[0].From, Is.EqualTo("Stavri"));
            Assert.That(transaction[1].From, Is.EqualTo("Ivan"));

            Assert.That(transaction[0].To, Is.EqualTo("Ivan"));
            Assert.That(transaction[1].To, Is.EqualTo("Samuil"));

            Assert.That(transaction[0].Amount, Is.EqualTo(90));
            Assert.That(transaction[1].Amount, Is.EqualTo(50));

            Assert.That(transaction[0].Status, Is.EqualTo(TransactionStatus.Successfull));
            Assert.That(transaction[1].Status, Is.EqualTo(TransactionStatus.Successfull));
        }

        [Test]
        public void Get_By_Transaction_Status_Should_Throw_An_Exception_If_Status_Is_Not_Existing()
        {
            // Arrange
            var chainblock = new Models.Chainblock();

            // Act
            chainblock.Add(this.firstTransaction);

            // Assert
            Assert.Throws<InvalidOperationException>(
                () => chainblock.GetByTransactionStatus(TransactionStatus.Aborted), // Act
                "This id is existing.");
        }

        [Test]
        public void Get_All_Senders_With_Transaction_Status_Should_Return_Them_Correctly()
        {
            // Arrange
            var chainblock = new Models.Chainblock();

            // Act
            chainblock.Add(this.firstTransaction);

            this.secondTransaction = new Transaction(100, "Ivancho", "Samuilcho", 501, TransactionStatus.Successfull);

            chainblock.Add(this.secondTransaction);

            var senders = chainblock
                .GetAllSendersWithTransactionStatus(TransactionStatus.Successfull)
                .ToList();

            // Assert
            Assert.That(senders, Is.Not.Null);

            Assert.That(senders[0], Is.EqualTo("Ivancho"));
            Assert.That(senders[1], Is.EqualTo("Ivan"));
        }

        [Test]
        public void Get_All_Senders_Should_Throw_An_Exception_If_Status_Is_Not_Existing()
        {
            // Arrange
            var chainblock = new Models.Chainblock();

            // Act
            chainblock.Add(this.firstTransaction);

            // Assert
            Assert.Throws<InvalidOperationException>(
                () => chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Aborted), // Act
                "This status is existing.");
        }

        [Test]
        public void Get_All_Receivers_With_Transaction_Status_Should_Return_Them_Correctly()
        {
            // Arrange
            var chainblock = new Models.Chainblock();

            // Act
            chainblock.Add(this.firstTransaction);

            this.secondTransaction = new Transaction(100, "Ivancho", "Samuilcho", 501, TransactionStatus.Successfull);

            chainblock.Add(this.secondTransaction);

            var receivers = chainblock
                .GetAllReceiversWithTransactionStatus(TransactionStatus.Successfull)
                .ToList();

            // Assert
            Assert.That(receivers, Is.Not.Null);

            Assert.That(receivers[0], Is.EqualTo("Samuilcho"));
            Assert.That(receivers[1], Is.EqualTo("Samuil"));
        }

        [Test]
        public void Get_All_Receivers_Should_Throw_An_Exception_If_Status_Is_Not_Existing()
        {
            // Arrange
            var chainblock = new Models.Chainblock();

            // Act
            chainblock.Add(this.firstTransaction);

            // Assert
            Assert.Throws<InvalidOperationException>(
                () => chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Aborted), // Act
                "This status is existing.");
        }

        [Test]
        public void Get_All_Ordered_By_Amount_Descending_Then_By_Id()
        {
            // Arrange
            var chainblock = new Models.Chainblock();

            // Act
            chainblock.Add(this.firstTransaction);

            this.secondTransaction = new Transaction(113, "Ivancho", "Samuilcho", 501, TransactionStatus.Successfull);
            chainblock.Add(this.secondTransaction);

            var thirdTransaction = new Transaction(111, "Ivo", "Ivcho", 501, TransactionStatus.Successfull);
            chainblock.Add(thirdTransaction);

            var transaction = chainblock
                .GetAllOrderedByAmountDescendingThenById()
                .ToList();

            // Assert
            Assert.That(transaction[0].Id, Is.EqualTo(113));
            Assert.That(transaction[1].Id, Is.EqualTo(111));
            Assert.That(transaction[2].Id, Is.EqualTo(10));

            Assert.That(transaction[0].From, Is.EqualTo("Ivancho"));
            Assert.That(transaction[1].From, Is.EqualTo("Ivo"));
            Assert.That(transaction[2].From, Is.EqualTo("Ivan"));

            Assert.That(transaction[0].To, Is.EqualTo("Samuilcho"));
            Assert.That(transaction[1].To, Is.EqualTo("Ivcho"));
            Assert.That(transaction[2].To, Is.EqualTo("Samuil"));

            Assert.That(transaction[0].Amount, Is.EqualTo(501));
            Assert.That(transaction[1].Amount, Is.EqualTo(501));
            Assert.That(transaction[2].Amount, Is.EqualTo(50));

            Assert.That(transaction[0].Status, Is.EqualTo(TransactionStatus.Successfull));
            Assert.That(transaction[1].Status, Is.EqualTo(TransactionStatus.Successfull));
            Assert.That(transaction[2].Status, Is.EqualTo(TransactionStatus.Successfull));
        }

        [Test]
        public void
            Get_All_Ordered_By_Amount_Descending_Then_By_Id_Should_Throw_An_Exception_If_There_Is_No_Transactions()
        {
            // Arrange
            var chainblock = new Models.Chainblock();

            // Assert
            Assert.Throws<InvalidOperationException>(
                () => chainblock.GetAllOrderedByAmountDescendingThenById());
        }

        [TestCase("Ivan")]
        public void Get_By_Sender_Ordered_By_Amount_Descending(string sender)
        {
            // Arrange
            var chainblock = new Models.Chainblock();

            // Act

            var transaction1 = new Transaction(100, "Ivan", "Samuilcho", 100, TransactionStatus.Successfull);
            var transaction2 = new Transaction(101, "Ivan", "Samuilcho", 200, TransactionStatus.Successfull);
            var transaction3 = new Transaction(102, "Ivan", "Samuilcho", 300, TransactionStatus.Successfull);
            var transaction4 = new Transaction(103, "Ivan", "Samuilcho", 400, TransactionStatus.Successfull);

            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);

            var result = chainblock
                .GetBySenderOrderedByAmountDescending(sender)
                .ToList();

            // Assert
            Assert.That(result[0].Id, Is.EqualTo(103));
            Assert.That(result[1].Id, Is.EqualTo(102));
            Assert.That(result[2].Id, Is.EqualTo(101));
            Assert.That(result[3].Id, Is.EqualTo(100));
        }

        [Test]
        public void Get_By_Sender_Ordered_By_Amount_Descending_Should_Throw_An_Exception_If_Collection_Is_Empty()
        {
            // Arrange
            var chainblock = new Models.Chainblock();

            // Act
            chainblock.Add(this.firstTransaction);

            string sender = "6i6ko";

            // Assert
            Assert.Throws<InvalidOperationException>(
                () => chainblock.GetBySenderOrderedByAmountDescending(sender));
        }

        [TestCase("Peshko")]
        public void Get_By_Receiver_Ordered_By_Amount_Descending(string receiver)
        {
            // Arrange
            var chainblock = new Models.Chainblock();

            // Act

            var transaction1 = new Transaction(100, "Peshko", "Samuilcho", 100, TransactionStatus.Successfull);
            var transaction2 = new Transaction(101, "Peshko", "Samuilcho", 200, TransactionStatus.Successfull);
            var transaction3 = new Transaction(102, "Peshko", "Samuilcho", 300, TransactionStatus.Successfull);
            var transaction4 = new Transaction(103, "Peshko", "Samuilcho", 400, TransactionStatus.Successfull);
            var transaction5 = new Transaction(104, "Peshko", "Samuilcho", 400, TransactionStatus.Successfull);

            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);
            chainblock.Add(transaction5);

            var result = chainblock
                .GetByReceiverOrderedByAmountThenById(receiver)
                .ToList();

            // Assert
            Assert.That(result[0].Id, Is.EqualTo(104));
            Assert.That(result[1].Id, Is.EqualTo(103));
            Assert.That(result[2].Id, Is.EqualTo(102));
            Assert.That(result[3].Id, Is.EqualTo(101));
            Assert.That(result[4].Id, Is.EqualTo(100));
        }

        [Test]
        public void Get_By_Receiver_Ordered_By_Amount_Descending_Should_Throw_An_Exception_If_Collection_Is_Empty()
        {
            // Arrange
            var chainblock = new Models.Chainblock();

            // Act
            chainblock.Add(this.firstTransaction);

            string sender = "6i6ko";

            // Assert
            Assert.Throws<InvalidOperationException>(
                () => chainblock.GetByReceiverOrderedByAmountThenById(sender));
        }

        [Test]
        public void Get_By_Transaction_Status_And_Maximum_Amount_Should_Work_Correctly()
        {
            // Arrange
            var chainblock = new Models.Chainblock();

            // Act
            var transaction1 = new Transaction(100, "Peshko", "Samuilcho", 100, TransactionStatus.Successfull);
            var transaction2 = new Transaction(101, "Peshko", "Samuilcho", 200, TransactionStatus.Successfull);
            var transaction3 = new Transaction(102, "Peshko", "Samuilcho", 300, TransactionStatus.Successfull);
            var transaction4 = new Transaction(103, "Peshko", "Samuilcho", 400, TransactionStatus.Successfull);
            var transaction5 = new Transaction(104, "Peshko", "Samuilcho", 400, TransactionStatus.Successfull);

            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);
            chainblock.Add(transaction5);

            var status = TransactionStatus.Successfull;
            var amount = 300;

            var transactions = chainblock
                .GetByTransactionStatusAndMaximumAmount(status, amount)
                .ToList();

            // Assert
            Assert.That(transactions[0].Id, Is.EqualTo(102));
            Assert.That(transactions[1].Id, Is.EqualTo(101));
            Assert.That(transactions[2].Id, Is.EqualTo(100));
        }

        [Test]
        public void Get_By_Transaction_Status_And_Maximum_Amount_Should_Work_Correctly_With_Empty_Collection()
        {
            // Arrange
            var chainblock = new Models.Chainblock();

            // Act
            var transaction1 = new Transaction(100, "Peshko", "Samuilcho", 100, TransactionStatus.Successfull);
            var transaction2 = new Transaction(101, "Peshko", "Samuilcho", 200, TransactionStatus.Successfull);
            var transaction3 = new Transaction(102, "Peshko", "Samuilcho", 300, TransactionStatus.Successfull);
            var transaction4 = new Transaction(103, "Peshko", "Samuilcho", 400, TransactionStatus.Successfull);
            var transaction5 = new Transaction(104, "Peshko", "Samuilcho", 400, TransactionStatus.Successfull);

            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);
            chainblock.Add(transaction5);

            var status = TransactionStatus.Successfull;
            var amount = 50;

            var transactions = chainblock
                .GetByTransactionStatusAndMaximumAmount(status, amount)
                .ToList();

            // Assert
            Assert.That(transactions.Count == 0);
        }

        [Test]
        public void Get_By_Transaction_Status_And_Maximum_Amount_Should_Throw_An_Exception_If_Amount_Is_Zero()
        {
            // Arrange
            var chainblock = new Models.Chainblock();

            // Assert
            Assert.Throws<InvalidOperationException>(
                () => chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Successfull, -1000), // Act
                "Amount is not under zero");
        }

        [Test]
        public void Get_By_Sender_And_Minimum_Amount_Should_Work_Correctly()
        {
            // Arrange
            var chainblock = new Models.Chainblock();

            // Act
            var transaction1 = new Transaction(100, "Peshko", "Samuilcho", 100, TransactionStatus.Successfull);
            var transaction2 = new Transaction(101, "Peshko", "Samuilcho", 200, TransactionStatus.Successfull);
            var transaction3 = new Transaction(102, "Peshko", "Samuilcho", 300, TransactionStatus.Successfull);
            var transaction4 = new Transaction(103, "Peshko", "Samuilcho", 400, TransactionStatus.Successfull);
            var transaction5 = new Transaction(104, "Peshko", "Samuilcho", 400, TransactionStatus.Successfull);

            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);
            chainblock.Add(transaction5);

            var sender = "Peshko";
            var amount = 200;

            var transactions = chainblock
                .GetBySenderAndMinimumAmountDescending(sender, amount)
                .ToList();

            // Assert
            Assert.That(transactions[0].Id, Is.EqualTo(104));
            Assert.That(transactions[1].Id, Is.EqualTo(103));
            Assert.That(transactions[2].Id, Is.EqualTo(102));
            Assert.That(transactions[3].Id, Is.EqualTo(101));
        }

        [Test]
        public void Get_By_Sender_And_Minimum_Amount_Descending_Should_Throw_An_Exception_If_No_Transactions_Found()
        {
            // Arrange
            var chainblock = new Models.Chainblock();

            // Assert
            Assert.Throws<InvalidOperationException>(
                () => chainblock.GetBySenderAndMinimumAmountDescending("sender", 1), // Act
                "There is transaction.");
        }

        [Test]
        public void Get_By_Sender_And_Minimum_Amount_Should_Throw_An_Exception_If_Amount_Is_Zero()
        {
            // Arrange
            var chainblock = new Models.Chainblock();

            // Assert
            Assert.Throws<InvalidOperationException>(
                () => chainblock.GetBySenderAndMinimumAmountDescending("Ivan", -1000), // Act
                "Amount is not under zero");
        }

        [Test]
        public void Get_By_Receiver_And_Amount_Range_Should_Work_Correctly()
        {
            // Arrange
            var chainblock = new Models.Chainblock();

            var transaction1 = new Transaction(100, "Peshko", "Samuilcho", 100, TransactionStatus.Successfull);
            var transaction2 = new Transaction(101, "Peshko", "Samuilcho", 200, TransactionStatus.Successfull);
            var transaction3 = new Transaction(102, "Peshko", "Samuilcho", 300, TransactionStatus.Successfull);
            var transaction4 = new Transaction(103, "Peshko", "Samuilcho", 400, TransactionStatus.Successfull);
            var transaction5 = new Transaction(104, "Peshko", "Samuilcho", 400, TransactionStatus.Successfull);

            // Act
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);
            chainblock.Add(transaction5);

            var receiver = "Samuilcho";

            var lo = 200;
            var hi = 400;

            var transactions = chainblock
                .GetByReceiverAndAmountRange(receiver, lo, hi)
                .ToList();

            // Assert
            Assert.That(transactions[0].Id, Is.EqualTo(102));
            Assert.That(transactions[1].Id, Is.EqualTo(101));
        }

        [Test]
        public void Get_By_Receiver_And_Amount_Range_Should_Throw_An_Exception_If_No_Transaction_Is_Found()
        {
            // Arrange
            var chainblock = new Models.Chainblock();

            // Assert
            Assert.Throws<InvalidOperationException>(
                () => chainblock.GetByReceiverAndAmountRange("A", 1, 2), // Act
                "There is existing transaction");
        }

        [Test]
        public void Get_By_Receiver_And_Amount_Range_Should_Throw_An_Exception_If_Lo_Is_Under_Zero()
        {
            // Arrange
            var chainblock = new Models.Chainblock();

            // Assert
            Assert.Throws<InvalidOperationException>(
                () => chainblock.GetByReceiverAndAmountRange("A", -1, 2), // Act
                "Lo is not under zero.");
        }

        [Test]
        public void Get_By_Receiver_And_Amount_Range_Should_Throw_An_Exception_If_Hi_Is_Under_Zero()
        {
            // Arrange
            var chainblock = new Models.Chainblock();

            // Assert
            Assert.Throws<InvalidOperationException>(
                () => chainblock.GetByReceiverAndAmountRange("A", 1, -2), // Act
                "Hi is not under zero");
        }

        [Test]
        public void Get_All_In_Amount_Range_Should_Work_Correctly()
        {
            // Arrange
            var chainblock = new Models.Chainblock();

            var transaction0 = new Transaction(99, "Peshko", "Samuilcho", 10, TransactionStatus.Successfull);
            var transaction1 = new Transaction(100, "Peshko", "Samuilcho", 100, TransactionStatus.Successfull);
            var transaction2 = new Transaction(101, "Peshko", "Samuilcho", 200, TransactionStatus.Successfull);
            var transaction3 = new Transaction(102, "Peshko", "Samuilcho", 300, TransactionStatus.Successfull);
            var transaction4 = new Transaction(103, "Peshko", "Samuilcho", 400, TransactionStatus.Successfull);
            var transaction5 = new Transaction(104, "Peshko", "Samuilcho", 400, TransactionStatus.Successfull);

            // Act
            chainblock.Add(transaction0);
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);
            chainblock.Add(transaction5);

            var lo = 100;
            var hi = 400;

            var transactions = chainblock
                .GetAllInAmountRange(lo, hi)
                .ToList();

            // Assert
            Assert.That(transactions[0].Id, Is.EqualTo(100));
            Assert.That(transactions[1].Id, Is.EqualTo(101));
            Assert.That(transactions[2].Id, Is.EqualTo(102));
            Assert.That(transactions[3].Id, Is.EqualTo(103));
            Assert.That(transactions[4].Id, Is.EqualTo(104));
        }

        [Test]
        public void Get_All_In_Amount_Range_Should_Return_Empty_Collection()
        {
            // Arrange
            var chainblock = new Models.Chainblock();

            var transaction = new Transaction(104, "Peshko", "Samuilcho", 4100, TransactionStatus.Successfull);

            // Act
            chainblock.Add(transaction);

            var lo = 100;
            var hi = 400;

            var transactions = chainblock
                .GetAllInAmountRange(lo, hi)
                .ToList();

            // Assert
            Assert.That(transactions.Count == 0);
        }

        [Test]
        public void Get_All_In_Amount_Range_Should_Throw_An_Exception_If_Lo_Is_Under_Zero()
        {
            // Arrange
            var chainblock = new Models.Chainblock();

            // Assert
            Assert.Throws<InvalidOperationException>(
                () => chainblock.GetAllInAmountRange(-1, 2), // Act
                "Lo is not under zero.");
        }

        [Test]
        public void Get_All_In_Amount_Range_Should_Throw_An_Exception_If_Hi_Is_Under_Zero()
        {
            // Arrange
            var chainblock = new Models.Chainblock();

            // Assert
            Assert.Throws<InvalidOperationException>(
                () => chainblock.GetAllInAmountRange(1, -2), // Act
                "Hi is not under zero");
        }
    }
}
