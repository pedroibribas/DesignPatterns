namespace State.Budget;

public class Finished : IBudgetState
{
    public void ApplyDiscount(Budget budget) => throw new InvalidOperationException(
        "Finished budgets have no discount.");

    public void Approve(Budget budget) => throw new InvalidOperationException(
        "´Budget already finished.");

    public void Deny(Budget budget) => throw new InvalidOperationException(
        "´Budget already finished.");

    public void Finish(Budget budget) => throw new InvalidOperationException(
        "´Budget already finished.");
}