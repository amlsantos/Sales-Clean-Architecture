using Application.Customers.Commands.CreateCustomer;
using Application.Customers.Queries.GetCustomerList;
using Microsoft.AspNetCore.Mvc;

namespace UI.Customers;

public class CustomersController : Controller
{
    private readonly IGetCustomersListQuery _query;
    private readonly ICreateCustomerCommand _command;

    public CustomersController(IGetCustomersListQuery query, ICreateCustomerCommand command)
    {
        _query = query;
        _command = command;
    }

    [HttpGet]
    public async Task<ViewResult> Index()
    {
        var customers = await _query.Execute();
        return View(customers);
    }

    [HttpGet]
    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(CreateCustomerModel model)
    {
        await _command.Execute(model);
        return RedirectToAction("Index", "Customers");
    }
}