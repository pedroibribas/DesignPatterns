using DesignPatterns.Domain.Interfaces;

namespace DesignPatterns.StrategyPattern.Strategies;

public class ISS : IBudgetTax
{
    public double Calculate(double budgetBalance) => budgetBalance * 0.6;
}