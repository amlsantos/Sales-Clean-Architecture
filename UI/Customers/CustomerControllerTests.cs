using Application.Customers.Commands.CreateCustomer;
using Application.Customers.Queries.GetCustomerList;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace UI.Customers;

public class CustomerControllerTests
{
    private readonly Mock<IGetCustomersListQuery> _queryMock;
    private readonly Mock<ICreateCustomerCommand> _commandMock;
    private readonly CustomersController _controller;
    
    public CustomerControllerTests()
    {
        _queryMock = new Mock<IGetCustomersListQuery>();
        _commandMock = new Mock<ICreateCustomerCommand>();
        _controller = new CustomersController(_queryMock.Object, _commandMock.Object);
    }

    [Fact]
    public async Task TestGetIndexShouldReturnListOfCustomers()
    {
        // arrange
        var customerModel = new CustomerModel();
        _queryMock.Setup(x => x.Execute())
            .ReturnsAsync(new List<CustomerModel>() { customerModel });

        // act
        var viewResult = await _controller.Index();
        var result = (List<CustomerModel>) viewResult.Model;
        
        // assert
        result.Single().Should().Be(customerModel);
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
    public async Task TestPostCreateShouldAddCustomerAndRedirectToAction()
    {
        // arrange
        var createCustomerModel = new CreateCustomerModel();
        _commandMock.Setup(x => x.Execute(createCustomerModel));

        // act
        var iActionResult = await _controller.Create(createCustomerModel);
        var result = (RedirectToActionResult)iActionResult;

        // assert
        result.ActionName.Should().Be("Index");
        result.ControllerName.Should().Be("Customers");
    }
}