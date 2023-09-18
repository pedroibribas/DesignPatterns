namespace ChainOfResponsibility.Person;

class FirstPersonRequestHandler : IPersonRequestHandler
{
    public IPersonRequestHandler? NextHandler { get; set; }

    public Person? Get(Person person, NewPersonDto dto)
    {
        person.Name = dto.Name;

        if (person.CreatedAt == PersonCreatedAt.FourMonthsAgo) 
            return person;

        return NextHandler?.Get(person, dto);
    }
}
