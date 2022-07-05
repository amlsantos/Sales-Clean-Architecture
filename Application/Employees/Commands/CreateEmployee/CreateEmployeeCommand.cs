using Application.Interfaces;
using Domain.Employees;

namespace Application.Employees.Commands.CreateEmployee;

public class CreateEmployeeCommand : ICreateEmployeeCommand
{
    private readonly IDatabaseService _database;

    public CreateEmployeeCommand(IDatabaseService database) => _database = database;

    public async Task Execute(CreateEmployeeModel model)
    {
        var employee = new Employee()
        {
            Name = model.Name
        };

        _database.Employees.Add(employee);
        await _database.Save();
    }
}