namespace Observer.InvoiceApp.Model;

/// <param name="CompanyName">Razão social.</param>
/// <param name="Cnpj"></param>
/// <param name="TotalValue">Valor bruto.</param>
/// <param name="EmittedAt"></param>
public record Invoice(
    string CompanyName,
    string Cnpj,
    double TotalValue,
    DateTime EmittedAt);
