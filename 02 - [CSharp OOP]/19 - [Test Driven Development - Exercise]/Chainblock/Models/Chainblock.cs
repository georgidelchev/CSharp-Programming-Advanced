using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chainblock.Contracts;

namespace Chainblock.Models
{
    public class Chainblock : IChainblock
    {
        private readonly ICollection<ITransaction> transactions;

        public Chainblock(params ITransaction[] transactions)
        {
            this.transactions = transactions
                .ToList();
        }

        public IReadOnlyCollection<ITransaction> Transactions
                 => this.transactions
                     .ToList()
                     .AsReadOnly();

        public int Count
            => this.transactions.Count;

        public void Add(ITransaction tx)
        {
            if (this.transactions.All(t => t.Id != tx.Id))
            {
                this.transactions.Add(tx);
            }
            else
            {
                throw new InvalidOperationException("Transactions are same.");
            }
        }

        public bool Contains(ITransaction tx)
        {
            if (tx == null)
            {
                throw new ArgumentNullException("Transaction can not be null.");
            }

            return this.transactions.Contains(tx);
        }

        public bool Contains(int id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Id can not be under zero.");
            }

            return this.transactions.Any(t => t.Id == id);
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Id can not be under zero.");
            }

            if (this.transactions.All(t => t.Id != id))
            {
                throw new InvalidOperationException("This id is not found.");
            }

            this.transactions.First(t => t.Id == id).Status = newStatus;
        }

        public void RemoveTransactionById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Id can not be under zero.");
            }

            if (this.transactions.All(t => t.Id != id))
            {
                throw new InvalidOperationException("This id is not found.");
            }

            var transaction = this.transactions.First(t => t.Id == id);

            this.transactions.Remove(transaction);
        }

        public ITransaction GetById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Id can not be under zero.");
            }

            if (this.transactions.All(t => t.Id != id))
            {
                throw new InvalidOperationException("This id is not existing.");
            }

            var transaction = this.transactions
                .FirstOrDefault(t => t.Id == id);

            return transaction;
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            if (this.transactions.All(t => t.Status != status))
            {
                throw new InvalidOperationException("This status is not existing.");
            }

            IEnumerable<ITransaction> transaction = this.transactions
                .Where(t => t.Status == status)
                .OrderByDescending(t => t.Amount);

            return transaction;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            if (this.transactions.All(t => t.Status != status))
            {
                throw new InvalidOperationException("This status is not existing.");
            }

            var senders = this.transactions
                .Where(t => t.Status == status)
                .OrderByDescending(t => t.Amount)
                .ToList();

            var result = new List<string>();

            foreach (var item in senders)
            {
                result.Add(item.From);
            }

            return result;
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            if (this.transactions.All(t => t.Status != status))
            {
                throw new InvalidOperationException("This status is not existing.");
            }

            var receivers = this.transactions
                .Where(t => t.Status == status)
                .OrderByDescending(t => t.Amount)
                .ToList();

            var result = new List<string>();

            foreach (var item in receivers)
            {
                result.Add(item.To);
            }

            return result;
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            var result = this.transactions
                .OrderByDescending(t => t.Amount)
                .ThenByDescending(t => t.Id)
                .ToList();

            if (result.Count == 0)
            {
                throw new InvalidOperationException("There is no transactions.");
            }

            return result;
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            var result = this.transactions
                .Where(t => t.From == sender)
                .OrderByDescending(t => t.Amount)
                .ToList();

            if (result.Count == 0)
            {
                throw new InvalidOperationException("There is no transactions.");
            }

            return result;
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            var result = this.transactions
                .Where(t => t.From == receiver)
                .OrderByDescending(t => t.Amount)
                .ThenByDescending(t => t.Id)
                .ToList();

            if (result.Count == 0)
            {
                throw new InvalidOperationException("There is no transactions.");
            }

            return result;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            if (amount < 0)
            {
                throw new InvalidOperationException("Amount can not be under zero.");
            }

            var result = this.transactions
                .Where(t => t.Status == status && t.Amount <= amount)
                .OrderByDescending(t => t.Amount)
                .ToList();

            return result;
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            if (amount < 0)
            {
                throw new InvalidOperationException("Amount can not be under zero.");
            }

            var result = this.transactions
                .Where(t => t.From == sender && t.Amount >= amount)
                .OrderByDescending(t => t.Amount)
                .ThenByDescending(t => t.Id)
                .ToList();

            if (result.Count == 0)
            {
                throw new InvalidOperationException("No transaction found.");
            }

            return result;
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            if (lo < 0 || hi < 0)
            {
                throw new InvalidOperationException("Lo and Hi can not be under zero.");
            }

            var result = this.transactions
                .Where(t => t.To == receiver)
                .Where(t => t.Amount >= lo && t.Amount < hi)
                .OrderByDescending(t => t.Amount)
                .ThenByDescending(t => t.Id)
                .ToList();

            if (result.Count == 0)
            {
                throw new InvalidOperationException("No transaction found.");
            }

            return result;
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            if (lo < 0 || hi < 0)
            {
                throw new InvalidOperationException("Lo and Hi can not be under zero.");
            }

            var result = this.transactions
                .Where(t => t.Amount >= lo && t.Amount <= hi)
                .ToList();

            return result;
        }

        public IEnumerator<ITransaction> GetEnumerator()
            => this.transactions.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
