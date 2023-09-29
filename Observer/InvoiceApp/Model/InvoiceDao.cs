using Observer.InvoiceApp.Interface;

namespace Observer.InvoiceApp.Model;

public class InvoiceDao : INewInvoiceAction
{
    public void Execute(Invoice invoice)
    {
        Console.WriteLine("Nota Fiscal gravada na base de dados.");
    }
}
