
using DesignPatterns.Domain.Interfaces;

namespace DesignPatterns.Domain.Entities;

public class ModerateInvestiment : IInvestimentStrategy
{
    public double Invest(double amount) => amount * 0.04;
}
