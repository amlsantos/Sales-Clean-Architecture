using Application.Interfaces;
using Application.Sales.Commands.CreateSale.Factory;
using Common.Dates;
using Domain.Products;
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
        var products = ToSalesProducts(await _database.Products.GetAll().ToListAsync(), model.Products);

        var sale = _factory.Create(
            date,
            customer, 
            employee, 
            products);

        await _database.Sales.Add(sale);
        await _database.Save();
        
        model.Products
            .ForEach(p => 
                _inventory.NotifySaleOcurred(p.ProductId, p.Quantity));
    }
    
    private List<SaleProduct> ToSalesProducts(List<Product> productsDbSet, List<ProductModel> productsModel)
    {
        return productsModel
            .Select(productModel => new SaleProduct()
            {
                Product = productsDbSet.Single(p => p.Id == productModel.ProductId), 
                Quantity = productModel.Quantity
            })
        .ToList();
    }
}