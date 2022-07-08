using Domain.Customers;

namespace Application.Interfaces;

public interface IRepository<T>
{
    IQueryable<T> GetAll();
    Task<T?> Get(int id);
    Task Add(T entity);
    void Remove(T entity);
}