using DesignPatternsApp;
using Observer.InvoiceApp.Interface;
using Observer.InvoiceApp.Model;

namespace Observer.InvoiceApp
{
    public class ObserverInvoiceApp : App
    {
        protected override string GetAppName() => nameof(ObserverInvoiceApp);

        protected override List<string> GetResults()
        {
            List<string> results = new();

            InvoiceBuilder builder = new(
                new List<INewInvoiceAction>
                {
                    new InvoiceDao(),
                    new Messenger(),
                    new Mailer()
                });

            builder
                .ToCompany("Hello World LTDA")
                .WithCnpj("32.132.432/1232-0")
                .WithEmittedAt(DateTime.Now);            

            builder.Build();

            return results;
        }
    }
}
