namespace Decorator.Filter;

public class BankAccFilter
{
    public static List<string> GetFilteredAccs(List<BankAcc> accs)
    {
        var handler = GetFilterMethod(FilterMethod.First);
        var validAccs = handler.Filter(accs);
        return validAccs;
    }

    private static FilterTemplate GetFilterMethod(FilterMethod method) => method switch
    {
        FilterMethod.First => FirstMethod(),
        FilterMethod.Second => SecondMethod(),
        FilterMethod.Third => ThirdMethod(),
        _ => FirstMethod(),
    };

    private static FilterTemplate FirstMethod() => new LowerThanAHundredFilter(new BiggerThanFiveHundred(new CreatedAtCurrentMonth()));

    private static FilterTemplate SecondMethod() => new CreatedAtCurrentMonth(new BiggerThanFiveHundred());

    private static FilterTemplate ThirdMethod() => new BiggerThanFiveHundred(new LowerThanAHundredFilter());
}
