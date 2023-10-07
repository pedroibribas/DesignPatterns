using DesignPatterns.Domain.Dtos;
using DesignPatterns.Domain.Interfaces;
using DesignPatterns.Utils;

namespace DesignPatterns.DesignPatternApp.Templates;

public abstract class DesignPatternAppTemplate : IDesignPatternApp
{
    public string AppName { get; private set; }
    protected UserInputDto UserInputDto { get; set; }

    protected DesignPatternAppTemplate()
    {
        AppName = this.GetType().Name;
        UserInputDto = new();
    }

    public void Run()
    {
        ConsoleHandler.WriteColoredSingleLine(
            foregroundColor: ConsoleColor.Cyan,
            $"{AppName}");
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

    public void With(UserInputDto dto)
    {
        UserInputDto = dto;
    }

    protected abstract List<string> GetResults(List<string> results);
}