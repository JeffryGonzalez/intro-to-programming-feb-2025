

namespace Banking.Tests.Values;
public class AccountTransactionAmountTests
{
  [Fact]
  public void ThrowsOnNegativeAmount()
  {
    Assert.Throws<AccountNegativeTransactionAmountException>(() => new AccountTransactionAmount(-3));
  }

  [Fact]
  public void ThrowsOnAmountsOverThreshold()
  {
    Assert.Throws<AccountTranactionAmountBeyondLimits>(() => new AccountTransactionAmount(10_000.01M));
  }

  [Fact]
  public void CanGetValue()
  {
    var amountToDeposit = new AccountTransactionAmount(232.55M);

    decimal balance = amountToDeposit;

    AccountTransactionAmount yourPay = 12.23M;

   Assert.Equal<decimal>(232.55M, amountToDeposit);
  }
}
