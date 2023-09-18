namespace ChainOfResponsibility.Person;

class SecondPersonRequestHandler : IPersonRequestHandler
{
    public IPersonRequestHandler? NextHandler { get; set; }

    public Person? Get(Person person, NewPersonDto dto)
    {
        person.Address = dto.Address;

        if (person.CreatedAt == PersonCreatedAt.SixMonthsAgo)
            return person;

        return NextHandler?.Get(person, dto);
    }
}
