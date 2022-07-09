using Domain.Customers;
using Domain.Employees;
using Domain.Products;
using Domain.Sales;
using Domain.SalesProducts;

namespace Application.Sales.Commands.CreateSale.Factory;

public class SaleFactory : ISaleFactory
{
    public Sale Create(DateTime date, Customer customer, Employee employee, List<SaleProduct> saleProducts)
    {
        return new Sale
        {
            CreatedDate = date,
            Customer = customer,
            Employee = employee,
            SaleProducts = saleProducts
        };
    }

    public Sale Create(DateTime date, int customerId, int employeeId, List<SaleProduct> saleProducts)
    {
        return new Sale
        {
            CreatedDate = date,
            CustomerId = customerId,
            EmployeeId = employeeId,
            SaleProducts = saleProducts
        };
    }
}