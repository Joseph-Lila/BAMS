namespace BAMS.Heart.CreditDepartment;

public class CreditDepartment
{
    private const decimal LimitForCardRelease = 100;

    public static bool ReleaseCard(BankAccount.BankAccount bankAccount) => bankAccount.Balance >= LimitForCardRelease;
}