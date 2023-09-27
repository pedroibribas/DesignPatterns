using DesignPatternsApp;

namespace State.BankAccount;

public class StateBankAccountApp : App
{
    protected override string GetAppName() => nameof(StateBankAccountApp);

    protected override List<string> GetResults()
    {
        List<string> results = new();

        try
        {
            results = Case1(results);
            results = Case2(results);
        }
        catch (Exception ex)
        {
            WriteError($"[ERR] {ex.Message}");
        }

        return results;
    }

    private List<string> Case2(List<string> results)
    {
        BankAccount acc2 = new(-500);
        results.Add($"Initial Balance = {acc2.Balance}");
        acc2.Deposit(300);
        results.Add($"Balance after deposit {acc2.Balance}");
        acc2.Withdraw(200);
        results.Add($"Balance after withdraw = {acc2.Balance}");
        return results;
    }

    private static List<string> Case1(List<string> results)
    {
        try
        {
            BankAccount acc1 = new(500);
            results.Add($"Initial Balance = {acc1.Balance}");
            acc1.Deposit(300);
            results.Add($"Balance after deposit {acc1.Balance}");
            acc1.Withdraw(200);
            results.Add($"Balance after withdraw = {acc1.Balance}");
        }
        catch (Exception)
        {
            throw;
        }
        return results;
    }
}
