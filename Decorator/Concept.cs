namespace Decorator;

/**
 * DECORATOR -- Os algorítimos se compõem entre si.
 * 
 * O padrão Decorator serve quando há a necessidade de criar
 * comportamentos compostos por outros comportamentos (e.g., filtros).
 * Além de reduzir a quantidade de código, esse padrão
 * torna genérica a combinação de comportamentos.
 * Assim a implementação de qualquer combinação é possível
 * na geração da cadeia. 
 * E.g., os comportamentos A, B, C e D se combinam de 16 formas diferentes,
 * e portanto exigiriam 16 implementações diferentes.
 * Com o padrão Decorator, existe apenas 1 implementação para quando
 * as implementações herdam os métodos da classe modelo.
 */
public abstract class Entity
{
    /**
     * O próximo nó da sequência.
     * Ele é definido via ctor, e seu valor é nulo quando não houver
     * próximo nó.
     */
    private Entity? NextEntity { get; set; }

    /**
     * O próximo nó é definido na instanciação do anterior, como um Decorator.
     * O ctor vazio viabiliza o uso de um único nó ou do último nó da cadeia.
     * E.g.: <c>First(new Second(new Third())).Handle(request);</c>
     */
    protected Entity(Entity nextEntity)
    {
        NextEntity = nextEntity;
    }
    protected Entity()
    {
        NextEntity = null;
    }

    /**
     * O método HandleNext chama o próximo nó da sequência, caso exista um.
     * Ele retorna o resultado do Handle do próximo nó ou um valor default
     * quando já for o último nó.
     */
    protected dynamic HandleNext(dynamic request) => 
        NextEntity != null ? NextEntity.Handle(request) : new { };

    public abstract dynamic Handle(dynamic request);
}
