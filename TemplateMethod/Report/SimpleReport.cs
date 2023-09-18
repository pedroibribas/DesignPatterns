namespace TemplateMethod.Report;

public class SimpleReport : BankReport
{
    public SimpleReport(BankData bank, BankAccount acc) : base(bank, acc)
    {
    }

    protected override ReportHeader Header(BankData bank, BankAccount acc) => new()
    {
        BankName = bank.Name
    };

    protected override ReportBody Body(BankData bank, BankAccount acc) => new()
    {
        BankAccOwner = acc.Owner,
        BankAccBalance = acc.Balance
    };

    protected override ReportFooter Footer(BankData bank, BankAccount acc) => new()
    {
        BankPhone = bank.Phone
    };
}