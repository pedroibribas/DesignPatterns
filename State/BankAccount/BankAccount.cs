namespace State.BankAccount;

public class BankAccount
{
    public IBankAccountState BankAccountState { get; private set; }
    public double Balance { get; private set; }

    public BankAccount(double balance)
    {
        Balance = balance;

        if (Balance > 0)
            BankAccountState = new PositiveBalance();
        else
            BankAccountState = new NegativeBalance();
    }

    public void Withdraw(double value) => BankAccountState.Withdraw(this, value);
    public void Deposit(double value) => BankAccountState.Deposit(this, value);

    /**
     * Os estados estão encapsulados pela classe BankAccount porque:
     * (i) os estados são como que uma "continuação" de BankAccount, pois
     * o comportamento deste é intimamente ligado ao dos estados.
     * (ii) os estados declarados internamente tem acesso às propriedades
     * privadas; assim é possível manter a atualização do Balance privada.
     */
    public interface IBankAccountState
    {
        void Withdraw(BankAccount acc, double value);
        void Deposit(BankAccount acc, double value);
    }

    private class PositiveBalance : IBankAccountState
    {
        public void Withdraw(BankAccount acc, double value)
        {
            acc.Balance -= value;
        }
        public void Deposit(BankAccount acc, double value)
        {
            acc.Balance += value * 0.98;
        }
    }

    private class NegativeBalance : IBankAccountState
    {
        public void Withdraw(BankAccount acc, double value)
        {
            throw new InvalidOperationException("Withdraw not allowed for balance is negative.");
        }
        public void Deposit(BankAccount acc, double value)
        {
            acc.Balance += value * 0.95;
        }
    }
}
