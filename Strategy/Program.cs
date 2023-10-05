using BudgetApp;

BankAccount bankAccount = new(500);
IInvestiment conservative = new Conservative();
Console.WriteLine(bankAccount.Invest(conservative));

Budget budget = new(100.0);
ITax icms = new ICMS();
ITax iss = new ISS();
TaxCalculator.Calculate(budget, icms);
TaxCalculator.Calculate(budget, iss);