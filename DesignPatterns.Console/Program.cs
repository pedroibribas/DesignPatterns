using DesignPatterns.Console;
using DesignPatterns.Utils;

do 
{
    ConsoleOutput.AppInitializationLine("### Você está rodando a aplicação de padrões de design! :-) ###");
    ConsoleOutput.ListOptions(
        header: "A lista de soluções de padrão para você escolher são as seguintes:",
        type: ConsoleOutput.OptionType.PATTERNS_CONSOLE_APP);
    ConsoleOutput.Question("Qual o comando da solução que você deseja rodar?");
    
    string userInput = ConsoleInput.GetUserInput();
    
    ConsoleOutput.DebugInput(userInput, "DesignPatterns.Console/Program.cs");

    try
    {
        AppLoader.RunAppByCommand(userInput);
    }
    catch (Exception ex)
    {
        ConsoleHandler.WriteSingleLineError(ex.Message);
    }
}
while (!ConsoleHandler.UserPressedEscape());

/*
 * CONCEITOS
 * - Output/ConsoleOutput:    Dado de saída da aplicação console.
 * - Input/UserInput:         Command que o usuário envia para a aplicação console processar.
 * - Command:                 Cadeia de caracteres que ativam um processamento da aplicação console. 
 */