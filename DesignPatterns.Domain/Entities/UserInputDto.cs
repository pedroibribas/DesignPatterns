using DesignPatterns.Domain.Enums;

namespace DesignPatterns.Domain.Dtos;

public class UserInputDto
{
    public double? BankAccountBalance { get; set; }
    public BankInvestmentType? BankInvestmentType { get; set; }
}