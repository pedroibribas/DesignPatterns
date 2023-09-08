namespace ChainOfResponsibility;

/// <summary>
/// Orçamento.
/// </summary>
public class Budget
{
    public double Amount { get; set; }
    public List<Item> Items { get; private set; }

    public Budget(double amount)
    {
        Amount = amount;
        Items = new List<Item>();
    }

    public void AddItem(Item item) => Items.Add(item);
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
        NoDiscount d3 = new();

        // chain
        d1.Next = d2;
        d2.Next = d3;

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

class NoDiscount : IDiscount
{
    public IDiscount? Next { get; set; }

    public double? Calculate(Budget budget)
    {
        return 0;
    }
}