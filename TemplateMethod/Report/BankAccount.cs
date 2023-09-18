namespace TemplateMethod.Report;

public class BankAccount
{
    public string Owner { get; set; }
    public double Balance { get; set; }
    public string AccountNumber { get; set; }
    public string Agency { get; set; }

    public BankAccount(string owner, double balance, string account, string agency)
    {
        Owner = owner;
        Balance = balance;
        AccountNumber = account;
        Agency = agency;
    }
}
