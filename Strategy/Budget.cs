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
        /**
         * Vejamos este método CalculateTax, que apresenta problemas:
         */
        public static void CalculateByTax(Budget budget, string taxName)
        {
            if ("ICMS".Equals(taxName)) // uso de IF's
            {
                double icms = budget.Value * 0.1; // exposição de regra de negócio
                Console.WriteLine(icms);
            }
            else if ("ISS".Equals(taxName))
            {
                double iss = budget.Value * 0.6;
                Console.WriteLine(iss);
            }
        }
        /**
         * O CalculateTax é de difícil manutenção, porque cada imposto novo precisará de um IF,
         * criando um método que tende a ficar grande.
         * Também não é coesa, porque expõe várias regras de cálculo diferentes.
         * 
         * Os métodos a seguir melhoram esses problemas:
         */
        public static void CalculateICMS(Budget budget)
        {
            double icms = new ICMS().Calculate(budget);
            Console.WriteLine(icms);
        }
        public static void CalculateISS(Budget budget)
        {
            double icms = new ISS().Calculate(budget);
            Console.WriteLine(icms);
        }
        // inserção de novos métodos...
        /**
         * Agora as regras de cálculo estão escondidas em classes especializadas e coesas, i.e.,
         * com responsabilidade única, e cada evento é mantido em métodos coesos.
         * Ainda assim, a manutenção do código ainda é difícil, porque exige um método novo
         * para cada imposto novo.
         * 
         * O método a seguir consegue tornar o cálculo genérico para resolver esse problema:
         */
        public static void Calculate(Budget budget, ITax tax)
        {
            double result = tax.Calculate(budget);
            Console.WriteLine(result);
        }
        /**
         * Agora temos um método independente de um imposto concreto, e que depende apenas
         * da abstração ITax, de modo genérico. As classes concretas de impostos se tornam
         * estratégias do ITax.
         * 
         * O uso de estratégias a partir de uma abstração é o padrão de projeto Strategy.
         */
    }

    /**
     * Cada imposto concreto é uma estratégia do contrato ITax.
     * O sistema aproveitará apenas a abstração.
     * 
     * Cada regra de imposto em concreto é ENCAPSULADO em uma classe especializada 
     * e coesa (responsabilidade única).
     * 
     * O padrão Strategy facilita a geração de novas estratégias, por meio do
     * polimorfismo, sem provocar uma manutenção sistêmica.
     */
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
