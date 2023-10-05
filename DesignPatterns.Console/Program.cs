using DesignPatterns.StrategyPattern;
using DesignPatterns.Utils;

do
{
    try
    {
        WriteHeader();

        string userInput = ConsoleHandler.GetUserInput();
        int userInputInteger = UserInputHandler.GetUserInputInteger(userInput);

        if (userInputInteger == 0) new TaxOnBudgetCalculation().Run();
        else ConsoleHandler.WriteColoredSingleLine(ConsoleColor.Yellow, 
            "Nenhuma aplicação para esse comando.");
    }
    catch (Exception ex)
    {
        ConsoleHandler.WriteSingleLineError(ex.Message);
    }
} while (!ConsoleHandler.UserPressedEscape());

static void WriteHeader()
{
    ConsoleHandler.WriteColoredSingleLine(ConsoleColor.DarkCyan, "Rodando DesignPatterns.Console");
    Console.WriteLine("Qual aplicação deve ser rodada pelo console?");
    Console.WriteLine("Lista de aplicações disponíveis:");
    foreach (AvailableAppsNames name in Enum.GetValues(typeof(AvailableAppsNames)))
    {
        Console.WriteLine("[{0}] {1}", (int)name, name);
    }
}


public enum AvailableAppsNames
{
    TaxOnBudgetCalculation
}


public class UserInputHandler
{
    public static int GetUserInputInteger(string userInput) => int.Parse(userInput);
}