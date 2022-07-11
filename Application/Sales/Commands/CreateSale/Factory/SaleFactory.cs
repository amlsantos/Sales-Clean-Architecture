using Domain.Customers;
using Domain.Employees;
using Domain.Products;
using Domain.Sales;
using Domain.SalesProducts;

namespace Application.Sales.Commands.CreateSale.Factory;

public class SaleFactory : ISaleFactory
{
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