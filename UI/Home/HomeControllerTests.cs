using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace UI.Home;

public class HomeControllerTests
{
    private readonly HomeController _controller;
    
    public HomeControllerTests()
    {
        _controller = new HomeController();
    }

    [Fact]
    public void TestGetIndexShouldReturnView()
    {
        // act
        var iActionResult = _controller.Index();
        var result = (ViewResult)iActionResult;

        // assert
        result.Should().NotBeNull();
    }

    [Fact]
    public void TestGetCustomersShouldReturnView()
    {
        // act
        var iActionResult = _controller.Customers();
        var result = (RedirectToActionResult)iActionResult;
        
        // assert
        result.ActionName.Should().Be("Index");
        result.ControllerName.Should().Be("Customers");
    }
    
    [Fact]
    public void TestGetProductsShouldReturnView()
    {
        // act
        var iActionResult = _controller.Products();
        var result = (RedirectToActionResult)iActionResult;
        
        // assert
        result.ActionName.Should().Be("Index");
        result.ControllerName.Should().Be("Products");
    }
    
    [Fact]
    public void TestGetEmployeesShouldReturnView()
    {
        // act
        var iActionResult = _controller.Employees();
        var result = (RedirectToActionResult)iActionResult;
        
        // assert
        result.ActionName.Should().Be("Index");
        result.ControllerName.Should().Be("Employees");
    }

    [Fact]
    public void TestGetSalesShouldReturnView()
    {
        // act
        var iActionResult = _controller.Sales();
        var result = (RedirectToActionResult)iActionResult;
        
        // assert
        result.ActionName.Should().Be("Index");
        result.ControllerName.Should().Be("Sales");
    }
}