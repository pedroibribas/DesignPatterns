using Observer.InvoiceApp.Model;

namespace Observer.InvoiceApp.Interface;

public interface INewInvoiceAction
{
    void Execute(Invoice invoice);
}
