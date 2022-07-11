using Application.Interfaces;
using Application.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Employees.Queries.GetEmployeeList;

public class GetEmployeesListQuery : IGetEmployeesListQuery
{
    private readonly IEmployeeRepository _repository;

    public GetEmployeesListQuery(IEmployeeRepository repository) => _repository = repository;

    public async Task<List<EmployeeModel>> Execute()
    {
        var employees = await _repository.GetAll();

        return employees.Select(p => new EmployeeModel
        {
            Id = p.Id,
            Name = p.Name
        }).ToList();
    }
}