

using Banking.Domain;

namespace Banking.Tests.BonusCalculation;
public class StandardBonusCalculatorTests
{
    [Theory]
    [InlineData(5000, 100, 20)]
    [InlineData(5000, 200, 40)]
    [InlineData(10_000, 200, 40)]
   
    public void BonusesThatMeetThresholdGetBonus(decimal balance, decimal depositAmount, decimal expectedBonus)
    {
        var bonusCalculator = new StandardBonusCalculator();

        decimal bonus = bonusCalculator.CalculateBonusForDeposit(balance, depositAmount);

        Assert.Equal(expectedBonus, bonus);

    }
    [Theory]
    [InlineData(5, 100, 0)]
    [InlineData(4999.99, 200, 0)]
    [InlineData(0, 1000, 0)]

    public void BonusesBelowThresholdGetnoBonus(decimal balance, decimal depositAmount, decimal expectedBonus)
    {
        var bonusCalculator = new StandardBonusCalculator();

        decimal bonus = bonusCalculator.CalculateBonusForDeposit(balance, depositAmount);

        Assert.Equal(expectedBonus, bonus);

    }
}
