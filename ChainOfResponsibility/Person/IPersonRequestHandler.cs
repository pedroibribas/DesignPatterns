namespace ChainOfResponsibility.Person;

public interface IPersonRequestHandler
{
    IPersonRequestHandler? NextHandler { get; set; }
    Person? Get(Person person, NewPersonDto dto);
}