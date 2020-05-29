using System;

namespace BorisBikes_DotNetCore.Models
{
    public class PaymentCard
    {
        public int Balance { get; private set; }
        public Guid AccountNumber { get; private set; }

        public PaymentCard(int balance = 0)
        {
            Balance = balance;
            AccountNumber = Guid.NewGuid();
        }

        public void Debit(int debitAmount)
        {
            Balance += debitAmount;
        }

        public void Credit(int creditAmount)
        {
            if (Balance - creditAmount < 0)
                throw new Exception("Insufficient funds to make transaction");

            Balance -= creditAmount;
        }
    }
}