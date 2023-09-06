using Strategy;

/**
* Os padrões de projeto resolvem problemas como:
* - diminui o tamanho do código
* - reduz complexidade do código
* - reduz uso de diversas variáveis, ifs e fors no mesmo método
* - reduz demora para compreender o que um método faz ou onde está o código que faz uma alteração
* - reduz classes alteráveis em uma manutenção 
*/

// Exemplo Investiment.cs 

BankAccount bankAccount = new(500);
IInvestimentStrategy conservative = new Conservative();

Console.WriteLine(bankAccount.Invest(conservative));


// Exemplo Budget.cs

Budget budget = new(100.0);
ITax icms = new ICMS();
ITax iss = new ISS();

TaxCalculator.Calculate(budget, icms);
TaxCalculator.Calculate(budget, iss);