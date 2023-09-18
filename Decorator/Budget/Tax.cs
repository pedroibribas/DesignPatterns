namespace Decorator.Budget;

public abstract class Tax
{
    private Tax? NextTax { get; set; }

    protected Tax(Tax nextTax)
    {
        NextTax = nextTax;
    }

    protected Tax()
    {
        NextTax = null;
    }

    public double Calc(double value) => 
        TaxCalc(value) + CalcNextTax(value);

    protected double CalcNextTax(double value) => 
        NextTax != null ? NextTax.Calc(value) : 0;

    protected abstract double TaxCalc(double value);
}
