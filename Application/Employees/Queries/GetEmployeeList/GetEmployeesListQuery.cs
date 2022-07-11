using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Employees.Queries.GetEmployeeList;

public class GetEmployeesListQuery : IGetEmployeesListQuery
{
    private readonly IDatabaseService _database;

    public GetEmployeesListQuery(IDatabaseService database)
    {
        _database = database;
    }

    public async Task<List<EmployeeModel>> Execute()
    {
        var employees = await _database.Employees.GetAll();

        return employees.Select(p => new EmployeeModel
        {
            Id = p.Id,
            Name = p.Name
        }).ToList();
    }
}