using System.Linq.Expressions;
using BAMS.Heart.InterestRate.Interfaces;

namespace BAMS.Heart.CreditCard;

public class CreditCard
{
    public decimal Duty { get; set; }
    public decimal Remainder { get; set; }
    private IInterestRateManager _interestRateManager;

    public CreditCard(IInterestRateManager interestRateManager)
    {
        _interestRateManager = interestRateManager;
        Duty = 0;
        Remainder = 10000;
    }

    public bool Pay(decimal amount)
    {
        if (amount < 0)
            throw new Exception("Amount can't be less than zero!");
        if (amount <= Remainder)
            try
            {
                Duty += _interestRateManager.GetInterestRate(Remainder, Duty);
                Remainder -= amount;
            }
            catch
            {
                throw new Exception("Pay operation error!");
            }
        return true;
    }
}
