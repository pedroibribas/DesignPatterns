namespace State.Budget;

public class Budget
{
    public IBudgetState CurrentState { get; set; }
    public double Balance { get; set; }

    public Budget(double balance)
    {
        Balance = balance;
        CurrentState = new Processing();
    }

    public void Approve() => CurrentState.Approve(this);

    public void Deny() => CurrentState.Deny(this);

    public void Finish() => CurrentState.Finish(this);

    public void ApplyDiscount() => CurrentState.ApplyDiscount(this);
}
