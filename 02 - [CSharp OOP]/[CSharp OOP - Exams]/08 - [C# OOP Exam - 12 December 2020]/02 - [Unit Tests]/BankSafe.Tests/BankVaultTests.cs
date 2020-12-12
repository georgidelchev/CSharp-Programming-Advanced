using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor_Should_Set_Values_Correctly()
        {
            var bankVault = new BankVault();

            Assert.IsNotNull(bankVault);
            Assert.That(bankVault.VaultCells.Count, Is.EqualTo(12));
        }

        [Test]
        public void Add_Item_Should_Throw_An_Exception_If_Cell_Is_Non_Existing()
        {
            var bankVault = new BankVault();

            Assert.Throws<ArgumentException>(() =>
                bankVault.AddItem("90", new Item("Ivan", "5")));
        }

        [Test]
        public void Add_Item_Should_Throw_An_Exception_If_Cell_Is_Taken()
        {
            var bankVault = new BankVault();

            bankVault.AddItem("A1", new Item("Ivan", "5"));

            Assert.Throws<ArgumentException>(() =>
                bankVault.AddItem("A1", new Item("90", "5")));
        }

        [Test]
        public void Add_Item_Should_Throw_An_Exception_If_Cell_Has_Already_Item()
        {
            var bankVault = new BankVault();

            var item = new Item("Ivan", "5");

            bankVault.AddItem("A1", item);

            Assert.Throws<InvalidOperationException>(() =>
                bankVault.AddItem("A2", item));
        }

        [Test]
        public void Remove_Item_Should_Throw_An_Exception_If_Cell_Is_Non_Existing()
        {
            var bankVault = new BankVault();

            Assert.Throws<ArgumentException>(() =>
                bankVault.RemoveItem("90", new Item("Ivan", "5")));
        }

        [Test]
        public void Remove_Item_Should_Throw_An_Exception_If_Item_In_That_Cell_Is_Not_Existing()
        {
            var bankVault = new BankVault();

            var item = new Item("Pesho", "31");

            bankVault.AddItem("A1", new Item("Ivan", "5"));

            Assert.Throws<ArgumentException>(() =>
                bankVault.RemoveItem("A1", item));
        }

        [Test]
        public void Remove_Should_Remove_Item_Correctly()
        {
            var bankVault = new BankVault();

            var item = new Item("Pesho", "31");

            bankVault.AddItem("A1", item);

            var removedItem = bankVault.RemoveItem("A1", item);

            Assert.That(removedItem, Is.EqualTo($"Remove item:{item.ItemId} successfully!"));
            Assert.That(bankVault.VaultCells["A1"], Is.EqualTo(null));
        }
    }
}