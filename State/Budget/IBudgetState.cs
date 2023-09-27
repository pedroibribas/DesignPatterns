namespace State.Budget;

public interface IBudgetState
{
    void ApplyDiscount(Budget budget);
    void Approve(Budget budget);
    void Deny(Budget budget);
    void Finish(Budget budget);
}
