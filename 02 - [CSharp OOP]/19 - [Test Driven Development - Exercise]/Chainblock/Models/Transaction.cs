using System;
using System.Collections.Generic;
using System.Text;
using Chainblock.Contracts;

namespace Chainblock.Models
{
    public class Transaction : ITransaction
    {
        private int id;
        private string from;
        private string to;
        private double amount;

        public Transaction(int id, string from, string to, double amount, TransactionStatus transactionStatus)
        {
            this.Id = id;
            this.From = from;
            this.To = to;
            this.Amount = amount;
            this.Status = transactionStatus;
        }

        public int Id
        {
            get
            {
                return this.id;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Id can not be less than zero.");
                }

                this.id = value;
            }
        }

        public string From
        {
            get
            {
                return this.from;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("From can not be null.");
                }

                if (value.Length < 3)
                {
                    throw new ArgumentException("From can not be less than 3 symbols.");
                }

                this.from = value;
            }

        }

        public string To
        {
            get
            {
                return this.to;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("To can not be null.");
                }

                if (value.Length < 3)
                {
                    throw new ArgumentException("To can not be less than 3 symbols.");
                }

                this.to = value;
            }

        }

        public double Amount
        {
            get
            {
                return this.amount;
            }
            private set
            {
                if (value<0)
                {
                    throw new ArgumentException("Amount can not be less than zero.");
                }

                this.amount = value;
            }
        }

        public TransactionStatus Status { get; set; }
    }
}
