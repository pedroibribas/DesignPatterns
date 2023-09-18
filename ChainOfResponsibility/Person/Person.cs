namespace ChainOfResponsibility.Person;

public class Person
{
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? Cpf { get; set; }
    public PersonCreatedAt CreatedAt { get; set; }
}
