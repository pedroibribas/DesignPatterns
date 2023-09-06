using System.Threading.Channels;

namespace Strategy;

public class BankAccount
{
    public double Balance { get; set; }

    public BankAccount(double balance)
    {
        Balance = balance;
    }

    public double Invest(string strategy)
    {
        if (strategy == "CONSERVADOR")
            return Balance * 0.08;

        int chance = new Random().Next(101);
        
        if (strategy == "MODERADO")
        {
            if (chance < 50) 
                return Balance * 0.25;

            return Balance * 0.07;
        }

        if (strategy == "ARROJADO")
        {
            if (chance < 20)
                return Balance * 0.5;
            if (chance < 30)
                return Balance * 0.3;
            return Balance * 0.06;
        }

        return 0;
    }

    public double Invest(IInvestimentStrategy investiment)
    {
        return investiment.GetInvestimentResult(Balance);
    }
}

public interface IInvestimentStrategy
{
    double GetInvestimentResult(double balance);
}
public class Conservative : IInvestimentStrategy
{
    public double GetInvestimentResult(double balance)
    {
        return balance * 0.08;
    }
}
public class Moderate : IInvestimentStrategy
{
    public double GetInvestimentResult(double balance)
    {
        if (new Random().Next(101) < 50)
            return balance * 0.25;

        return balance * 0.07;
    }
}
public class Brave : IInvestimentStrategy
{
    public double GetInvestimentResult(double balance)
    {
        int chance = new Random().Next(101);
        
        if (chance < 20)
            return balance * 0.5;

        if (chance < 30)
            return balance * 0.3;
        
        return balance * 0.06;
    }
}