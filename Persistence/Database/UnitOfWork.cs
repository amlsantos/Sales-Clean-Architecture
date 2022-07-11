using Application.Interfaces.Persistence;

namespace Persistence.Database;

public class UnitOfWork : IUnitOfWork
{
    private readonly IDatabaseContext _database;

    public UnitOfWork(IDatabaseContext database) => _database = database;

    public async Task SaveAsync() => await _database.SaveAsync();
}