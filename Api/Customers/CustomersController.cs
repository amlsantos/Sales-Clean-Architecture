using Application.Customers.Queries.GetCustomerList;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomersController : ControllerBase
{
    private readonly IGetCustomersListQuery _query;

    public CustomersController(IGetCustomersListQuery query) => _query = query;

    [HttpGet]
    public IEnumerable<CustomerModel> Get()
    {
        return _query.Execute();
    }
}