namespace State.Budget;

public class Processing : IBudgetState
{
    public bool DiscountApplied = false;

    public void ApplyDiscount(Budget budget)
    {
        if (DiscountApplied)
            throw new InvalidOperationException("Discount already applied.");

        budget.Balance -= (budget.Balance * 0.3);
        DiscountApplied = true;
    }

    public void Approve(Budget budget) => budget.CurrentState = new Approved();

    public void Deny(Budget budget) => budget.CurrentState = new Denied();

    public void Finish(Budget budget) => throw new InvalidOperationException(
        "Processing budgets cannot be finished directly.");
}
