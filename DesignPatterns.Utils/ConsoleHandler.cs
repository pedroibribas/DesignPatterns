namespace DesignPatterns.Utils;
public class ConsoleHandler
{
    public static string GetUserInput() => Console.ReadLine() ?? "";

    public static bool UserPressedEscape() => Console.ReadKey().Key == ConsoleKey.Escape;

    public static void WriteSingleLineError(string textLine)
    {
        WriteColoredSingleLine(ConsoleColor.Red, textLine);
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