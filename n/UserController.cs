namespace ChainOfResponsibility;

public class UserController
{
    public static User Update(User user, Dto dto)
    {
        UpdateOlderThanFourMonthsUser update1 = new();
        UpdateOlderThanSixMonthsUser update2 = new();
        UpdateOlderThanOneYearUser update3 = new();

        update1.Next = update2;
        update2.Next = update3;

        return update1.Update(user, dto) ?? user;
    }
}

interface IUpdateUser
{
    IUpdateUser? Next { get; set; }
    User? Update(User user, Dto dto);
}
class UpdateOlderThanFourMonthsUser : IUpdateUser
{
    public IUpdateUser? Next { get; set; }

    public User? Update(User user, Dto dto)
    {
        user.Name = dto.Name;
        if (dto.TimeSpan == Time.OlderThanFourMonths) return user;
        return Next?.Update(user, dto);
    }
}
class UpdateOlderThanSixMonthsUser : IUpdateUser
{
    public IUpdateUser? Next { get; set; }

    public User? Update(User user, Dto dto)
    {
        user.Address = dto.Address;
        if (dto.TimeSpan == Time.OlderThanSixMonths) return user;
        return Next?.Update(user, dto);
    }
}
class UpdateOlderThanOneYearUser : IUpdateUser
{
    public IUpdateUser? Next { get; set; }

    public User? Update(User user, Dto dto)
    {
        user.Cpf = dto.Cpf;
        return user;
    }
}

public enum Time
{
    OlderThanFourMonths, OlderThanSixMonths, OlderThanOneYear
}

public class User
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Cpf { get; set; }
    public string Address { get; set; }

    public User(string id, string name, string cpf, string address)
    {
        Id = id;
        Name = name;
        Cpf = cpf;
        Address = address;
    }
}

public record Dto(
    Time TimeSpan,
    string Name = "",
    string Cpf = "",
    string Address = "");