namespace BAMS.Heart.InterestRate.Interfaces;

public interface IInterestRateByBalance
{
    public decimal[] InterestRateByBalanceCheckPoints { get; set; }
    public decimal[] InterestRateByBalanceValues { get; set; }
    public decimal GetInterestRateByBalance(decimal amount);
}