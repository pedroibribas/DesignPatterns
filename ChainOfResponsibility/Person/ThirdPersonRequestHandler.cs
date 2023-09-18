namespace ChainOfResponsibility.Person;

class ThirdPersonRequestHandler : IPersonRequestHandler
{
    public IPersonRequestHandler? NextHandler { get; set; }

    public Person? Get(Person person, NewPersonDto dto)
    {
        person.Cpf = dto.Cpf;

        if (person.CreatedAt == PersonCreatedAt.OneYearAgo) 
            return person;

        return NextHandler?.Get(person, dto);
    }
}
