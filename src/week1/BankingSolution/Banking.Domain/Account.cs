


namespace Banking.Domain;

public enum AccountTypes {  Standard, Gold, Platinum};
public class Account
{
    private decimal _currentBalance = 5000;
    public AccountTypes AccountType = AccountTypes.Standard; // zero mean standard account, 1 means it is a Gold account, 2 Plant
    // Queries (methods where we ask for stuff)
    public decimal GetBalance()
    { 
        return _currentBalance;
    }
    public void Deposit(decimal amountToDeposit)
    {
        var bonus = 0M;
        if (AccountType == AccountTypes.Gold)
        {
            bonus = amountToDeposit * .20M;
        }
        CheckTransactionAmount(amountToDeposit);
        _currentBalance += amountToDeposit + bonus;
    }

    // Commands - telling our account to do some work.
    public void Withdraw(decimal amountToWithdraw)
    {
        CheckTransactionAmount(amountToWithdraw);
        if (_currentBalance >= amountToWithdraw)
        {
            _currentBalance -= amountToWithdraw;
        }
        else
        {
            throw new AccountOverdraftException();
        }

    }

    // Helpers, etc. extracted from the above.
    private void CheckTransactionAmount(decimal amount)
    {
        if (amount < 0)
        {
            throw new AccountNegativeTransactionAmountException();
        }
    }
}


