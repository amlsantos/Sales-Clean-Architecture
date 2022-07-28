using System.Net;
using Application.Customers.Commands.CreateCustomer;
using Application.Customers.Queries.GetCustomerList;
using FluentAssertions;
using Moq;
using Xunit;

namespace Api.Customers;

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
    public async Task TestGetCustomersListShouldReturnListOfCustomers()
    {
        // arrange
        var customers = new List<CustomerModel>() { new() { Id = 1, Name = "Customer 1" } };
        _queryMock.Setup(q => q.Execute()).ReturnsAsync(customers);

        // act
        var result = await _controller.Get();

        // assert
        result.Should().NotBeEmpty();
        result.Should().NotBeNull();
        _queryMock.Verify(q => q.Execute(), Times.Once);
    }

    [Fact]
    public async Task TestPostCustomersShouldAddNewCustomer()
    {
        // arrange
        _commandMock.Setup(c => c.Execute(It.IsAny<CreateCustomerModel>()));
        var model = new CreateCustomerModel() { Name = "Customer 2" };

        // act
        var result = await _controller.Create(model);

        // assert
        _commandMock.Verify(c => c.Execute(It.IsAny<CreateCustomerModel>()), Times.Once);
        
        result.Should().BeOfType<HttpResponseMessage>();
        result.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}