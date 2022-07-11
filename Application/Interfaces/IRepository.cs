namespace Application.Interfaces;

public interface IRepository<T>
{
    Task<IQueryable<T>> GetAll();
    Task<T> Get(int id);

    public Task AddAsync(T entity);
    public Task RemoveAsync(T entity);
}