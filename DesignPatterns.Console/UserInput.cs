using DesignPatterns.Utils;

namespace DesignPatterns.Console;

public class UserInput
{
    public string Input { get; private set; }

    public UserInput(string input)
    {
        Input = input;
    }

    public string Normalized() =>
        Input.ToLower();
}