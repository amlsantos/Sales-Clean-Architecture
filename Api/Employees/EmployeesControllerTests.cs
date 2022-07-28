using System.Net;
using Application.Employees.Commands.CreateEmployee;
using Application.Employees.Queries.GetEmployeeList;
using Domain.Sales;
using FluentAssertions;
using Moq;
using Xunit;

namespace Api.Employees;

public class EmployeesControllerTests
{
    private readonly Mock<IGetEmployeesListQuery> _queryMock;
    private readonly Mock<ICreateEmployeeCommand> _commandMock;
    private readonly EmployeesController _controller;

    public EmployeesControllerTests()
    {
        _queryMock = new Mock<IGetEmployeesListQuery>();
        _commandMock = new Mock<ICreateEmployeeCommand>();
        _controller = new EmployeesController(_queryMock.Object, _commandMock.Object);
    }

    [Fact]
    public async Task TestGetEmployeesListShouldReturnListOfEmployees()
    {
        // arrange
        var employees = new List<EmployeeModel>() { new EmployeeModel() { Id = 1, Name = "Employee 1" } };
        _queryMock.Setup(q => q.Execute()).ReturnsAsync(employees);

        // act
        var result = await _controller.Get();

        // assert
        result.Should().NotBeEmpty();
        result.Should().NotBeNull();
        _queryMock.Verify(q => q.Execute(), Times.Once);
    }

    [Fact]
    public async Task TestPostEmployeesShouldAddNewEmployee()
    {
        // arrange
        _commandMock.Setup(c => c.Execute(It.IsAny<CreateEmployeeModel>()));
        var model = new CreateEmployeeModel() { Name = "Employee 1" };

        // act
        var result = await _controller.Create(model);

        // assert
        _commandMock.Verify(c => c.Execute(It.IsAny<CreateEmployeeModel>()), Times.Once);
        result.Should().BeOfType<HttpResponseMessage>();
        result.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}