using DesignPatternsApp;

namespace State.Budget;

public class StateBudgetApp : App
{
    protected override string GetAppName() => nameof(StateBudgetApp);

    protected override List<string> GetResults()
    {
        List<string> results = new();

        try
        {
            Budget budget = new(500);

            budget.ApplyDiscount();
            results.Add(budget.Balance.ToString());

            budget.Approve();
            budget.ApplyDiscount();
            results.Add(budget.Balance.ToString());

            budget.Finish();
            results.Add(budget.Balance.ToString());

            return results;
        }
        catch (Exception ex)
        {
            WriteError(ex.Message);
            return results;
        }
    }
}
