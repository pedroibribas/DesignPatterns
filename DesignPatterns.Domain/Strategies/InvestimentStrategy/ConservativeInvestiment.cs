
using DesignPatterns.Domain.Interfaces;

namespace DesignPatterns.Domain.Entities;

public class ConservativeInvestiment : IInvestimentStrategy
{
    public double Invest(double amount) => amount * 0.01;
}
