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
  }
}