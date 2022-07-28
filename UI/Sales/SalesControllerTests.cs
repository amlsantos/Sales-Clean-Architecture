using Application.Customers.Queries.GetCustomerList;
using Application.Sales.Commands.CreateSale;
using Application.Sales.Queries.GetSalesDetail;
using Application.Sales.Queries.GetSalesList;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using UI.Sales.Models;
using UI.Sales.Services;
using Xunit;

namespace UI.Sales;

public class SalesControllerTests
{
    private readonly Mock<IGetSalesListQuery> _listQueryMock;
    private readonly Mock<IGetSaleDetailQuery> _detailQueryMock;
    private readonly Mock<ICreateSaleCommand> _saleCommandMock;
    private readonly Mock<ICreateSaleViewModelFactory> _factoryMock;
    private readonly SalesController _controller;
    
    public SalesControllerTests()
    {
        _listQueryMock = new Mock<IGetSalesListQuery>();
        _detailQueryMock = new Mock<IGetSaleDetailQuery>();
        _saleCommandMock = new Mock<ICreateSaleCommand>();
        _factoryMock = new Mock<ICreateSaleViewModelFactory>();
        _controller = new SalesController(_listQueryMock.Object, _detailQueryMock.Object, _saleCommandMock.Object, _factoryMock.Object);
    }
    
    [Fact]
    public async Task TestGetIndexShouldReturnListOfSales()
    {
        // arrange
        var salesListItemModel = new SalesListItemModel();
        _listQueryMock.Setup(x => x.Execute())
            .ReturnsAsync(new List<SalesListItemModel>() { salesListItemModel });

        // act
        var viewResult = await _controller.Index();
        var result = (List<SalesListItemModel>) viewResult.Model;
        
        // assert
        result.Single().Should().Be(salesListItemModel);
    }
    
    [Fact]
    public async Task TestGetCreateShouldReturnView()
    {
        // arrange
        var salesViewModel = new CreateSaleViewModel();
        _factoryMock.Setup(x => x.Create())
            .ReturnsAsync(salesViewModel);
        
        // act
        var viewResult = await _controller.Create();
        var model = viewResult.Model;

        // assert
        model.Should().NotBeNull();
        model.Should().Be(salesViewModel);
    }

    [Fact]
    public async Task TestPostCreateShouldAddSaleAndRedirectToAction()
    {
        // arrange
        var createSaleViewModel = new CreateSaleViewModel
        {
            SelectedCustomerId = 1,
            SelectedEmployeeId = 1,
            SelectedProductsIds = new int[] { 1, 2 }
        };
        var createSaleModel = new CreateSaleModel();

        _saleCommandMock.Setup(x => x.Execute(createSaleModel));

        // act
        var iActionResult = await _controller.Create(createSaleViewModel);
        var result = (RedirectToActionResult)iActionResult;
        
        // assert
        _saleCommandMock.Verify(x => x.Execute(It.IsAny<CreateSaleModel>()), Times.Once);
        result.ActionName.Should().Be("Index");
        result.ControllerName.Should().Be("Sales");
    }

    [Fact]
    public async Task TestGetDetailShouldReturnCreateSaleViewModel()
    {
        // arrange
        const int id = 1;
        var saleDetailModel = new SaleDetailModel();
        
        _detailQueryMock.Setup(x => x.Execute(id))
            .ReturnsAsync(saleDetailModel);
        
        // act
        var viewResult = await _controller.Detail(id);
        var model = viewResult.Model;

        // assert
        model.Should().Be(saleDetailModel);
    }
}