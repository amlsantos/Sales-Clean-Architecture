using Application.Employees.Commands.CreateEmployee;
using Application.Employees.Queries.GetEmployeeList;
using Microsoft.AspNetCore.Mvc;

namespace UI.Employees;

public class EmployeesController : Controller
{
    private readonly IGetEmployeesListQuery _query;
    private readonly ICreateEmployeeCommand _command;

    public EmployeesController(IGetEmployeesListQuery query, ICreateEmployeeCommand command)
    {
        _query = query;
        _command = command;
    }

    public async Task<ViewResult> Index()
    {
        var employees = await _query.Execute();
        return View(employees);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public IActionResult Create(CreateEmployeeModel model)
    {
        _command.Execute(model);
        return RedirectToAction("Index", "Employees");
    }
}