using BAMS.Heart.InterestRate.Interfaces;

namespace BAMS.Heart.InterestRate;

public class BaseInterestRateManager : IInterestRateManager
{
    public decimal[] InterestRateByBalanceCheckPoints { get; set; }
    public decimal[] InterestRateByBalanceValues { get; set; }
    public decimal[] InterestRateByTransactionsHistoryCheckPoints { get; set; }
    public decimal[] InterestRateByTransactionsHistoryValues { get; set; }

    public BaseInterestRateManager(
        decimal[] interestRateByBalanceCheckPoints,
        decimal[] interestRateByBalanceValues,
        decimal[] interestRateByTransactionsHistoryCheckPoints,
        decimal[] interestRateByTransactionsHistoryValues)
    {
        InterestRateByBalanceCheckPoints = interestRateByBalanceCheckPoints;
        InterestRateByBalanceValues = interestRateByBalanceValues;
        InterestRateByTransactionsHistoryCheckPoints = interestRateByTransactionsHistoryCheckPoints;
        InterestRateByTransactionsHistoryValues = interestRateByTransactionsHistoryValues;
    }
    public decimal GetInterestRateByBalance(decimal amount)
    {
        if (
            InterestRateByBalanceValues.Length != InterestRateByBalanceCheckPoints.Length
        ) throw new Exception("There is a difference between initial values elements quantities!");
        decimal startInterestRate = 1;
        decimal currentValue = -1;
        for (int i = 0; i < InterestRateByBalanceValues.Length; ++i)
        {
            if (currentValue < InterestRateByBalanceCheckPoints[i])
                break;
            startInterestRate -= InterestRateByBalanceValues[i];
        }
        return startInterestRate;
    }

    public decimal GetInterestRate(decimal balance, decimal duty)
    {
        return (GetInterestRateByBalance(balance) + GetInterestRateByTransactionsHistory(duty)) / 2;
    }

    public decimal GetInterestRateByTransactionsHistory(decimal amount)
    {
        if (
            InterestRateByTransactionsHistoryValues.Length != InterestRateByTransactionsHistoryCheckPoints.Length
        ) throw new Exception("There is a difference between initial values elements quantities!");
        decimal startInterestRate = 1;
        decimal currentValue = -1;
        for (int i = 0; i < InterestRateByTransactionsHistoryValues.Length; ++i)
        {
            if (currentValue < InterestRateByTransactionsHistoryCheckPoints[i])
                break;
            startInterestRate -= InterestRateByTransactionsHistoryValues[i];
        }
        return startInterestRate;
    }
}