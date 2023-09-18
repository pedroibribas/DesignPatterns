namespace ChainOfResponsibility.Person;

public class PersonRequest
{
    public static Person Get(Person person, NewPersonDto dto)
    {
        FirstPersonRequestHandler handler1 = new();
        SecondPersonRequestHandler handler2 = new();
        ThirdPersonRequestHandler handler3 = new();

        handler1.NextHandler = handler2;
        handler2.NextHandler = handler3;

        return handler1.Get(person, dto) ?? person;
    }
}
