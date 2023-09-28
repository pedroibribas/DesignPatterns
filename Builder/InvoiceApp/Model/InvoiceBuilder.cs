namespace Builder.InvoiceApp.Model;

public class InvoiceBuilder
{
    private string CompanyName { get; set; }
    private string Cnpj { get; set; }
    private List<Product> Products { get; set; }
    private double TotalValue { get; set; }
    private double TaxesValue { get; set; }
    private string Information { get; set; }
    private DateTime EmittedAt { get; set; }

    public InvoiceBuilder()
    {
        CompanyName = "";
        Cnpj = "";
        Products = new List<Product>();
        Information = "";
        EmittedAt = DateTime.Now;
    }

    public Invoice Build() => new(
        CompanyName,
        Cnpj,
        TotalValue,
        TaxesValue,
        Products,
        Information,
        EmittedAt);

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

    public InvoiceBuilder With(List<Product> products)
    {
        products.ForEach((p) =>
        {
            Products.Add(p);
            TotalValue += p.Value;
            TaxesValue += p.Value * 0.05;
        });
        return this;
    }

    public InvoiceBuilder WithInformation(string information)
    {
        Information = information;
        return this;
    }

    public InvoiceBuilder WithEmittedAt(DateTime emittedAt)
    {
        EmittedAt = emittedAt;
        return this;
    }
}
