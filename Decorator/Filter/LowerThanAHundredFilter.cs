namespace Decorator.Filter;

public class LowerThanAHundredFilter : FilterTemplate
{
    public LowerThanAHundredFilter()
    {
    }

    public LowerThanAHundredFilter(FilterTemplate nextFilter) : base(nextFilter)
    {
    }

    protected override bool CheckAcc(BankAcc acc) => acc.Balance < 100;
}
