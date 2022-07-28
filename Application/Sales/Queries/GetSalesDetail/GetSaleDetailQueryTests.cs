﻿using Application.Interfaces;
using Domain.Products;
using Domain.Sales;
using FluentAssertions;
using MockQueryable.Moq;
using Moq;
using Xunit;

namespace Application.Sales.Queries.GetSalesDetail;

public class GetSaleDetailQueryTests
{
    private readonly Mock<IDatabaseService> _databaseServiceMock;
    private readonly GetSaleDetailQuery  _query;

    public GetSaleDetailQueryTests()
    {
        _databaseServiceMock = new Mock<IDatabaseService>();
        _query = new GetSaleDetailQuery(_databaseServiceMock.Object); 
    }

    [Fact]
    public async Task TestExecuteShouldReturnListOfSales()
    {
        // arrange
        var sales = GetSales();
        var dbSet = sales.AsQueryable().BuildMockDbSet();
        _databaseServiceMock.Setup(x => x.Sales).Returns(dbSet.Object);
        
        // act
        var result = await _query.Execute(id: 1);
        
        // assert
        _databaseServiceMock.Verify(x => x.Sales, Times.Once);
        result.Id.Should().Be(1);
        result.CustomerId.Should().Be(1);
        result.CustomerName.Should().Be("Customer 1");
        result.EmployeeId.Should().Be(1);
        result.EmployeeName.Should().Be("Employee 1");
        result.TotalPrice.Should().Be(11);
        result.TotalQuantity.Should().Be(3);
        result.ProductDetails.Count.Should().Be(2);
    }
    
    private IEnumerable<Sale> GetSales()
    {
        return new List<Sale>()
        {
            new()
            {
                Id = 1,
                Customer = new ()
                {
                    Id = 1,
                    Name = "Customer 1"
                },
                Employee = new()
                {
                    Id = 1,
                    Name = "Employee 1"
                },
                TotalItems = 3,
                TotalPrice = 11,
                CreatedDate = new DateTime(2022, 07, 27),
                SaleProducts = new()
                {
                    new()
                    {
                        Id = 1,
                        Quantity = 1,
                        Product = new Product()
                        {
                            Name = "Product 1",
                            Price = 3m
                        }
                    },
                    new()
                    {
                        Id = 2,
                        Quantity = 2,
                        Product = new Product()
                        {
                            Name = "Product 2",
                            Price = 4m
                        }
                    }
                }
            }
        };
    }
}