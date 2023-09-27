namespace State.Budget;

public class Approved : IBudgetState
{
    public bool DiscountApplied = false;

    public void ApplyDiscount(Budget budget)
    {
        if (DiscountApplied)
            throw new InvalidOperationException("Discount already applied.");

        budget.Balance -= (budget.Balance * 0.2);
        DiscountApplied = true;
    }

    public void Approve(Budget budget) => throw new InvalidOperationException(
        "Budget already approved.");

    public void Deny(Budget budget) => throw new InvalidOperationException(
        "Approved budget cannot be denied.");

    public void Finish(Budget budget) => budget.CurrentState = new Finished();
}
