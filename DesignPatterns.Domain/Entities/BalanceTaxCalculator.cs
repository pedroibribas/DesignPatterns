using DesignPatterns.Domain.Interfaces;

namespace DesignPatterns.Domain.Entities;

public class BalanceTaxCalculator
{
    public IBudgetTax BudgetTax { get; private set; }

    public BalanceTaxCalculator(IBudgetTax budgetTax) => 
        BudgetTax = budgetTax;

    public double Calculate(double budgetBalance) => 
        BudgetTax.Calculate(budgetBalance);
}

/*
 * ### CRIAÇÃO DE UM CÓDIGO ÚNICO ###
 * - manutenção difícil: muitos ifs dificultam a manutenção; um novo if surge para 
 *   cada imposto novo, aumentando o tamanho do código. 
 * - falta coesão: o código não deveria expor regras de negócio diferentes.
 * - exemplo:
    ```
     public static double CalculateTaxOnBudget(Bugdet budget, string taxName)
     {
         double tax = 0;
         if ("ICMS".Equals(taxName)) tax = budget.Balance * 0.1;
         else if ("ISS".Equals(taxName)) tax = budget.Balance * 0.6;
         return tax;
     }
    ```
 *
 * =============================================================================
 *
 * ### REFATORAÇÃO EM MÉTODOS DISTINTOS ###
 * - manutenção difícil: um novo método deve ser criado para cada imposto novo,
 *   além da permanência das condições.
 * - coesão (single responsibility): o código se mantém coeso, "escondendo" as
 *   regras de negócio.
 * - exemplo:
     ```
     public static double CalculateTaxOnBudget(Bugdet budget, string taxName)
     {
     double tax = 0;
     if ("ICMS".Equals(taxName)) tax = CalculateICMS(budget);
     else if ("ISS".Equals(taxName)) tax = CalculateISS(budget);
     return tax;
     }
     public static double CalculateICMS(Bugdet budget) => budget.Balance * 0.1;
     public static double CalculateISS(Bugdet budget) => budget.Balance * 0.6;
     ```
 */