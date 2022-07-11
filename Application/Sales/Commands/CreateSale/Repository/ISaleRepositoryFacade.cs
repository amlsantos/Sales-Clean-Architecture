using Domain.Customers;
using Domain.Employees;
using Domain.Products;
using Domain.Sales;

namespace Application.Sales.Commands.CreateSale.Repository;

public interface ISaleRepositoryFacade
{
    Task<Customer> GetCustomer(int id);
    Task<Employee> GetEmployee(int id);
    Task<Product> GetProduct(int id);

    Task AddSaleAsync(Sale sale);
}