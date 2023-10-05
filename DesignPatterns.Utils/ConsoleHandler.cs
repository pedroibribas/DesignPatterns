namespace DesignPatterns.Utils;
public class ConsoleHandler
{
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