namespace Application.Employees.Commands.CreateEmployee;

public interface ICreateEmployeeCommand
{
    Task Execute(CreateEmployeeModel model);
}