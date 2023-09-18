namespace TemplateMethod.Report;

public abstract class BankReport
{
    private BankData Bank { get; set; }
    private BankAccount Acc { get; set; }

    protected BankReport(BankData bank, BankAccount acc)
    {
        Bank = bank;
        Acc = acc;
    }

    public Report Get() => new(Header(Bank, Acc), Body(Bank, Acc), Footer(Bank, Acc));

    protected abstract ReportHeader Header(BankData bank, BankAccount acc);
    protected abstract ReportBody Body(BankData bank, BankAccount acc);
    protected abstract ReportFooter Footer(BankData bank, BankAccount acc);
}