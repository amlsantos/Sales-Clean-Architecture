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
        var customer = _database.Customers.FirstOrDefault(p => p.Id == model.CustomerId);
        var employee = _database.Employees.FirstOrDefault(p => p.Id == model.EmployeeId);
        var products = await _database.Products.ToListAsync();
        var saleProducts = ToSalesProducts(products, model.Products);
        var sale = _factory.Create(date, customer.Id, employee.Id, saleProducts);

        await _database.Sales.AddAsync(sale);
        await _database.SaveAsync();
        
        sale.SaleProducts.ForEach(sp => _inventory.NotifySaleOcurred(sp.ProductId, sp.Quantity));
    }

    private List<SaleProduct> ToSalesProducts(List<Product> products, List<ProductModel> productsModel)
    {
        return productsModel.Select(productModel => new SaleProduct()
            {
                Product = products.Single(p => p.Id == productModel.ProductId),
                Quantity = productModel.Quantity
            })
            .ToList();
    }
}