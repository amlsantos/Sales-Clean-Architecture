using Domain.Customers;
using Domain.Employees;
using Domain.Products;
using Domain.Sales;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Database;

public interface IDatabaseContext
{
    DbSet<Customer> Customers { get; }
    DbSet<Employee> Employees { get; }
    DbSet<Product> Products { get; }
    DbSet<Sale> Sales { get; }

    Task SaveAsync();
}