namespace Decorator.Budget;

public class ICMS : Tax
{
    public ICMS()
    {
    }

    public ICMS(Tax nextTax) : base(nextTax)
    {
    }

    protected override double TaxCalc(double value) => value * 0.1;
}
