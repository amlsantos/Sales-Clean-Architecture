using System.Net;
using Application.Customers.Commands.CreateCustomer;
using Application.Customers.Queries.GetCustomerList;
using Microsoft.AspNetCore.Mvc;

namespace Api.Customers;

[ApiController]
[Route("[controller]")]
public class CustomersController : ControllerBase
{
    private readonly IGetCustomersListQuery _query;
    private readonly ICreateCustomerCommand _command;

    public CustomersController(IGetCustomersListQuery query, ICreateCustomerCommand command)
    {
        _query = query;
        _command = command;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var response = await _query.Execute();

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCustomerModel model)
    {
        await _command.Execute(model);

        return Created(model.Name, model);
    }
}