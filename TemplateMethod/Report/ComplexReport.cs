namespace TemplateMethod.Report;

class ComplexReport : BankReport
{
    public ComplexReport(BankData bank, BankAccount acc) : base(bank, acc)
    {
    }

    protected override ReportBody Body(BankData bank, BankAccount acc) => new()
    {
        BankAccNumber = acc.AccountNumber,
        BankAccAgency = acc.Agency
    };

    protected override ReportFooter Footer(BankData bank, BankAccount acc) => new()
    {
        BankEmail = bank.Email,
        CreatedAt = DateTime.Now
    };

    protected override ReportHeader Header(BankData bank, BankAccount acc) => new()
    {
        BankAddress = bank.Address,
        BankPhone = bank.Phone
    };
}
