using System.Net;
using Application.Products.Commands.CreateProduct;
using Application.Products.Queries.GetProductsList;
using FluentAssertions;
using Moq;
using Xunit;

namespace Api.Products;

public class ProductsControllerTests
{
    private readonly Mock<IGetProductsListQuery> _queryMock;
    private readonly Mock<ICreateProductCommand> _commandMock;
    private readonly ProductsController _controller;

    public ProductsControllerTests()
    {
        _queryMock = new Mock<IGetProductsListQuery>();
        _commandMock = new Mock<ICreateProductCommand>();
        _controller = new ProductsController(_queryMock.Object, _commandMock.Object);
    }

    [Fact]
    public async Task TestGetProductsListShouldReturnListOfProducts()
    {
        // arrange
        var products = new List<ProductListModel>() { new() { Id = 1, Name = "Product 1", UnitPrice = 10 } };
        _queryMock.Setup(q => q.Execute()).ReturnsAsync(products);

        // act
        var result = await _controller.Get();

        // assert
        _queryMock.Verify(c => c.Execute(), Times.Once);
        result.Should().NotBeEmpty();
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task TestPostProductsShouldAddNewProducts()
    {
        // arrange
        _commandMock.Setup(c => c.Execute(It.IsAny<CreateProductModel>()));
        var model = new CreateProductModel() { Name = "Product 1", Price = 10 };

        // act
        var result = await _controller.Create(model);

        // assert
        _commandMock.Verify(c => c.Execute(It.IsAny<CreateProductModel>()), Times.Once);
        result.Should().BeOfType<HttpResponseMessage>();
        result.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}