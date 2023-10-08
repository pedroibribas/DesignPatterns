using DesignPatterns.Domain.Enums;

namespace DesignPatterns.Console;

public class AppLoader
{
    public static void RunAppByCommand(string command)
    {
        LoadBankInvestmentConsoleApp(command);
    }

    private static void LoadBankInvestmentConsoleApp(string command)
    {
        string runBankInvestmentCommand = AppsToRunByCommand.BankInvestment.ToString();
        if (command.Contains(runBankInvestmentCommand))
        {
            new BankInvestmentConsoleApp().Run(command);
        }
    }    
}