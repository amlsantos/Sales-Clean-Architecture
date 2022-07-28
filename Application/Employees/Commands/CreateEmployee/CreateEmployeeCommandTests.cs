using Application.Interfaces;
using Domain.Employees;
using MockQueryable.Moq;
using Moq;
using Xunit;

namespace Application.Employees.Commands.CreateEmployee;

public class CreateEmployeeCommandTests
{
    private readonly Mock<IDatabaseService> _databaseServiceMock;
    private readonly CreateEmployeeCommand _command;

    public CreateEmployeeCommandTests()
    {
        _databaseServiceMock = new Mock<IDatabaseService>();
        _command = new CreateEmployeeCommand(_databaseServiceMock.Object);
    }

    [Fact]
    public async Task TestExecuteShouldAddEmployeeToTheDatabase()
    {
        // arrange
        var employees = GetEmployees();
        var dbSet = employees.AsQueryable().BuildMockDbSet();
        _databaseServiceMock.Setup(x => x.Employees).Returns(dbSet.Object);
        var createEmployeeModel = new CreateEmployeeModel() { Name = "Employee 2" };
        
        // act
        await _command.Execute(createEmployeeModel);

        // assert
        _databaseServiceMock.Verify(x => x.Employees, Times.Once);
        _databaseServiceMock.Verify(x => x.SaveAsync(), Times.Once);
    }
    
    private IEnumerable<Employee> GetEmployees()
    {
        return new List<Employee>()
        {
            new()
            {
                Id = 1,
                Name = "Employee 1"
            }
        };
    }
}