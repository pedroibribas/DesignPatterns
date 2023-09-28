namespace Builder;

public class Entity
{
    public string PropOne { get; set; }
    public string PropTwo { get; set; }

    public Entity(string propOne, string propTwo)
    {
        PropOne = propOne;
        PropTwo = propTwo;
    }
}

/**
 * No padrão Builder, uma classe é criada para assumir a
 * responsabilidade de criação do objeto, ficando mais
 * fácil de manter o código de criação, especialmente nos casos
 * de construtores muito complexos ou com argumentos opcionais.
 * 
 * O Builder é um padrão de design criacional.
 */
public class EntityBuilder
{
    public string? PropOne { get; private set; }
    public string? PropTwo { get; private set; }

    /**
     * O ctor é útil para guardar valores opcionais,
     * que podem ser alterados na construção. Assim
     * não é necessário depender do parâmetro opcional.
     */
    public EntityBuilder()
    {
        PropTwo = "Default";
    }

    public Entity Build()
    {
        if (PropOne == null)
            throw new ArgumentNullException(nameof(PropOne));

        if (PropTwo == null)
            throw new ArgumentNullException(nameof(PropTwo));

        return new(PropOne, PropTwo);
    }

    /**
     * Os métodos retornam o próprio builder para viabilizar
     * o Fluent Interface -- ou Method Chaining.
     */
    public EntityBuilder WithPropOne(string propOne)
    {
        PropOne = propOne;
        return this;
    }
    public EntityBuilder WithPropTwo(string propTwo)
    {
        PropTwo = propTwo;
        return this;
    }
}

public class EntityApp
{
    public static void Handle()
    {
        try
        {
            EntityBuilder builder = new();

            builder
                .WithPropOne("I'm prop one")
                .WithPropTwo("I'm prop two");

            Entity entity = builder.Build();
        }
        catch (Exception)
        {
            throw;
        }
    }
}
