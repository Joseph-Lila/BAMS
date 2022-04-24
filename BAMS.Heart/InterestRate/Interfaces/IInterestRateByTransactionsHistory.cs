namespace BAMS.Heart.InterestRate.Interfaces;

public interface IInterestRateByTransactionsHistory
{
    public decimal[] InterestRateByTransactionsHistoryCheckPoints { get; set; }
    public decimal[] InterestRateByTransactionsHistoryValues { get; set; }

    public decimal GetInterestRateByTransactionsHistory(decimal amount);
}