using Application.Employees.Commands.CreateEmployee;
using Application.Employees.Queries.GetEmployeeList;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace UI.Employees;

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
    public async Task TestGetIndexShouldReturnListOfEmployees()
    {
        // arrange
        var employeeModel = new EmployeeModel();
        _queryMock.Setup(x => x.Execute())
            .ReturnsAsync(new List<EmployeeModel>() { employeeModel });

        // act
        var viewResult = await _controller.Index();
        var result = (List<EmployeeModel>)viewResult.Model;

        // assert
        result.Single().Should().Be(employeeModel);
    }
    
    [Fact]
    public void TestGetCreateShouldReturnView()
    {
        // act
        var iActionResult = _controller.Create();
        var result = (ViewResult)iActionResult;

        // assert
        result.Should().NotBeNull();
    }
    
    [Fact]
    public async Task TestPostCreateShouldAddEmployeeAndRedirectToAction()
    {
        // arrange
        var createEmployeeModel = new CreateEmployeeModel();
        _commandMock.Setup(x => x.Execute(createEmployeeModel));

        // act
        var iActionResult = await _controller.Create(createEmployeeModel);
        var result = (RedirectToActionResult)iActionResult;

        // assert
        result.ActionName.Should().Be("Index");
        result.ControllerName.Should().Be("Employees");
    }
}