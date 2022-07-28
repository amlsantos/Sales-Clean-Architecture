using Application.Products.Commands.CreateProduct;
using Application.Products.Queries.GetProductsList;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace UI.Products;

public class ProductControllerTests
{
    private readonly Mock<IGetProductsListQuery> _queryMock;
    private readonly Mock<ICreateProductCommand> _commandMock;
    private readonly ProductsController _controller;
    
    public ProductControllerTests()
    {
        _queryMock = new Mock<IGetProductsListQuery>();
        _commandMock = new Mock<ICreateProductCommand>();
        _controller = new ProductsController(_queryMock.Object, _commandMock.Object);
    }
    
    [Fact]
    public async Task TestGetIndexShouldReturnListOfProducts()
    {
        // arrange
        var productListModel = new ProductListModel();
        _queryMock.Setup(x => x.Execute())
            .ReturnsAsync(new List<ProductListModel>() { productListModel });

        // act
        var viewResult = await _controller.Index();
        var result = (List<ProductListModel>) viewResult.Model;
        
        // assert
        result.Single().Should().Be(productListModel);
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
    public async Task TestPostCreateShouldAddProductAndRedirectToAction()
    {
        // arrange
        var createProductModel = new CreateProductModel();
        _commandMock.Setup(x => x.Execute(createProductModel));

        // act
        var iActionResult = await _controller.Create(createProductModel);
        var result = (RedirectToActionResult)iActionResult;

        // assert
        result.ActionName.Should().Be("Index");
        result.ControllerName.Should().Be("Products");
    }
}