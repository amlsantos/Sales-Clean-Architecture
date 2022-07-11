using Application.Interfaces;
using Application.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Database;

public abstract class Repository<T> : IRepository<T> where T : class
{
    protected readonly DbSet<T> DbSet;

    protected Repository(DbSet<T> dbSet)
    {
        DbSet = dbSet;
    }

    public Task<IQueryable<T>> GetAll()
    {
        return Task.FromResult<IQueryable<T>>(DbSet);
    }

    public virtual async Task<T> Get(int id)
    {
        return await DbSet.FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await DbSet.AddAsync(entity);
    }

    public Task RemoveAsync(T entity)
    {
        return Task.FromResult(DbSet.Remove(entity));
    }
}