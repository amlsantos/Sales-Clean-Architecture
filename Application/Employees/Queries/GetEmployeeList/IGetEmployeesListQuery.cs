namespace Application.Employees.Queries.GetEmployeeList;

public interface IGetEmployeesListQuery
{
    Task<List<EmployeeModel>> Execute();
}