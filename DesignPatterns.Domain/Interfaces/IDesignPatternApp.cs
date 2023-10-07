using DesignPatterns.Domain.Dtos;

namespace DesignPatterns.Domain.Interfaces;

public interface IDesignPatternApp
{
    void Run();
    void With(UserInputDto dto);
}
