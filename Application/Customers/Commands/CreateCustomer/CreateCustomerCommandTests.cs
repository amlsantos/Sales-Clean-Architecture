using Application.Interfaces;
using Domain.Customers;
using FluentAssertions;
using MockQueryable.Moq;
using Moq;
using Xunit;

namespace Application.Customers.Commands.CreateCustomer;

public class CreateCustomerCommandTests
{
    private readonly Mock<IDatabaseService> _databaseServiceMock;
    private readonly CreateCustomerCommand _command;
    
    public CreateCustomerCommandTests()
    {
        _databaseServiceMock = new Mock<IDatabaseService>();
        _command = new CreateCustomerCommand(_databaseServiceMock.Object);
    }

    [Fact]
    public async Task TestExecuteShouldAddCustomerToTheDatabase()
    {
        // arrange
        var customers = GetCustomers();
        var dbSet = customers.AsQueryable().BuildMockDbSet();
        _databaseServiceMock.Setup(x => x.Customers).Returns(dbSet.Object);
        var createCustomerModel = new CreateCustomerModel() { Name = "Customer 2" };
        
        // act
        await _command.Execute(createCustomerModel);

        // assert
        _databaseServiceMock.Verify(x => x.Customers, Times.Once);
        _databaseServiceMock.Verify(x => x.SaveAsync(), Times.Once);
    }
    
    private IEnumerable<Customer> GetCustomers()
    {
        return new List<Customer>()
        {
            new()
            {
                Id = 1,
                Name = "Customer 1"
            }
        };
    }
}