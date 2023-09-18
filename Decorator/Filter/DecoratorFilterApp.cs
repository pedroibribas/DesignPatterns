namespace Decorator.Filter;

public class DecoratorFilterApp : DesignPatternsApp
{
    protected override string GetAppName() => nameof(DecoratorFilterApp);

    protected override List<string> GetResults() => BankAccFilter.GetFilteredAccs(new List<BankAcc>
    {
        new("Louis", 90, new DateTime(2023, 08, 20)),
        new("Joseph", 600, new DateTime(2023, 07, 15)),
        new("Mark", 400, DateTime.Now),
        new("Peter", 200, new DateTime(2023, 08, 20)),
    });
}
