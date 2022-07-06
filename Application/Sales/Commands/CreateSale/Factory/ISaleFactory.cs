using Domain.Customers;
using Domain.Employees;
using Domain.Sales;
using Domain.SalesProducts;

namespace Application.Sales.Commands.CreateSale.Factory;

public interface ISaleFactory
{
    Sale Create(DateTime date, Customer customer, Employee employee, List<SaleProduct> saleProducts);
}