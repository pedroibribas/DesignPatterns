using DesignPatterns.DesignPatternApp.Templates;
using DesignPatterns.Domain.Entities;
using DesignPatterns.Domain.Interfaces;
using DesignPatterns.StrategyPattern.Strategies;

namespace DesignPatterns.StrategyPattern;

public class TaxOnBudgetCalculation : DesignPatternAppTemplate
{
    protected override List<string> GetResults(List<string> results)
    {
        BalanceTaxCalculator balanceTaxCalculator = new(GetTax());
        Bugdet bugdet = new(balance: 500);
        double calcResult = balanceTaxCalculator.Calculate(bugdet.Balance);
        
        results.Add(calcResult.ToString());
        
        return results;
    }

    private IBudgetTax GetTax() => new ICMS();
}