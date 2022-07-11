using Domain.Customers;
using Domain.Employees;
using Domain.Products;
using Domain.Sales;

namespace Application.Interfaces;

public interface IDatabaseService
{
    IRepository<Customer> Customers { get; }
    IRepository<Employee> Employees { get; }
    IRepository<Product> Products { get; }
    IRepository<Sale> Sales { get; }

    Task SaveAsync();
}