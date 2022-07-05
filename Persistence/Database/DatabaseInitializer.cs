using Domain.Customers;
using Domain.Employees;
using Domain.Products;
using Domain.Sales;

namespace Persistence.Database;

public static class DatabaseInitializer
{
    public static readonly IEnumerable<Customer> Customers = new List<Customer>()
    {
        new() { Id = 1, Name = "Martin Fowler" },
        new() { Id = 2, Name = "Uncle Bob" },
        new() { Id = 3, Name = "Kent Beck" },
        new() { Id = 4, Name = "Brenda Delacruz" },
        new() { Id = 5, Name = "Harvir Estes" },
        new() { Id = 6, Name = "Maurice Boyd" },
        new() { Id = 7, Name = "Claire Lacey" },
        new() { Id = 8, Name = "Mahamed Vincent" },
        new() { Id = 9, Name = "Clayton Whitfield" },
        new() { Id = 10, Name = "Cali Spencer" },
        new() { Id = 11, Name = "Evie-Mai Fountain" },
        new() { Id = 12, Name = "Nia Hook" }
    };

    public static readonly IEnumerable<Employee> Employees = new List<Employee>()
    {
        new() { Id = 1, Name = "Eric Evans" },
        new() { Id = 2, Name = "Greg Young" },
        new() { Id = 3, Name = "Udi Dahan" },
        new() { Id = 4, Name = "Rhia Hatfield" },
        new() { Id = 5, Name = "Tasnim Stewart" },
        new() { Id = 6, Name = "Neve Kidd" },
        new() { Id = 7, Name = "Ezekiel Zamora" },
        new() { Id = 8, Name = "Donnie Everett" },
        new() { Id = 9, Name = "Renae Mcclure" },
        new() { Id = 10, Name = "Lucian Donald" },
        new() { Id = 11, Name = "Mea Craft" },
        new() { Id = 12, Name = "Neo Black" },
    };

    public static readonly IEnumerable<Product> Products = new List<Product>()
    {
        new() { Id = 1, Name = "Spaghetti", Price = 5m },
        new() { Id = 2, Name = "Lasagna", Price = 10m },
        new() { Id = 3, Name = "Ravioli", Price = 15m },
        new() { Id = 4, Name = "Salad", Price = 5m },
        new() { Id = 5, Name = "Sandwich", Price = 3m },
        new() { Id = 6, Name = "Tuna Steak", Price = 9m },
        new() { Id = 7, Name = "Shrimp", Price = 12m },
        new() { Id = 8, Name = "Rice", Price = 7m },
        new() { Id = 9, Name = "Pizza", Price = 12m },
        new() { Id = 10, Name = "Hamburger", Price = 8m },
        
    };

    public static readonly IEnumerable<Sale> Sales = new List<Sale>()
    {
        new()
        {
            Id = 1,
            Date = DateTime.Now.Date.AddDays(-3),
            CustomerId = Customers.ElementAt(0).Id,
            EmployeeId = Employees.ElementAt(0).Id,
            ProductId = Products.ElementAt(0).Id,
        },
        new()
        {
            Id = 2,
            Date = DateTime.Now.Date.AddDays(-2),
            CustomerId = Customers.ElementAt(1).Id,
            EmployeeId = Employees.ElementAt(1).Id,
            ProductId = Products.ElementAt(1).Id
        },
        new()
        {
            Id = 3,
            Date = DateTime.Now.Date.AddDays(-1),
            CustomerId = Customers.ElementAt(2).Id,
            EmployeeId = Employees.ElementAt(2).Id,
            ProductId = Products.ElementAt(2).Id
        }
    };
}