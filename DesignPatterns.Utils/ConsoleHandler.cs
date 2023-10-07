namespace DesignPatterns.Utils;
public class ConsoleHandler
{
    // ### STRING HANDLER
    public static int GetUserInputInteger(string userInput) => int.Parse(userInput);

    // ### USER INPUT HANDLERS
    public static string GetUserInput() => Console.ReadLine() ?? "";
    public static bool UserPressedEscape() => Console.ReadKey().Key == ConsoleKey.Escape;

    // ### WRITE HANDLERS
    public static void WriteSingleLineError(string textLine)
    {
        WriteColoredSingleLine(ConsoleColor.Red, textLine);
    }

    public static void WriteSingleLineDebug(string message, string stack)
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("{0} - Stack: {1}", message, stack);
        Console.ResetColor();
    }

    public static void WriteColoredSingleLine(ConsoleColor foregroundColor, string textLine)
    {
        Console.ForegroundColor = foregroundColor;
        Console.WriteLine(textLine);
        Console.ResetColor();
    }

    public static void WriteManyLinesFormatted(List<string> textLines)
    {
        for (int i = 0; i < textLines.Count; i++)
        {
            Console.WriteLine("{0}={1};", i, textLines[i]);
        }
    }
}