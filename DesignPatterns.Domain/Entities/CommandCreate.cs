using DesignPatterns.Domain.Enums;

namespace DesignPatterns.Domain.Entities;

public class CommandCreate
{
    public bool HasCommandCreate { get; set; }
    private string UserInput { get; set; }
    private string CommandName { get; set; }
    private int CommandPosition { get; set; }
    public string? CommandValue { get; private set; }

    public CommandCreate(string userInput)
    {
        UserInput = userInput;
        CommandName = UserCommands.Create.ToString();
        if (EnsureCommandCreate())
        {
            HasCommandCreate = true;
            CommandPosition = UserInput.IndexOf(CommandName);
            CommandValue = SetCommandValue();
        }
    }

    private string SetCommandValue()
    {
        int dataPosition = CommandPosition + 1;
        return UserInput[dataPosition].ToString();
    }

    private bool EnsureCommandCreate() => UserInput.Contains(CommandName);
}