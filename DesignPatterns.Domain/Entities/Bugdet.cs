namespace DesignPatterns.Domain.Entities;
public class Bugdet
{
    public double Balance { get; private set; }

    public Bugdet(double balance)
    {
        Balance = balance;
    }
}
