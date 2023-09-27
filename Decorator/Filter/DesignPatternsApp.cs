namespace Decorator.Filter;

public abstract class DesignPatternsApp : IDesignPatternsApp
{
    public void Run()
    {
        WriteTitle();
        List<string> results = GetResults();
        WriteResults(results);
    }    

    protected void WriteTitle()
    {
        string appName = GetAppName();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"{appName} results:");
        Console.ResetColor();
    }

    protected abstract string GetAppName();

    protected abstract List<string> GetResults();

    protected static void WriteResults(List<string> results)
    {
        string format = "Result {0} = {1};";
        for (int i = 0; i < results.Count; i++)
        {
            Console.WriteLine(format, i, results[i]);
        }
    }
}
