using Application.Interfaces;
using Domain.Products;
using FluentAssertions;
using MockQueryable.Moq;
using Moq;
using Xunit;

namespace Application.Products.Queries.GetProductsList;

public class GetProductsListQueryTests
{
    private readonly Mock<IDatabaseService> _databaseServiceMock;
    private readonly GetProductsListQuery _query;

    public GetProductsListQueryTests()
    {
        _databaseServiceMock = new Mock<IDatabaseService>();
        _query = new GetProductsListQuery(_databaseServiceMock.Object);
    }

    [Fact]
    public async Task TestExecuteShouldReturnListOfProducts()
    {
        // arrange
        var products = GetProducts();
        var dbSet = products.AsQueryable().BuildMockDbSet();
        _databaseServiceMock.Setup(x => x.Products).Returns(dbSet.Object);
        
        // act
        var results = await _query.Execute();
        var result = results.Single();
        
        // assert
        _databaseServiceMock.Verify(x => x.Products, Times.Once);
        result.Id.Should().Be(1);
        result.Name.Should().Be("Product 1");
    }

    private IEnumerable<Product> GetProducts()
    {
        return new List<Product>()
        {
            new()
            {
                Id = 1,
                Name = "Product 1",
                Price = 1m
            }
        };
    }
}