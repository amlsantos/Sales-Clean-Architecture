namespace Application.Interfaces.Persistence;

public interface IUnitOfWork
{
    Task SaveAsync();
}