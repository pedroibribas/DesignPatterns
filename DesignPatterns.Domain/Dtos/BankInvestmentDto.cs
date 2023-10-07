using DesignPatterns.Domain.Enums;

namespace DesignPatterns.Domain.Dtos;

public record BankInvestmentDto(
    double BankAccountBalance,
    BankInvestmentType InvestmentType);
