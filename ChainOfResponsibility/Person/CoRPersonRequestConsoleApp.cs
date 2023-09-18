using System.Text.Json;

namespace ChainOfResponsibility.Person;

public class CoRPersonRequestConsoleApp
{
    public static void Run()
    {
        Person pedro = Pedro();
        Person marcos = Marcos();
        Person felipe = Felipe();
        
        NewPersonDto dto = PersonDto();

        Person newPedro = PersonRequest.Get(pedro, dto);
        Person newMarcos = PersonRequest.Get(marcos, dto);
        Person newFelipe = PersonRequest.Get(felipe, dto);

        Console.WriteLine(JsonSerializer.Serialize(newPedro).ToString());
        Console.WriteLine(JsonSerializer.Serialize(newMarcos).ToString());
        Console.WriteLine(JsonSerializer.Serialize(newFelipe).ToString());
    }

    private static NewPersonDto PersonDto() => new("Henrique", "3216549871", "Av. Azul");

    private static Person Pedro() => new()
    {
        Name = "Pedro Ivo",
        Cpf = "1234567890",
        Address = "Rua Amarela",
        CreatedAt = PersonCreatedAt.FourMonthsAgo
    };
    private static Person Marcos() => new()
    {
        Name = "Marcos",
        Cpf = "1234567890",
        Address = "Rua Vermelha",
        CreatedAt = PersonCreatedAt.SixMonthsAgo
    };
    private static Person Felipe() => new()
    {
        Name = "Felipe",
        Cpf = "1234567890",
        Address = "Rua Azul",
        CreatedAt = PersonCreatedAt.OneYearAgo
    };
}
