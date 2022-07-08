using Application.Customers.Queries.GetCustomerList;
using Application.Employees.Queries.GetEmployeeList;
using Application.Products.Queries.GetProductsList;
using Microsoft.AspNetCore.Mvc.Rendering;
using UI.Sales.Models;

namespace UI.Sales.Services;

public class CreateSaleViewModelFactory : ICreateSaleViewModelFactory
{
    private readonly IGetCustomersListQuery _customersQuery;
    private readonly IGetEmployeesListQuery _employeesQuery;
    private readonly IGetProductsListQuery _productsQuery;

    public CreateSaleViewModelFactory(IGetCustomersListQuery customersQuery, IGetEmployeesListQuery employeesQuery,
        IGetProductsListQuery productsQuery)
    {
        _customersQuery = customersQuery;
        _employeesQuery = employeesQuery;
        _productsQuery = productsQuery;
    }

    public CreateSaleViewModel Create()
    {
        var employees = _employeesQuery.Execute();
        var customers = _customersQuery.Execute();
        var products = _productsQuery.Execute();

        return new CreateSaleViewModel
        {
            Employees = GetEmployees(employees),
            Customers = GetCustomers(customers),
            Products = GetProducts(products)
        };
    }

    private static List<SelectListItem> GetEmployees(IEnumerable<EmployeeModel> employees)
    {
        return employees
            .Select(p => new SelectListItem()
            {
                Value = p.Id.ToString(),
                Text = p.Name
            })
            .ToList();
    }

    private static List<SelectListItem> GetCustomers(List<CustomerModel> customers)
    {
        return customers
            .Select(p => new SelectListItem()
            {
                Value = p.Id.ToString(),
                Text = p.Name
            })
            .ToList();
    }

    private static List<SelectListItem> GetProducts(List<ProductListModel> products)
    {
        return products
            .Select(p => new SelectListItem()
            {
                Value = p.Id.ToString(),
                Text = p.Name + " ($" + p.UnitPrice + ")"
            })
            .ToList();
    }
}