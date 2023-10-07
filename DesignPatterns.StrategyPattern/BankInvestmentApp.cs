using DesignPatterns.DesignPatternApp.Templates;
using DesignPatterns.Domain.Dtos;
using DesignPatterns.Domain.Entities;
using DesignPatterns.Domain.Enums;
using DesignPatterns.Domain.Interfaces;
using DesignPatterns.Utils;

namespace DesignPatterns.StrategyPattern;

public class BankInvestmentApp : DesignPatternAppTemplate
{
    protected override List<string> GetResults(List<string> results)
    {
        if (EnsureBankInvestimentDto())
        {
            ConsoleHandler.WriteSingleLineError(
                $"Nenhum resultado da aplicação {AppName}: Os dados bancários são inválidos.");
            ConsoleHandler.WriteColoredSingleLine(ConsoleColor.Yellow,
                $"Inicialize uma conta bancária com saldo e tipo de investimento.");
            return results;
        }
        BankAccount bankAcc = new(UserInputDto.BankAccountBalance);

        results.Add($"Base de cálculo (saldo atual da conta bancária): {bankAcc.Balance}");

        switch (UserInputDto.BankInvestmentType)
        {
            case (BankInvestmentType.Conservative):
                Invest(bankAcc.Balance, strategy: new ConservativeInvestiment());
                break;
            
            case (BankInvestmentType.Moderate):
                Invest(bankAcc.Balance, strategy: new ModerateInvestiment());
                break;

            case (BankInvestmentType.Bold):
                Invest(bankAcc.Balance, strategy: new BoldInvestiment());
                break;
            
            default:
                break;
        }

        results.Add($"Saldo após investimento {UserInputDto.BankInvestmentType}: {bankAcc.Balance}");

        return results;
    }

    private bool EnsureBankInvestimentDto()
    {
        return UserInputDto != null
               && UserInputDto.BankAccountBalance > 0
               && !string.IsNullOrEmpty(UserInputDto.BankInvestmentType.ToString());
    }

    private void Invest(double balance, IInvestimentStrategy strategy)
    {
        MoneyInvestmentCalculator calculator = new(strategy);
        calculator.Invest(balance);
    }
}
