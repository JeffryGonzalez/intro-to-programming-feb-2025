
using Banking.Domain;

namespace Banking.Tests.Accounts;
public class MakingWithdrawals
{

    [Theory]
    [InlineData(42.23)]
    [InlineData(3.23)]
  
   
    public void MakingWithdrawalsDecreasesTheBalance(decimal amountToWithdraw)
    {
        var account = new Account();
        var openingBalance = account.GetBalance();
       

        account.Withdraw(amountToWithdraw);

        Assert.Equal(openingBalance - amountToWithdraw,
            account.GetBalance());
    }

    [Fact]
    public void CanWithdrawFullBalance()
    {
        var account = new Account();

        account.Withdraw(account.GetBalance());

        Assert.Equal(0, account.GetBalance());  
    }

    [Fact]
    public void WhenOverdraftBalanceIsNotReducedNotAllowed()
    {

        var account = new Account();
        var openingBalance = account.GetBalance();
        var amountThatRepresentsMoreThanTheCurrentBalance = openingBalance + .01M;

        account.Withdraw(amountThatRepresentsMoreThanTheCurrentBalance);

        Assert.Equal(openingBalance, account.GetBalance());
    }
}
