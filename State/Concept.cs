namespace State;

/** UTILIZAÇÃO
 * A principal situação para o uso do padrão State
 * é a necessidade de uma máquina de estados. Geralmente, 
 * o controle das possíveis transições são vários e complexos, 
 * fazendo com que a implementação não seja simples. 
 * O State mantém o controle dos estados simples e organizados através
 * da criação de classes que representem cada estado e saiba controlar as transições.
 */

public interface IState
{
    /**
     * Métodos que tratam os comportamentos conforme o estado da entidade.
     */
    void HandlerOne(dynamic request);
    void HandlerTwo(dynamic request);

    /**
     * Métodos que tratam a transição de um estado para outro.
     * Cada estado pode tratar a transição de um modo específico.
     * A transição é efetivada na propriedade referente ao estado
     * na classe do elemento de referência.
     */
    void SetToSecondState();
    void SetToFinalState();
}

public class InitialState : IState
{
    public void HandlerOne(dynamic request) => throw new NotImplementedException();
    public void HandlerTwo(dynamic request) => throw new NotImplementedException();
    public void SetToFinalState() => throw new NotImplementedException();
    public void SetToSecondState() => throw new NotImplementedException();
}

public class SecondState : IState
{
    public void HandlerOne(dynamic request) => throw new NotImplementedException();
    public void HandlerTwo(dynamic request) => throw new NotImplementedException();
    public void SetToFinalState() => throw new NotImplementedException();
    public void SetToSecondState() => throw new NotImplementedException();
}

public class FinalState : IState
{
    public void HandlerOne(dynamic request) => throw new NotImplementedException();
    public void HandlerTwo(dynamic request) => throw new NotImplementedException();
    public void SetToFinalState() => throw new NotImplementedException();
    public void SetToSecondState() => throw new NotImplementedException();
}

public class Element
{
    public IState State { get; set; }
    public dynamic Request { get; set; }

    public Element(dynamic request)
    {
        State = new InitialState();
        Request = request;
    }

    public void HandlerOne() => State.HandlerOne(Request);
    public void HandlerTwo() => State.HandlerTwo(Request);
    public void SetToSecondState() => State.SetToSecondState();
    public void SetToFinalState() => State.SetToFinalState();
}
