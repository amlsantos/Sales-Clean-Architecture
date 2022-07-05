using Application.Interfaces;

namespace Application.Employees.Queries.GetEmployeeList;

public class GetEmployeesListQuery : IGetEmployeesListQuery
{
    private readonly IDatabaseService _database;

    public GetEmployeesListQuery(IDatabaseService database)
    {
        _database = database;
    }

    public List<EmployeeModel> Execute()
    {
        var employees = _database.Employees.Select(p => new EmployeeModel
            {
                Id = p.Id,
                Name = p.Name
            });               

        return employees.ToList();
    }
}