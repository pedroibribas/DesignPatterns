namespace Observer;

/** 
 * O padrão de design Observer é utilizado para desacoplar
 * ações de uma classe e expô-las na classe principal, otimizando
 * a manutenção.
 * 
 * Usar principalmente quando:
 * (i) as ações estão aumentando demais na classe.
 * (ii) muitas ações são executadas após um processo.
 */

public class ObserverConcept
{
    private readonly List<IAction> actions;

    public ObserverConcept(List<IAction> actions)
    {
        /**
         * Definição das ações. */
        this.actions = actions;
    }

    public void Handle(object request)
    {
        /**
         * Execução de todas as ações definidas. */
        foreach (var action in actions)
        {
            action.Execute(request);
        }
    }
}

public interface IAction
{
    void Execute(object request);
}

public class ActionOne : IAction
{
    public void Execute(object request) => throw new NotImplementedException();
}

public class ActionTwo : IAction
{
    public void Execute(object request) => throw new NotImplementedException();
}

public class Program
{
    public static ObserverConcept Run()
    {
        return new ObserverConcept(new List<IAction>
        {
            new ActionOne(),
            new ActionTwo()
        });
    }
}