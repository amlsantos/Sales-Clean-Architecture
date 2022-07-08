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
    public async Task<IEnumerable<CustomerModel>> Get()
    {
        return await _query.Execute();
    }

    [HttpPost]
    public HttpResponseMessage Create(CreateCustomerModel model)
    {
        _command.Execute(model);
        
        return new HttpResponseMessage(HttpStatusCode.Created);
    }
}