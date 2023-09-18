using Utils;

namespace TemplateMethod;

/**
 * Classe Template implementada pelas classes concretas que
 * repetem a mesma lógica condicional para o imposto.
 * 
 * Por não ser instanciável, a classe Template é Abstract.
 * 
 * As classes que implementam o Template precisam apenas 
 * definir o conteúdo dos métodos abstratos, que são variáveis,
 * de forma que o método repetido já é um método concreto.
 * 
 * O Template Method é usado para definir o método repetido
 * em várias classes.
 * 
 * A vantagem de usar o Template Method é que eventuais
 * mudanças no algoritmo de cálculo de imposto é concentrado
 * no Template, e não em cada classe específica.
 */
public abstract class ConditionalTaxTemplate
{
    public double Calculate(Budget budget)
    {
        // max tax
        if (EnsureMaxTax(budget))
            return MaxTax(budget);
        // min tax
        return MinTax(budget);
    }
    /**
     * Métodos que são implementados de forma específica
     * em cada implementação do Template.
     * 
     * O modificador de acesso 'protected' esconde a classe
     * para classes clientes enquanto viabiliza o 'override'.
     */
    protected abstract double MinTax(Budget budget);
    protected abstract double MaxTax(Budget budget);
    protected abstract bool EnsureMaxTax(Budget budget);
}

public class ICMS : ConditionalTaxTemplate
{
    /** Sem implementação do Template: */
    //public static double Calculate(Budget budget)
    //{
    //    if (budget.Value >= 500)
    //        return budget.Value * 0.07;
    //    return budget.Value * 0.05;
    //}

    protected override bool EnsureMaxTax(Budget budget) => budget.Value >= 500;
    protected override double MinTax(Budget budget) => budget.Value * 0.05;
    protected override double MaxTax(Budget budget) => budget.Value * 0.07;
}

// Exemplo de classe antes de implementar o template:
public class ISS
{
    public static double Calculate(Budget budget)
    {
        // max tax
        if (budget.Value >= 500 && budget.Items.Any(i => i.Value > 100))
            return budget.Value * 0.1;

        // min tax
        return budget.Value * 0.06;
    }
}

public class IX : ConditionalTaxTemplate
{
    protected override bool EnsureMaxTax(Budget budget) => CheckCollection.HasDuplicates(budget.Items);

    protected override double MaxTax(Budget budget) => (budget.Value * 0.13) + 100;

    protected override double MinTax(Budget budget) => budget.Value * (budget.Items.Count * 0.01);
}

public class Budget
{
    public double Value { get; set; }
    public List<Item> Items { get; private set; }

    public Budget()
    {
        Items = new List<Item>();
    }

    public double UpdateAmount(double newAmount) => Value += newAmount;

    public void AddItem(Item item)
    {
        Items.Add(item);
        UpdateAmount(item.Value);
    }
}

public class Item
{
    public string Name { get; set; }
    public double Value { get; set; }

    public Item(string name, double value)
    {
        Name = name;
        Value = value;
    }
}
