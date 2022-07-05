namespace Application.Employees.Queries.GetEmployeeList;

public interface IGetEmployeesListQuery
{
    List<EmployeeModel> Execute();
}