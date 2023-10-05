namespace BudgetApp
{
    class Budget
    {
        public double Value { get; set; }

        public Budget(double value)
        {
            Value = value;
        }
    }

    class TaxCalculator
    {
        public static void Calculate(Budget budget, ITax tax)
        {
            double result = tax.Calculate(budget);
            Console.WriteLine(result);
        }
    }


    interface ITax
    {
        double Calculate(Budget budget);
    }
    class ICMS : ITax
    {
        public double Calculate(Budget budget) => budget.Value * 0.1;
    }
    class ISS : ITax
    {
        public double Calculate(Budget budget) => budget.Value * 0.6;
    }
    class IPTU : ITax
    {
        public double Calculate(Budget budget) => budget.Value * 0.3;
    }
}
