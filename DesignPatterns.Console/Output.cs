using DesignPatterns.Utils;

namespace DesignPatterns.Console;

public class ConsoleOutput
{
    public enum OptionType
    {
        PATTERNS_CONSOLE_APP
    }

    public static void AppInitializationLine(string textLine) =>
        ConsoleHandler.WriteColoredSingleLine(ConsoleColor.DarkCyan, textLine);

    public static void ListOptions(string header, OptionType type)
    {
        //write header
        if (type == OptionType.PATTERNS_CONSOLE_APP)
        {
            //TODO criar algoritmo que lida com coleção de pares comando x descrição
            // foreach (AppsToRun app in AppsToRun.GetAll())
            // {
            //     System.Console.WriteLine("{0} | {1}", app.Command, app.Name);
            // }
        }
    }

    public static void Question(string text) =>
        System.Console.Write(text);

    public static void NoAppFoundAlert()
    {
        ConsoleHandler.WriteColoredSingleLine(
            ConsoleColor.Yellow, "Nenhuma aplicação para esse comando.");
    }

    public static void DebugInput(string input, string stack) =>
        ConsoleHandler.WriteSingleLineDebug($"Entrada: {input}", stack);
}
