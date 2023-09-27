namespace DesignPatternsApp;

public abstract class App : IApp
{
    public void Run()
    {
        WriteTitle();
        List<string>  results = GetResults();
        WriteResults(results);
    }

    protected abstract string GetAppName();
    protected abstract List<string> GetResults();

    protected void WriteTitle()
    {
        string appName = GetAppName();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"{appName} results:");
        Console.ResetColor();
    }
    protected static void WriteError(string message)
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine(message);
        Console.ResetColor();
    }
    protected static void WriteResults(List<string> results)
    {
        string format = "Result {0} = {1};";
        for (int i = 0; i < results.Count; i++)
        {
            Console.WriteLine(format, (i + 1), results[i]);
        }
    }
}