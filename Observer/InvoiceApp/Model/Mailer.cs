using Observer.InvoiceApp.Interface;

namespace Observer.InvoiceApp.Model;

public class Mailer : INewInvoiceAction
{
    public void Execute(Invoice invoice)
    {
        Console.WriteLine("Nota Fiscal enviada por e-mail.");
    }
}
