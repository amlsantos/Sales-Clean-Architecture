using Application.Interfaces;
using Application.Sales.Commands.CreateSale.Factory;
using Common.Dates;
using Domain.Products;
using Domain.Sales;
using Domain.SalesProducts;
using Microsoft.EntityFrameworkCore;

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
        var customer = await _database.Customers.Get(model.CustomerId);
        var employee = await _database.Employees.Get(model.EmployeeId);
        var saleProducts = await ToSalesProducts(model.Products);
        var sale = _factory.Create(date, customer.Id, employee.Id, saleProducts);

        saleProducts.ForEach(sp => 
            _inventory.NotifySaleOcurred(sp.ProductId, sp.Quantity));
        
        await _database.Sales.AddAsync(sale);
        await _database.SaveAsync();
    }
    
    private async Task<List<SaleProduct>> ToSalesProducts(List<ProductModel> selectedProducts)
    {
        var output = new List<SaleProduct>();
        
        foreach (var product in selectedProducts)
        {
            var model = new SaleProduct()
            {
                Product = await _database.Products.Get(product.ProductId),
                Quantity = product.Quantity
            };
            
            output.Add(model);
        }

        return output;
    }
}