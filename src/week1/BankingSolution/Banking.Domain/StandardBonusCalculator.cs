
namespace Banking.Domain;

public class StandardBonusCalculator
{


  public decimal CalculateBonusForDeposit(decimal balance, decimal depositAmount)
  {
        return balance >= 5000 ? depositAmount * .10M : 0;
  }
}