using DesignPatterns.Domain.Enums;
using DesignPatterns.Utils;

namespace DesignPatterns.Console;

public class Output
{
    public static string GetUserInputNormalized()
    {
        string userInput = ConsoleHandler.GetUserInput();
        return new UserInput(userInput).Normalized();
    }

    public static void NoAppFoundAlert()
    {
        ConsoleHandler.WriteColoredSingleLine(
            ConsoleColor.Yellow, "Nenhuma aplicação para esse comando.");
    }

    public static void Header()
    {
        ConsoleHandler.WriteColoredSingleLine(ConsoleColor.DarkCyan, "Rodando DesignPatterns.Console");
        System.Console.WriteLine("Qual aplicação deve ser rodada pelo console?");
        System.Console.WriteLine("Lista de aplicações disponíveis:");
        foreach (AppsToRunByCommand name in Enum.GetValues(typeof(AppsToRunByCommand)))
        {
            System.Console.WriteLine("[{0}] {1}", (int)name, name);
        }
    }
}
