namespace ChainOfResponsibility.Concept;

public interface IHandler
{
    IHandler? Next { get; set; }

    dynamic? Handle(dynamic request);
}

public class Handler : IHandler
{
    public IHandler? Next { get; set; }

    public virtual dynamic? Handle(dynamic request)
    {
        return Next?.Handle(request);
    }
}

public class FirstHandler : Handler
{
    public override dynamic? Handle(object request)
    {
        if (request as string == "FirstCondition")
        {
            return "First condition handled";
        }

        return base.Handle(request);
    }
}
