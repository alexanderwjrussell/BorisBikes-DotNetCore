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
    }
}