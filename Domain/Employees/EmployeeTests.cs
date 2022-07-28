using FluentAssertions;
using Xunit;

namespace Domain.Employees;

public class EmployeeTests
{
    private readonly Employee _employee;
    private const int Id = 1;
    private const string Name = "Test";

    public EmployeeTests()
    {
        _employee = new Employee();
    }

    [Fact]
    public void TestSetAndGetId()
    {
        // arrange
        _employee.Id = Id;

        // assert
        _employee.Id.Should().Be(Id);
    }

    [Fact]
    public void TestSetAndGetName()
    {
        // arrange
        _employee.Name = Name;

        // assert
        _employee.Name.Should().Be(Name);
    }
}