namespace Chainblock.Contracts
{
    using System;

    public interface ITransaction
    {
        int Id { get; }

        TransactionStatus Status { get; set; }

        string From { get; }

        string To { get; }

        double Amount { get; }
    }
}