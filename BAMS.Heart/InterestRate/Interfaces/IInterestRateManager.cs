namespace BAMS.Heart.InterestRate.Interfaces;

public interface IInterestRateManager : IInterestRateByBalance, IInterestRateByTransactionsHistory
{
    public decimal GetInterestRate(decimal balance, decimal duty);
}