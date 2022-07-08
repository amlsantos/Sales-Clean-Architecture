using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Database;

public class RepositoryAdapter<T> : IRepository<T> where T : class
{
    private readonly DbSet<T> _dbSet;

    public RepositoryAdapter(DbSet<T> dbSet) => _dbSet = dbSet;

    public IQueryable<T> GetAll()
    {
        return _dbSet;            
    }

    public async Task<T> Get(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task Add(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }
}