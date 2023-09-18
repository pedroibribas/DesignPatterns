namespace ChainOfResponsibility.Concept;

public interface IHandler
{
    IHandler? NextHandler { get; set; }
    dynamic? Handle(dynamic request);
}

public class FirstHandler : IHandler
{
    public IHandler? NextHandler { get; set; }

    public dynamic? Handle(dynamic request) =>
        NextHandler?.Handle(request);
}
