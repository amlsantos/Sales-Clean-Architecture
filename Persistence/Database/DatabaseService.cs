using Application.Interfaces;
using Domain.Customers;
using Domain.Employees;
using Domain.Products;
using Domain.Sales;

namespace Persistence.Database;

public class DatabaseService : IDatabaseService
{
    private readonly IDatabaseContext _context;
    private readonly Repository<Customer> _customers;
    private readonly Repository<Employee> _employees;
    private readonly Repository<Product> _products;
    private readonly Repository<Sale> _sales; 

    public DatabaseService(IDatabaseContext context)
    {
        _context = context;
        _customers = new Repository<Customer>(_context.Customers);
        _employees = new Repository<Employee>(_context.Employees);
        _products = new Repository<Product>(_context.Products);
        _sales = new Repository<Sale>(_context.Sales);
    }

    public IRepository<Customer> Customers => _customers;
    public IRepository<Employee> Employees => _employees;
    public IRepository<Product> Products => _products;
    public IRepository<Sale> Sales => _sales;

    public async Task SaveAsync()
    {
        await _context.SaveAsync();
    }
}