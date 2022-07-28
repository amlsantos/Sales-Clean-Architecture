using Application.Interfaces;
using Domain.Customers;
using Domain.Products;
using Domain.Sales;
using Domain.SalesProducts;
using FluentAssertions;
using MockQueryable.Moq;
using Moq;
using Xunit;

namespace Application.Customers.Queries.GetCustomerList;

public class GetCustomersListQueryTests
{
    private readonly Mock<IDatabaseService> _databaseServiceMock;
    private readonly GetCustomersListQuery _query;

    public GetCustomersListQueryTests()
    {
        _databaseServiceMock = new Mock<IDatabaseService>();
        _query = new GetCustomersListQuery(_databaseServiceMock.Object);
    }

    [Fact]
    public async Task TestExecuteShouldReturnListOfCustomers()
    {
        // arrange
        var customers = GetCustomers();
        var dbSet = customers.AsQueryable().BuildMockDbSet();
        _databaseServiceMock.Setup(x => x.Customers).Returns(dbSet.Object);

        // act
        var results = await _query.Execute();
        var result = results.Single();

        // assert
        _databaseServiceMock.Verify(x => x.Customers, Times.Once);
        result.Id.Should().Be(1);
        result.Name.Should().Be("Customer 1");
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