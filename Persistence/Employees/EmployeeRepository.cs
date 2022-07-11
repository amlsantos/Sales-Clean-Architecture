using Application.Interfaces.Persistence;
using Domain.Employees;
using Persistence.Database;

namespace Persistence.Employees;

public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(IDatabaseContext context) : base(context.Employees) { }
}