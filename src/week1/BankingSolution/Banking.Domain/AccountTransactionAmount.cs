
using System.Reflection.Metadata.Ecma335;

namespace Banking.Domain;

public record struct AccountTransactionAmount
{
  private readonly decimal _amount;

  //public decimal GetValue()
  //{
  //  return _amount;
  //}
  public decimal Value {
    get
    {
      return _amount; 
    }
    
  }
 

  public AccountTransactionAmount(decimal value)
  {
    if (value < 0)
    {
      throw new AccountNegativeTransactionAmountException();
    }
    if (value > 10_000)
    {
      throw new AccountTranactionAmountBeyondLimits();
    }
    _amount = value;
  }

  public static implicit operator Decimal(AccountTransactionAmount a) => a.Value;

  public static implicit operator AccountTransactionAmount(decimal value) => new(value);
  

}
