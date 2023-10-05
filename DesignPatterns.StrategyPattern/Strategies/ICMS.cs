using DesignPatterns.Domain.Interfaces;

namespace DesignPatterns.StrategyPattern.Strategies;

public class ICMS : IBudgetTax
{
    public double Calculate(double budgetBalance) => budgetBalance * 0.1;
}