using System.Reflection;

namespace TemplateMethod.Report;

public class BankReportPrinterConsoleApp
{
    public static void Run()
    {
        BankData bank = new("Hello World", "Hello World", "Hello World", "Hello World");
        BankAccount acc = new("Hello World", 100, "Hello World", "Hello World");

        SimpleReport sr = new(bank, acc);
        Report simpleReport = sr.Get();

        Print("Relatório simples:", simpleReport);
    }

    private static void Print(string title, Report report)
    {
        Console.WriteLine(title);
        PrintObjectProps(report.Header);
        PrintObjectProps(report.Body);
        PrintObjectProps(report.Footer);
        Console.WriteLine(string.Empty);
    }

    private static void PrintObjectProps(object obj)
    {
        foreach (PropertyInfo prop in obj.GetType().GetProperties())
        {
            if (prop.GetValue(obj) != null)
                Console.WriteLine($"{obj} | {prop.Name} | {prop.GetValue(obj)}");
        }
    }
}
