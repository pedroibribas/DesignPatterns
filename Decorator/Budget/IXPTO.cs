namespace Decorator.Budget;

public class IXPTO : Tax
{
    public IXPTO()
    {
    }

    public IXPTO(Tax nextTax) : base(nextTax)
    {
    }

    protected override double TaxCalc(double value) => value * 0.2;
}