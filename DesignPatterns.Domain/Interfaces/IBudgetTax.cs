using DesignPatterns.Domain.Entities;

namespace DesignPatterns.Domain.Interfaces;

public interface IBudgetTax
{
    double Calculate(double budgetBalance);
}