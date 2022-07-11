using Application.Interfaces.Infrastructure;
using Application.Interfaces.Persistence;
using Application.Sales.Commands.CreateSale.Factory;
using Application.Sales.Commands.CreateSale.Repository;
using Common.Dates;
using Domain.SalesProducts;

namespace Application.Sales.Commands.CreateSale;

public class CreateSaleCommand : ICreateSaleCommand
{
    private readonly IDateService _dateService;
    private readonly ISaleRepositoryFacade _facade;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISaleFactory _factory;
    private readonly IInventoryService _inventory;

    public CreateSaleCommand(
        IDateService dateService, 
        ISaleRepositoryFacade facade,
        IUnitOfWork unitOfWork,
        ISaleFactory factory,
        IInventoryService inventory)
    {
        _dateService = dateService;
        _facade = facade;
        _unitOfWork = unitOfWork;
        _factory = factory;
        _inventory = inventory;
    }
    
    public async Task Execute(CreateSaleModel model)
    {
        var date = _dateService.GetDate();
        var customer = await _facade.GetCustomer(model.CustomerId);
        var employee = await _facade.GetEmployee(model.EmployeeId);
        var saleProducts = await ToSalesProducts(model.Products);
        var sale = _factory.Create(date, customer.Id, employee.Id, saleProducts);

        saleProducts.ForEach(sp => 
            _inventory.NotifySaleOcurred(sp.ProductId, sp.Quantity));
        
        await _facade.AddSaleAsync(sale);
        await _unitOfWork.SaveAsync();
    }
    
    private async Task<List<SaleProduct>> ToSalesProducts(List<ProductModel> selectedProducts)
    {
        var output = new List<SaleProduct>();
        
        foreach (var product in selectedProducts)
        {
            var model = new SaleProduct()
            {
                Product = await _facade.GetProduct(product.ProductId),
                Quantity = product.Quantity
            };
            
            output.Add(model);
        }

        return output;
    }
}