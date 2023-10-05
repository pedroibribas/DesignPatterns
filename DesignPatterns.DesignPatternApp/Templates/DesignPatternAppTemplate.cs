using DesignPatterns.Domain.Interfaces;
using DesignPatterns.Utils;

namespace DesignPatterns.DesignPatternApp.Templates;

public abstract class DesignPatternAppTemplate : IDesignPatternApp
{
    public string AppName { get; private set; }

    protected DesignPatternAppTemplate()
    {
        AppName = this.GetType().Name;
    }

    public void Run()
    {
        ConsoleHandler.WriteColoredSingleLine(
            foregroundColor: ConsoleColor.Cyan,
            $"{AppName}");

        // List<string> results = new();
        try
        {
            List<string> results = GetResults(new());
            ConsoleHandler.WriteManyLinesFormatted(results);
        }
        catch (Exception ex)
        {
            ConsoleHandler.WriteColoredSingleLine(
                foregroundColor: ConsoleColor.Red,
                $"{ex.Message}");
        }
    }

    protected abstract List<string> GetResults(List<string> results);
}