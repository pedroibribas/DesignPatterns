namespace ChainOfResponsibility;

public enum Format
{
    XML, CSV, PERCENT
}

public class BankRequest
{
    public Format Format { get; private set; }

    public BankRequest(Format format)
    {
        Format = format;
    }
}

public class BankAccount
{
    public double Balance { get; set; }
    public string Owner { get; set; }

    public BankAccount(double balance, string owner)
    {
        Balance = balance;
        Owner = owner;
    }
}

public record HandlerRequest(Format Format, double Balance, string Owner);

/// <summary>
/// Classe específica para lidar com requisições bancárias de um client.
/// </summary>
public class BankRequestHandler
{
    private readonly IHandler _bankRequestHandler;

    public BankRequestHandler()
    {
        // a manutenção é feita só aqui, adicionando novos cenários
        HandlerCsv handlerCsv = new(
            new HandlerPercent(
                new HandlerXml()));

        _bankRequestHandler = handlerCsv;
    }

    public string Handle(BankRequest bankRequest, BankAccount bankAccount)
    {        
       return _bankRequestHandler.Handle(GetHandlerRequest(bankRequest, bankAccount)) 
            ?? "O resultado do handler é nulo.";
    }

    private static HandlerRequest GetHandlerRequest(
        BankRequest bankRequest,
        BankAccount bankAccount)
    {
        return new(bankRequest.Format, bankAccount.Balance, bankAccount.Owner);
    }
}

public interface IHandler
{
    string Handle(HandlerRequest request);
}

public class HandlerBase : IHandler
{
    // o setter explicita o próximo handler que será invocado.
    public IHandler? NextHandler { get; set; }

    public HandlerBase()
    {
    }

    // o construtror garante que o próximo handler não seja
    // esquecido durante a implementação.
    public HandlerBase(IHandler nextHandler)
    {
        NextHandler = nextHandler;
    }

    public virtual string Handle(HandlerRequest request)
    {
        if (NextHandler == null)
            throw new NullReferenceException(nameof(NextHandler));

        return NextHandler.Handle(request);
    }
}

public class HandlerCsv : HandlerBase
{
    public HandlerCsv(IHandler nextHandler) : base(nextHandler)
    {
    }

    public override string Handle(HandlerRequest request)
    {
        if (request.Format == Format.CSV)
            return $"{request.Balance};{request.Owner}";
        
        return base.Handle(request);
    }
}

public class HandlerPercent : HandlerBase
{
    public HandlerPercent(IHandler nextHandler) : base(nextHandler)
    {
    }

    public override string Handle(HandlerRequest request)
    {
        if (request.Format == Format.PERCENT)
            return $"{request.Balance}%{request.Owner}";

        return base.Handle(request);
    }
}

public class HandlerXml : HandlerBase
{
    public HandlerXml()
    {
        NextHandler = null;
    }

    public override string Handle(HandlerRequest request)
    {
        if (request.Format == Format.XML)
            return $"<{request.Balance}><{request.Owner}>";

        return base.Handle(request);
    }
}