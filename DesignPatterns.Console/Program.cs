using DesignPatterns.Console;
using DesignPatterns.Utils;

do
{
    try
    {
        Output.Header();
        string userInputNormalized = Output.GetUserInputNormalized();
        
        ConsoleHandler.WriteSingleLineDebug($"Dados de entrada: {userInputNormalized}", "DesignPatterns.Console/Program.cs");

        AppLoader appLoader = new(userInputNormalized);
        appLoader.Load();

        IConsoleApp? app = appLoader.App;

        if (app != null)
            app.Run(userInputNormalized);
        else Output.NoAppFoundAlert();
    }
    catch (Exception ex)
    {
        ConsoleHandler.WriteSingleLineError(ex.Message);
    }
} while (!ConsoleHandler.UserPressedEscape());
