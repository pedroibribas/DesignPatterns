namespace Decorator.Budget;

public class DecoratorBudgetApp
{
    /**
     * A ideia do padrão nessa aplicação é compor impostos,
     * i.e., ao chamar um método que calcule um imposto,
     * um outro imposto é calculado depois para ser somado,
     * e.g., ao calcular o ISS, o ICMS é calculado também.
     * Assim, na construção do cálculo, uma classe decora a outra,
     * i.e., é passada como parâmetro de outra.
     */
    public static void Run()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"{nameof(DecoratorBudgetApp)} results:");
        Console.ResetColor();

        // criação de impostos compostos
        Tax tax1 = new ISS(new ICMS(new IXPTO()));
        Tax tax2 = new IXPTO(new ISS());

        double result1 = tax1.Calc(1000);
        double result2 = tax2.Calc(1000);

        List<double> results = new()
        {
            result1,
            result2
        };

        for (int i = 0; i < results.Count; i++)
        {
            Console.WriteLine($"[{i}]{results[i]}");
        }
    }
}
