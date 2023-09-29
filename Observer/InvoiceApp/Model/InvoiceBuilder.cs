using Observer.InvoiceApp.Interface;

namespace Observer.InvoiceApp.Model;

public class InvoiceBuilder
{
    public string CompanyName { get; set; }
    public string Cnpj { get; set; }
    public double TotalValue { get; set; }
    public DateTime EmittedAt { get; set; }

    private readonly List<INewInvoiceAction> newInvoiceActions;

    public InvoiceBuilder(List<INewInvoiceAction> newInvoiceActions)
    {
        this.newInvoiceActions = newInvoiceActions;

        CompanyName = "";
        Cnpj = "";
        EmittedAt = DateTime.Now;
    }

    public void Build()
    {
        Invoice invoice = new(CompanyName, Cnpj, TotalValue, EmittedAt);

        foreach (INewInvoiceAction action in newInvoiceActions)
        {
            action.Execute(invoice);
        }
    }

    public InvoiceBuilder ToCompany(string companyName)
    {
        CompanyName = companyName;
        return this;
    }

    public InvoiceBuilder WithCnpj(string cnpj)
    {
        Cnpj = cnpj;
        return this;
    }

    public InvoiceBuilder WithEmittedAt(DateTime emittedAt)
    {
        EmittedAt = emittedAt;
        return this;
    }
}
