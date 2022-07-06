using Domain.Customers;
using Domain.Employees;
using Domain.Products;
using Domain.Sales;
using Domain.SalesProducts;

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
        new() { Id = 11, Name = "Bean sauce", Price = 3m },
        new() { Id = 12, Name = "Brown sugar", Price = 6m },
        new() { Id = 13, Name = "Adobo", Price = 1m },
        new() { Id = 14, Name = "Hoisin sauce", Price = 9m },
        new() { Id = 15, Name = "Sesame seeds", Price = 12m },
        new() { Id = 16, Name = "Cottage cheese", Price = 14m },
        new() { Id = 17, Name = "Chai", Price = 19m },
        new() { Id = 18, Name = "Plantains", Price = 5m },
        new() { Id = 19, Name = "Pasta", Price = 3m },
        new() { Id = 20, Name = "Coconut milk", Price = 12m },
        new() { Id = 21, Name = "Cilantro", Price = 5m },
        new() { Id = 22, Name = "Rabbits", Price = 1m },
        new() { Id = 23, Name = "Plums", Price = 9m },
        new() { Id = 24, Name = "Rice vinegar", Price = 12m },
        new() { Id = 25, Name = "Peanuts", Price = 6m },
        new() { Id = 26, Name = "Jack cheese", Price = 6m },
        new() { Id = 27, Name = "Turkeys", Price = 21m },
        new() { Id = 28, Name = "Broth", Price = 22m },
        new() { Id = 29, Name = "Couscous", Price = 15m },
        new() { Id = 30, Name = "Coconut oil", Price = 18m },
        
    };

    public static readonly IEnumerable<Sale> Sales = new List<Sale>()
    {
        new()
        {
            Id = 1,
            CreatedDate = DateTime.Now.Date.AddDays(-3),
            CustomerId = Customers.ElementAt(0).Id,
            EmployeeId = Employees.ElementAt(0).Id,
        },
        new()
        {
            Id = 2,
            CreatedDate = DateTime.Now.Date.AddDays(-2),
            CustomerId = Customers.ElementAt(1).Id,
            EmployeeId = Employees.ElementAt(1).Id,
        },
        new()
        {
            Id = 3,
            CreatedDate = DateTime.Now.Date.AddDays(-1),
            CustomerId = Customers.ElementAt(2).Id,
            EmployeeId = Employees.ElementAt(2).Id,
        },
        new()
        {
            Id = 4,
            CreatedDate = DateTime.Now.Date.AddDays(-1),
            CustomerId = Customers.ElementAt(2).Id,
            EmployeeId = Employees.ElementAt(2).Id,
        },
        new()
        {
            Id = 5,
            CreatedDate = DateTime.Now.Date.AddDays(-1),
            CustomerId = Customers.ElementAt(0).Id,
            EmployeeId = Employees.ElementAt(1).Id,
        },
        new()
        {
            Id = 6,
            CreatedDate = DateTime.Now.Date.AddDays(-1),
            CustomerId = Customers.ElementAt(1).Id,
            EmployeeId = Employees.ElementAt(2).Id,
        }
    };

    public static readonly IEnumerable<SaleProduct> SalesProducts = new List<SaleProduct>()
    {
        new ()
        {
            Id = 1,
            ProductId = Products.ElementAt(0).Id,
            SaleId = Sales.ElementAt(0).Id,
            Quantity = 2
        },
        new ()
        {
            Id = 2,
            ProductId = Products.ElementAt(1).Id,
            SaleId = Sales.ElementAt(0).Id,
            Quantity = 1
        },
        new ()
        {
            Id = 3,
            ProductId = Products.ElementAt(2).Id,
            SaleId = Sales.ElementAt(0).Id,
            Quantity = 1
        },
        new ()
        {
            Id = 4,
            ProductId = Products.ElementAt(3).Id,
            SaleId = Sales.ElementAt(0).Id,
            Quantity = 2
        },
        new ()
        {
            Id = 5,
            ProductId = Products.ElementAt(4).Id,
            SaleId = Sales.ElementAt(0).Id,
            Quantity = 1
        },
        new ()
        {
            Id = 6,
            ProductId = Products.ElementAt(5).Id,
            SaleId = Sales.ElementAt(1).Id,
            Quantity = 1
        },
        new ()
        {
            Id = 7,
            ProductId = Products.ElementAt(6).Id,
            SaleId = Sales.ElementAt(1).Id,
            Quantity = 2
        },
        new ()
        {
            Id = 8,
            ProductId = Products.ElementAt(7).Id,
            SaleId = Sales.ElementAt(2).Id,
            Quantity = 2
        },
        new ()
        {
            Id = 9,
            ProductId = Products.ElementAt(8).Id,
            SaleId = Sales.ElementAt(2).Id,
            Quantity = 3
        },
        new ()
        {
            Id = 10,
            ProductId = Products.ElementAt(9).Id,
            SaleId = Sales.ElementAt(3).Id,
            Quantity = 5
        },
        new ()
        {
            Id = 11,
            ProductId = Products.ElementAt(0).Id,
            SaleId = Sales.ElementAt(4).Id,
            Quantity = 7
        },
        new ()
        {
            Id = 12,
            ProductId = Products.ElementAt(0).Id,
            SaleId = Sales.ElementAt(5).Id,
            Quantity = 3
        },
        new ()
        {
            Id = 13,
            ProductId = Products.ElementAt(1).Id,
            SaleId = Sales.ElementAt(5).Id,
            Quantity = 7
        },
        new ()
        {
            Id = 14,
            ProductId = Products.ElementAt(2).Id,
            SaleId = Sales.ElementAt(5).Id,
            Quantity = 5
        },
        new ()
        {
            Id = 15,
            ProductId = Products.ElementAt(3).Id,
            SaleId = Sales.ElementAt(5).Id,
            Quantity = 4
        },
        new ()
        {
            Id = 16,
            ProductId = Products.ElementAt(4).Id,
            SaleId = Sales.ElementAt(5).Id,
            Quantity = 1
        }
    };
}