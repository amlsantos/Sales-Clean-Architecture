using Domain.Customers;
using Domain.Employees;
using Domain.Products;
using Domain.Sales;

namespace Application.Sales.Commands.CreateSale.Factory;

public class SaleFactory : ISaleFactory
{
    public Sale Create(DateTime date, Customer customer, Employee employee, Product product, int quantity)
    {
        var sale = new Sale
        {
            Date = date,
            Customer = customer,
            Employee = employee,
            Product = product,
            Quantity = quantity
        };
        
        sale.UnitPrice = sale.Product.Price;

        return sale;
    }
}