
using Banking.Domain;

namespace Banking.Tests.GoldAccounts;
public class GetBonusOnDeposits
{

    [Fact]
    public void GetBonus()
    {
        // Given - Arrange - "Establishing the context for this test"
        var account = new Account();
        var openingBalance = account.GetBalance();
        var amountToDeposit = 100M;
        var expectedBonus = 20M;
        var expectedNewBalance = openingBalance + amountToDeposit + expectedBonus;
        account.AccountType = AccountTypes.Gold;

        // When - Act
        account.Deposit(amountToDeposit);

        // Then - Assert
        Assert.Equal(expectedNewBalance, account.GetBalance());
            
    }
}
