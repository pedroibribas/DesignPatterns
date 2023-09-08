namespace ChainOfResponsibility;

/// <summary>
/// Orçamento.
/// </summary>
public class Budget
{
    public double Amount { get; set; }
    public List<Item> Items { get; private set; }

    public Budget()
    {
        Items = new List<Item>();
    }

    public double UpdateAmount(double newAmount) => Amount += newAmount;

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

/// <summary>
/// Classe responsável por construir a corrente.
/// </summary>
public class DiscountCalculator
{
    public static double CalculateBad(Budget budget)
    {
        if (budget.Items.Count > 5) return budget.Amount * 0.1;
        if (budget.Amount > 200) return budget.Amount * 0.2;
        return 0;
    }

    public static double? CalculateBetter(Budget budget)
    {
        double? discount = new DiscountWhenMoreThanFiveItems().Calculate(budget);

        if (discount == null)
            discount = new DiscountWhenMoreThanTwoHundred().Calculate(budget);

        else discount ??= new NoDiscount().Calculate(budget);
        //else if (discount == null) discount = new NoDiscount().Calculate(budget);

        return discount;
    }

    public static double? Calculate(Budget budget)
    {
        // init
        DiscountWhenMoreThanFiveItems d1 = new();
        DiscountWhenMoreThanTwoHundred d2 = new();
        DiscountVendaCasada d3 = new();
        NoDiscount dFinal = new();

        // chain
        d1.Next = d2;
        d2.Next = d3;
        d3.Next = dFinal;

        return d1?.Calculate(budget);
    }
}

interface IDiscount
{
    IDiscount? Next { get; set; }
    double? Calculate(Budget budget);
}

class DiscountWhenMoreThanFiveItems : IDiscount
{
    public IDiscount? Next { get; set; }

    public double? Calculate(Budget budget)
    {
        if (budget.Items.Count > 5) return budget.Amount * 0.1;
        return Next?.Calculate(budget);
    }
}

class DiscountWhenMoreThanTwoHundred : IDiscount
{
    public IDiscount? Next { get; set; }

    public double? Calculate(Budget budget)
    {
        if (budget.Amount > 200) return budget.Amount * 0.2;
        return Next?.Calculate(budget);
    }
}

class DiscountVendaCasada : IDiscount
{
    public IDiscount? Next { get; set; }

    public double? Calculate(Budget budget)
    {
        if (EnsureVendaCasada(budget))
            return budget.Amount * 0.05;

        return Next?.Calculate(budget);
    }

    private static bool EnsureVendaCasada(Budget budget)
    {
        string[] names = { "Pencil", "Pen" };
        return ItemsExist(budget.Items, names);
    }

    private static bool ItemsExist(List<Item> items, string[] names)
    {
        IEnumerable<Item> result = items
            .Where(i => names.Any(n => String.Equals(i.Name, n, StringComparison.OrdinalIgnoreCase)));

        return result.Count() == names.Length;
    }
}

class NoDiscount : IDiscount
{
    public IDiscount? Next { get; set; }

    public double? Calculate(Budget budget)
    {
        return 0;
    }
}