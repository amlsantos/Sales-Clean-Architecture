using Domain.Customers;
using Domain.Employees;
using Domain.Products;
using Domain.Sales;

namespace Application.Sales.Commands.CreateSale.Factory;

public interface ISaleFactory
{
    Sale Create(DateTime date, Customer customer, Employee employee, Product product, int quantity);
}