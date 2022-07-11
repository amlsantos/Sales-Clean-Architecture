using Application.Interfaces.Persistence;
using Domain.Customers;
using Domain.Employees;
using Domain.Products;
using Domain.Sales;

namespace Application.Sales.Commands.CreateSale.Repository;

public class SaleRepositoryFacade : ISaleRepositoryFacade
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IProductRepository _productRepository;
    private readonly ISaleRepository _saleRepository;

    public SaleRepositoryFacade(ICustomerRepository customerRepository, IEmployeeRepository employeeRepository, IProductRepository productRepository, ISaleRepository saleRepository)
    {
        _customerRepository = customerRepository;
        _employeeRepository = employeeRepository;
        _productRepository = productRepository;
        _saleRepository = saleRepository;
    }

    public async Task<Customer> GetCustomer(int id) => await _customerRepository.Get(id);

    public async Task<Employee> GetEmployee(int id) => await _employeeRepository.Get(id);

    public async Task<Product> GetProduct(int id) => await _productRepository.Get(id);

    public async Task AddSaleAsync(Sale sale) => await _saleRepository.AddAsync(sale);
}