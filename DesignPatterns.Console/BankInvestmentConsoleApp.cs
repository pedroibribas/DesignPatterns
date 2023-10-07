using DesignPatterns.Domain.Builders;
using DesignPatterns.Domain.Dtos;
using DesignPatterns.Domain.Entities;
using DesignPatterns.Domain.Enums;
using DesignPatterns.Domain.Interfaces;
using DesignPatterns.StrategyPattern;

namespace DesignPatterns.Console;

public class BankInvestmentConsoleApp : IConsoleApp
{
    private string EntitiyToCreate { get; set; }
    private IDesignPatternApp App { get; set; }
    private readonly UserInputDtoBuilder UserInputDtoBuilder;

    public BankInvestmentConsoleApp()
    {
        App = new BankInvestmentApp();
        EntitiyToCreate = EntitiesToCreateByCommand.BankAccount.ToString();
        UserInputDtoBuilder = new();
    }

    public void Run(string userInput)
    {     
        if (!EnsureIsCreatingBankAccount(userInput))
            return;

        UserInputDto dto = BuildUserInputDto(userInput);
        App.With(dto);
        App.Run();
    }

    private UserInputDto BuildUserInputDto(string userInput) => UserInputDtoBuilder
        .WithBankAccountBalance(GetBankAccountBalance(userInput))
        .WithBankInvestmentType(GetBankInvestmentType(userInput))
        .Build();

    private BankInvestmentType GetBankInvestmentType(string userInput)
    {
        throw new NotImplementedException();
    }

    private bool EnsureIsCreatingBankAccount(string userInput)
    {
        CommandCreate commandCreate = new(userInput);
        string? entityName = commandCreate.CommandValue;
        return entityName == null || entityName.Equals(EntitiyToCreate);
    }

    private double GetBankAccountBalance(string userInput)
    {        
        int bankAccountBalanceIndex = userInput.IndexOf("-b") + 1; 
        return int.Parse(userInput[bankAccountBalanceIndex].ToString());
    }
}