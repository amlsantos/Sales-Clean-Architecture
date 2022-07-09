using Domain.Customers;
using Domain.Employees;
using Domain.Products;
using Domain.Sales;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces;

public interface IDatabaseService
{
    DbSet<Customer> Customers { get; set; }
    DbSet<Employee> Employees { get; set; }
    DbSet<Product> Products { get; set; }
    DbSet<Sale> Sales { get; set; }

    Task SaveAsync();
}