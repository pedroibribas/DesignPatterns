namespace State.Budget;

public class Denied : IBudgetState
{
    public void ApplyDiscount(Budget budget) => throw new InvalidOperationException(
        "Denied budgets have no discount.");

    public void Approve(Budget budget) => throw new InvalidOperationException(
        "Denied budget cannot be approved.");

    public void Deny(Budget budget) => throw new InvalidOperationException(
        "Budget already denied.");

    public void Finish(Budget budget) => budget.CurrentState = new Finished();
}
