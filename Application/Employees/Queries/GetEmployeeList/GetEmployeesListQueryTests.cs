using Application.Interfaces;
using Domain.Employees;
using FluentAssertions;
using MockQueryable.Moq;
using Moq;
using Xunit;

namespace Application.Employees.Queries.GetEmployeeList;

public class GetEmployeesListQueryTests
{
    private readonly Mock<IDatabaseService> _databaseServiceMock;
    private readonly GetEmployeesListQuery _query;

    public GetEmployeesListQueryTests()
    {
        _databaseServiceMock = new Mock<IDatabaseService>();
        _query = new GetEmployeesListQuery(_databaseServiceMock.Object);
    }

    [Fact]
    public async Task TestExecuteShouldReturnListOfEmployees()
    {
        // arrange
        var employees = GetEmployees();
        var dbSet = employees.AsQueryable().BuildMockDbSet();
        _databaseServiceMock.Setup(x => x.Employees).Returns(dbSet.Object);
        
        // act
        var results = await _query.Execute();
        var result = results.Single();
        
        // assert
        _databaseServiceMock.Verify(x => x.Employees, Times.Once);
        result.Id.Should().Be(1);
        result.Name.Should().Be("Employee 1");
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