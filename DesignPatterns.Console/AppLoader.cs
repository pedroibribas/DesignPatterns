using DesignPatterns.Domain.Enums;

namespace DesignPatterns.Console;

public class AppLoader
{
    public string Command { get; private set; }
    public IConsoleApp? App { get; set; }

    public AppLoader(string command) => 
        Command = command;

    public void Load()
    {
        LoadBankInvestmentConsoleApp();
    }

    private void LoadBankInvestmentConsoleApp()
    {
        string runBankInvestmentCommand = AppsToRunByCommand.BankInvestment.ToString();
        if (Command.Contains(runBankInvestmentCommand))
        {
            App = new BankInvestmentConsoleApp();
        }
    }    
}