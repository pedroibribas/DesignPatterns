namespace Decorator.Budget;

public class ISS : Tax
{
    public ISS()
    {
    }

    public ISS(Tax nextTax) : base(nextTax)
    {
    }

    protected override double TaxCalc(double value) => value * 0.06;
}