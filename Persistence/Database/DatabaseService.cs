using Application.Interfaces;
using Domain.Customers;
using Domain.Employees;
using Domain.Products;
using Domain.Sales;

namespace Persistence.Database;

public class DatabaseService : IDatabaseService
{
    private readonly IDatabaseContext _context;
    private readonly RepositoryAdapter<Customer> _customers;
    private readonly RepositoryAdapter<Employee> _employees;
    private readonly RepositoryAdapter<Product> _products;
    private readonly RepositoryAdapter<Sale> _sales;

    public DatabaseService(IDatabaseContext context)
    {
        if (_context == null)
        {
            _context = context;

            _customers = new RepositoryAdapter<Customer>(_context.Customers);
            _employees = new RepositoryAdapter<Employee>(_context.Employees);
            _products = new RepositoryAdapter<Product>(_context.Products);
            _sales = new RepositoryAdapter<Sale>(_context.Sales);
        }
    }

    public IRepository<Customer> Customers => _customers;
    public IRepository<Employee> Employees => _employees;
    public IRepository<Product> Products => _products;
    public IRepository<Sale> Sales => _sales;

    public async Task Save()
    {
        await _context.SaveAsync();
    }
}