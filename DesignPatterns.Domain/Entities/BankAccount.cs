
using DesignPatterns.Domain.Interfaces;

namespace DesignPatterns.Domain.Entities;

public class BankAccount
{
    public double Balance { get; private set; }

    public BankAccount(double? balance) =>
        Balance = balance ?? 0;

    public void InvestMoney(IInvestimentStrategy investimentStrategy)
    {
        MoneyInvestmentCalculator calculator = new(investimentStrategy);
        double investimentResult = calculator.Invest(Balance);
        DepositMoney(investimentResult);
    }

    private void DepositMoney(double investimentResult) =>
        Balance += investimentResult;
}