using System;
using BorisBikes_DotNetCore.Models;
using Xunit;

namespace BorisBikes_DotNetCore_Tests
{
    public class PaymentCardTests
    {
        [Fact]
        public void PaymentCard_ShouldInitialiseCorrectly()
        {
            var card = new PaymentCard();

            Assert.Equal(0, card.Balance);
            Assert.IsType<Guid>(card.AccountNumber);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        public void PaymentCard_ShouldBeAbleToInitialiseWithAnOpeningBalance(int balance)
        {
            var card = new PaymentCard(balance);

            Assert.Equal(balance, card.Balance);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        public void PaymentCard_Debit_ShouldAddFundsToBalance_WhenDebitted(int debitAmount)
        {
            var card = new PaymentCard();

            Assert.Equal(0, card.Balance);

            card.Debit(debitAmount);

            Assert.Equal(debitAmount, card.Balance);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        public void PaymentCard_Credit_ShouldRemoveFundsFromBalance_WhenCredited(int creditAmount)
        {
            var startingBalance = 1000;
            var card = new PaymentCard(startingBalance);

            Assert.Equal(startingBalance, card.Balance);

            card.Credit(creditAmount);
            var newBalance = startingBalance - creditAmount;

            Assert.Equal(newBalance, card.Balance);
        }

        [Fact]
        public void PaymentCard_Credit_ShouldThrowException_WhenCardDoesNotHaveSufficientFunds()
        {
            var card = new PaymentCard();

            Assert.Throws<Exception>(() => card.Credit(10));
        }
    }
}