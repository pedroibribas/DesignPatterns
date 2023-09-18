namespace Decorator.Filter;

public class CreatedAtCurrentMonth : FilterTemplate
{
    public CreatedAtCurrentMonth()
    {
    }

    public CreatedAtCurrentMonth(FilterTemplate nextFilter) : base(nextFilter)
    {
    }

    protected override bool CheckAcc(BankAcc acc) => DateTime.Now.Month == acc.CreatedAt.Month;
}
