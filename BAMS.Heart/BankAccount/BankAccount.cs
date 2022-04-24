using BAMS.Heart.Customer;
using BAMS.Heart.Customer.Interfaces;
using BAMS.Heart.InterestRate;

namespace BAMS.Heart.BankAccount;

public class BankAccount
{
    private readonly ICustomer _user;
    private CreditCard.CreditCard? _creditCard;
    public decimal Balance;
    private const decimal WithdrawLimit = 200;

    public BankAccount(ICustomer customer)
    {
        _user = customer;
        _creditCard = null;
        Balance = 0;
    }
    
    public void ShowBalanceInfo()
    {
        Logger.Logger.Log("{" + (_user.SsnNumber / 1000000).ToString() + "}-" +
                          "{" + ((_user.SsnNumber - _user.SsnNumber / 1000000 * 1000000) / 10000).ToString() + "}-" +
                          "{" + (_user.SsnNumber - (_user.SsnNumber - _user.SsnNumber / 1000000 * 1000000) / 10000 * 10000)
                          .ToString() + "} <---> " +
                          $"{_user.FirstName} {_user.LastName}: {Balance}");
    }

    public bool Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new Exception("Amount should be more than zero!");
        Balance += amount;
        Logger.Logger.Log("Funds have been credited to your account!");
        return true;
    }

    public bool Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new Exception("Amount should be more than zero!");
        if (_user.GetType() == typeof(OrdinaryCustomer))
        {
            if (amount < WithdrawLimit)
                return false;
        }
        if (amount <= Balance)
        {
                Balance -= amount;
                Logger.Logger.Log($"Funds {amount} have been took from your account!");
                return true;
        }
        return false;
    }

    public bool GetCreditCard()
    {
        if (CreditDepartment.CreditDepartment.ReleaseCard(this))
        {
            _creditCard = new CreditCard.CreditCard(
                    new BaseInterestRateManager(
                        new decimal[] {100, 200, 500, 1000, 5000, 15000},
                        new decimal[]
                        {
                            (decimal) 0.8, (decimal) 0.02, (decimal) 0.02, (decimal) 0.02, (decimal) 0.02,
                            (decimal) 0.02
                        },
                        new decimal[] {100, 200, 500, 1000, 5000, 15000},
                        new decimal[]
                        {
                            (decimal) 0.8, (decimal) 0.02, (decimal) 0.02, (decimal) 0.02, (decimal) 0.02,
                            (decimal) 0.02
                        }
                    )
                );
            Logger.Logger.Log($"Credit Card was successfully created!");
            return true;
        }
        Logger.Logger.Log($"Sorry, but Credit Department didn't give permission for Credit Card creation!");
        return false;
    }

    public bool CloseCreditCard()
    {
        if (_creditCard != null && Balance >= _creditCard.Duty)
        {
            Balance -= _creditCard.Duty;
            _creditCard = null;
            Logger.Logger.Log($"Credit Card was successfully closed!");
            return true;
        }
        Logger.Logger.Log($"Make sure you have enough money on the balance and you really have a Credit Card!");
        return false;
    }
}