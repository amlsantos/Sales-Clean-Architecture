using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Database;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly DbSet<T> _dbSet;

    public Repository(DbSet<T> dbSet)
    {
        _dbSet = dbSet;
    }

    public Task<IQueryable<T>> GetAll()
    {
        return Task.FromResult<IQueryable<T>>(_dbSet);
    }

    public async Task<T> Get(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public Task RemoveAsync(T entity)
    {
        return Task.FromResult(_dbSet.Remove(entity));
    }
}