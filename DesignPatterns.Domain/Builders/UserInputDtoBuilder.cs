using DesignPatterns.Domain.Dtos;
using DesignPatterns.Domain.Enums;

namespace DesignPatterns.Domain.Builders;

public class UserInputDtoBuilder
{
    private double BankAccountBalance { get; set; }
    private BankInvestmentType BankInvestmentType { get; set; }

    public UserInputDto Build() => new()
        {
            BankAccountBalance = BankAccountBalance,
            BankInvestmentType = BankInvestmentType
        };

    public UserInputDtoBuilder WithBankAccountBalance(double bankAccountBalance)
    {
        BankAccountBalance = bankAccountBalance;
        return this;
    }

    public UserInputDtoBuilder WithBankInvestmentType(BankInvestmentType investmentType)
    {
        BankInvestmentType = investmentType;
        return this;
    }
}