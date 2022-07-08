using System.Net;
using Application.Employees.Commands.CreateEmployee;
using Application.Employees.Queries.GetEmployeeList;
using Microsoft.AspNetCore.Mvc;

namespace Api.Employees;

[ApiController]
[Route("[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IGetEmployeesListQuery _query;
    private readonly ICreateEmployeeCommand _command;

    public EmployeesController(IGetEmployeesListQuery query, ICreateEmployeeCommand command)
    {
        _query = query;
        _command = command;
    }

    [HttpGet]
    public IEnumerable<EmployeeModel> Get()
    {
        return _query.Execute();
    }

    [HttpPost]
    public async Task<HttpResponseMessage> Create(CreateEmployeeModel model)
    {
        await _command.Execute(model);
        
        return new HttpResponseMessage(HttpStatusCode.Created);
    }
}