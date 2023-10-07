
using DesignPatterns.Domain.Interfaces;

namespace DesignPatterns.Domain.Entities;

public record MoneyInvestmentCalculator(IInvestimentStrategy InvestimentStrategy)
{
    public IInvestimentStrategy InvestimentStrategy { get; private set; } = InvestimentStrategy;

    public double Invest(double amount) =>
        InvestimentStrategy.Invest(amount);
}

/*
 * antes:
 ```
    public static double InvestAsConservative(double amount) => amount * 0.01;    
    public static double InvestAsModerate(double amount) => amount * 0.05;
    public static double InvestAsBold(double amount) => amount * 0.1;
 ```
 * depois:
 ```
    public double Invest(double amount) => InvestimentStrategy.Invest(amount);
 ```
 */