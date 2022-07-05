using Application.Interfaces;
using Application.Sales.Commands.CreateSale.Factory;
using Common.Dates;

namespace Application.Sales.Commands.CreateSale;

public class CreateSaleCommand : ICreateSaleCommand
{
    private readonly IDateService _dateService;
    private readonly IDatabaseService _database;
    private readonly ISaleFactory _factory;
    private readonly IInventoryService _inventory;

    public CreateSaleCommand(
        IDateService dateService,
        IDatabaseService database,
        ISaleFactory factory,
        IInventoryService inventory)
    {
        _dateService = dateService;
        _database = database;
        _factory = factory;
        _inventory = inventory;
    }

    public async Task Execute(CreateSaleModel model)
    {
        var date = _dateService.GetDate();

        var customer = _database.Customers.Single(p => p.Id == model.CustomerId);
        var employee = _database.Employees.Single(p => p.Id == model.EmployeeId);
        var product = _database.Products.Single(p => p.Id == model.ProductId);
        var quantity = model.Quantity;

        var sale = _factory.Create(
            date,
            customer, 
            employee, 
            product, 
            quantity);

        _database.Sales.Add(sale);
        await _database.Save();
        
        _inventory.NotifySaleOcurred(product.Id, quantity);
    }
}