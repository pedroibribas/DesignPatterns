using ChainOfResponsibility;

/**
 * teste da calculadora de descontos.
 * implementado com CHAIN OF RESPONSIBILIY.
 * o orçamento é verificado para aplicar algum desconto.
 */

Budget budget1 = new();
List<Item> budget1Items = new()
{
    new Item("Item A", 50),
    new Item("Item B", 50),
    new Item("Item C", 50),
    new Item("Item D", 50),
    new Item("Item E", 50),
    new Item("Item F", 50)
};
budget1Items.ForEach(i => budget1.AddItem(i));
double? budget1Result = DiscountCalculator.Calculate(budget1); //30
Console.WriteLine($"Resultado para 6 itens = {budget1Result}");

Budget budget2 = new();
List<Item> budget2Items = new()
{
    new Item("Item A", 100),
    new Item("Item B", 200)
};
budget2Items.ForEach(i => budget2.AddItem(i));
double? budget2Result = DiscountCalculator.Calculate(budget2); //60
Console.WriteLine($"Resultado para R$300 = {budget2Result}");

Budget budget3 = new();
Item budget3Item = new("Item A", 100);
budget3.AddItem(budget3Item);
double? budget3Result = DiscountCalculator.Calculate(budget3); //0
Console.WriteLine($"Resultado sem desconto = {budget3Result}");

Budget budget4 = new();
List<Item> budget4Items = new()
{
    new Item("Pencil", 30),
    new Item("Pen", 30)
};
budget4Items.ForEach(i => budget4.AddItem(i));
double? budget4Result = DiscountCalculator.Calculate(budget4); // 3
Console.WriteLine($"Resultado para venda casada = {budget4Result}");

/**
 * teste do handler da aplicação bancária.
 */
BankAccount account = new(100, "Fulano");

BankRequestHandler handler = new();

string resultCsv = handler.Handle(new BankRequest(Format.CSV), account);
Console.WriteLine($"Requisição para formato CSV = {resultCsv}");

string resultPercent = handler.Handle(new BankRequest(Format.PERCENT), account);
Console.WriteLine($"Requisição para formato Percent = {resultPercent}");

string resultXml = handler.Handle(new BankRequest(Format.XML), account);
Console.WriteLine($"Requisição para formato XML = {resultXml}");



