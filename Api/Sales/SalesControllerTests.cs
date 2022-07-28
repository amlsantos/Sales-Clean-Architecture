using System.Net;
using Application.Sales.Commands.CreateSale;
using Application.Sales.Queries.GetSalesDetail;
using Application.Sales.Queries.GetSalesList;
using FluentAssertions;
using Moq;
using Xunit;

namespace Api.Sales;

public class SalesControllerTests
{
    private readonly Mock<IGetSalesListQuery> _listQueryMock;
    private readonly Mock<IGetSaleDetailQuery> _detailQueryMock;
    private readonly Mock<ICreateSaleCommand> _createCommandMock;
    private readonly SalesController _controller;

    public SalesControllerTests()
    {
        _listQueryMock = new Mock<IGetSalesListQuery>();
        _detailQueryMock = new Mock<IGetSaleDetailQuery>();
        _createCommandMock = new Mock<ICreateSaleCommand>();
        _controller = new SalesController(_listQueryMock.Object, _detailQueryMock.Object, _createCommandMock.Object);
    }

    [Fact]
    public async Task TestGetSalesListShouldReturnListOfSales()
    {
        // arrange
        var sales = GetSales();
        _listQueryMock.Setup(q => q.Execute()).ReturnsAsync(sales);

        // act
        var result = await _controller.Get();

        // assert
        _listQueryMock.Verify(q => q.Execute(), Times.Once);
        result.Should().NotBeEmpty();
        result.Should().NotBeNull();
    }

    private List<SalesListItemModel> GetSales()
    {
        return new List<SalesListItemModel>()
        {
            new()
            {
                Id = 1, CustomerName = "Customer", EmployeeName = "Employee", TotalPrice = 10,
                Products = new List<string>() { "Product 1" }
            }
        };
    }

    [Fact]
    public async Task TestGetSalesByIdListShouldReturnSale()
    {
        // arrange
        var sale = GetSale();
        var saleId = 1;
        _detailQueryMock.Setup(d => d.Execute(It.IsAny<int>())).ReturnsAsync(sale);

        // act
        var result = await _controller.Get(saleId);

        // assert
        result.Should().NotBeNull();
        result.Id.Should().Be(saleId);
        _detailQueryMock.Verify(d => d.Execute(It.IsAny<int>()), Times.Once);
    }

    private SaleDetailModel GetSale()
    {
        return new SaleDetailModel()
        {
            Id = 1, CustomerId = 1, EmployeeId = 1, CustomerName = "Customer", EmployeeName = "Employee",
            TotalPrice = 10m, TotalQuantity = 2,
            ProductDetails = new List<ProductDetailModel>()
                { new() { Quantity = 3, ProductId = 1, ProductName = "Product 1" } }
        };
    }

    [Fact]
    public async Task TestPostSaleShouldAddNewSale()
    {
        // arrange
        _createCommandMock.Setup(c => c.Execute(It.IsAny<CreateSaleModel>()));
        var model = new CreateSaleModel()
        {
            CustomerId = 1, EmployeeId = 1,
            Products = new List<ProductModel>() { new() { ProductId = 1, Quantity = 2 } }
        };

        // act
        var result = await _controller.Create(model);

        // assert
        _createCommandMock.Verify(c => c.Execute(It.IsAny<CreateSaleModel>()), Times.Once);
        result.Should().BeOfType<HttpResponseMessage>();
        result.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}