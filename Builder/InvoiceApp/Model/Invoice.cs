namespace Builder.InvoiceApp.Model;

/// <param name="CompanyName">Razão social.</param>
/// <param name="Cnpj"></param>
/// <param name="TotalValue">Valor bruto.</param>
/// <param name="TaxesValue"></param>
/// <param name="Products"></param>
/// <param name="Information"></param>
/// <param name="EmittedAt"></param>
public record Invoice(
    string CompanyName,
    string Cnpj,
    double TotalValue,
    double TaxesValue,
    List<Product> Products,
    string Information,
    DateTime EmittedAt);
