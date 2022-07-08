using Application.Sales.Commands.CreateSale;
using Application.Sales.Queries.GetSalesDetail;
using Application.Sales.Queries.GetSalesList;
using Microsoft.AspNetCore.Mvc;
using UI.Sales.Models;
using UI.Sales.Services;

namespace UI.Sales;

public class SalesController : Controller
{
    private readonly IGetSalesListQuery _salesListQuery;
    private readonly IGetSaleDetailQuery _saleDetailQuery;
    private readonly ICreateSaleCommand _createCommand;
    private readonly ICreateSaleViewModelFactory _factory;

    public SalesController(IGetSalesListQuery salesListQuery, IGetSaleDetailQuery saleDetailQuery, ICreateSaleCommand createCommand, ICreateSaleViewModelFactory factory)
    {
        _salesListQuery = salesListQuery;
        _saleDetailQuery = saleDetailQuery;
        _createCommand = createCommand;
        _factory = factory;
    }
    
    public ViewResult Index()
    {
        var sales = _salesListQuery.Execute();
        return View(sales);
    }

    public ViewResult Create()
    {
        var viewModel = _factory.Create();
        return View(viewModel);
    }
    
    [HttpPost]
    public IActionResult Create(CreateSaleViewModel viewModel)
    {
        var model = new CreateSaleModel
        {
            CustomerId = viewModel.SelectedCustomerId,
            EmployeeId = viewModel.SelectedEmployeeId,
            Products = viewModel.SelectedProductsIds.Select(id => new ProductModel()
            {
               ProductId = id,
               Quantity = 1
            }).ToList()
        };

        _createCommand.Execute(model);

        return RedirectToAction("Index", "Sales");
    }

    public ViewResult Detail(int id)
    {
        var sale = _saleDetailQuery.Execute(id);
        return View(sale);
    }
}