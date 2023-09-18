namespace Decorator.Filter;

public class BiggerThanFiveHundred : FilterTemplate
{
    public BiggerThanFiveHundred()
    {
    }

    public BiggerThanFiveHundred(FilterTemplate nextFilter) : base(nextFilter)
    {
    }

    protected override bool CheckAcc(BankAcc acc) => acc.Balance > 500;
}
