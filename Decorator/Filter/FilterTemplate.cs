namespace Decorator.Filter;

public abstract class FilterTemplate
{
    public FilterTemplate? NextFilter { get; private set; }

    public FilterTemplate(FilterTemplate nextFilter)
    {
        NextFilter = nextFilter;
    }

    public FilterTemplate()
    {
    }

    public List<string> Filter(List<BankAcc> accs, List<string>? filteredAccs = null)
    {
        filteredAccs ??= new();

        foreach (var acc in accs)
        {
            if(CheckAcc(acc)) filteredAccs.Add(acc.Name);
        }

        if (NextFilter != null)
            return NextFilter.Filter(accs, filteredAccs);

        return filteredAccs;
    }

    protected abstract bool CheckAcc(BankAcc acc);
}
