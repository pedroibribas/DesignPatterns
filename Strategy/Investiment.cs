namespace BudgetApp;

public class BankAccount
{
    public double Balance { get; set; }

    public BankAccount(double balance)
    {
        Balance = balance;
    }

    public void Deposit(double amount)
    {
        Balance += amount;
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

    public double Invest(IInvestiment investiment)
    {
        double result = investiment.Calculate(Balance);
        Deposit(result * 0.75);
        return Balance;
    }
}

public interface IInvestiment
{
    double Calculate(double balance);
}
public class Conservative : IInvestiment
{
    public double Calculate(double balance)
    {
        return balance * 0.008;
    }
}
public class Moderate : IInvestiment
{
    private readonly Random random;

    public Moderate()
    {
        random = new Random();
    }

    public double Calculate(double balance)
    {
        if (random.Next(101) < 50)
            return balance * 0.025;

        return balance * 0.007;
    }
}
public class Brave : IInvestiment
{
    private readonly Random random;

    public Brave()
    {
        random = new Random();
    }

    public double Calculate(double balance)
    {
        int chance = random.Next(101);
        
        if (chance >= 0 && chance <= 20) return balance * 0.5;
        if (chance < 30) return balance * 0.3;
        return balance * 0.006;
    }
}