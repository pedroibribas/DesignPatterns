using Builder.InvoiceApp.Model;
using DesignPatternsApp;
using System.Text.Json;

namespace Builder.InvoiceApp;

public class BuilderInvoiceApp : App
{
    protected override string GetAppName() => nameof(BuilderInvoiceApp);

    private readonly InvoiceBuilder InvoiceBuilder = new();

    private readonly List<Product> Products = new()
    {
        new("mesa de madeira", 100),
        new("cadeira de madeira", 40),
        new("banco de madeira", 20)
    };

    protected override List<string> GetResults()
    {
        List<string> results = new();

        Invoice invoice1 = InvoiceBuilder.ToCompany("Los Hermanos Constructores LTDA")
            .WithCnpj("12.123.123/0001-12")
            .With(Products)
            .WithInformation("Nota fiscal para o Pedro")
            .Build();
        results.Add(JsonSerializer.Serialize(invoice1));
        
        return results;
    }
}
