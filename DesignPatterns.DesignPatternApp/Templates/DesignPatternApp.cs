using DesignPatterns.Domain.Interfaces;
using DesignPatterns.Utils;

namespace DesignPatterns.DesignPatternApp.Templates;
public abstract class DesignPatternApp : IDesignPatternApp
{
    public string AppName { get; private set; }

    protected DesignPatternApp()
    {
        AppName = this.GetType().Name;
    }

    public void Run()
    {
        ConsoleHandler.WriteColoredSingleLine(
            foregroundColor: ConsoleColor.Cyan,
            $"{AppName}");

        List<string> results = new();
        try
        {
            results = GetResults();
            ConsoleHandler.WriteManyLinesFormatted(results);
        }
        catch (Exception ex)
        {
            ConsoleHandler.WriteColoredSingleLine(
                foregroundColor: ConsoleColor.Red,
                $"{ex.Message}");
        }
    }

    protected abstract List<string> GetResults();
}