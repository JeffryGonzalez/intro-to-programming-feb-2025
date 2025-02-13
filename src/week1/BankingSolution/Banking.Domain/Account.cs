


namespace Banking.Domain;


public class Account
{
    private decimal _currentBalance = 5000;
    public void Deposit(decimal amountToDeposit)
    {
        _currentBalance += amountToDeposit;
    }

    public decimal GetBalance()
    {
        // "Slime it"
        return _currentBalance; 
    }

    public void Withdraw(decimal amountToWithdraw)
    {
        if(amountToWithdraw < 0)
        {
            throw new AccountNegativeTransactionAmountException();
        }
        if (_currentBalance >= amountToWithdraw)
        {
            _currentBalance -= amountToWithdraw;
        }
        else
        {
            throw new AccountOverdraftException();
        }
       
    }
}


