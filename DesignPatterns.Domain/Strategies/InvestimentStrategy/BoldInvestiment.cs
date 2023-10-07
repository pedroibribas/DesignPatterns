
using DesignPatterns.Domain.Interfaces;

namespace DesignPatterns.Domain.Entities;

public class BoldInvestiment : IInvestimentStrategy
{
    public double Invest(double amount) => amount * 0.08;
}