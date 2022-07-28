using Domain.Customers;
using Domain.Employees;
using Domain.Products;
using Domain.SalesProducts;
using FluentAssertions;
using Xunit;

namespace Domain.Sales;

public class SaleTests
{
    private readonly Sale _sale;
    
    public SaleTests()
    {
        _sale = new Sale();
    }

    [Fact]
    public void TestSetAndGetId()
    {
        // arrange
        const int id = 1;
        
        // act
        _sale.Id = id;

        // assert
        _sale.Id.Should().Be(id);
    }

    [Fact]
    public void TestSetAndGetDate()
    {
        // arrange
        var createdDate = new DateTime(2001, 2, 3);
        
        // act
        _sale.CreatedDate = createdDate;

        // assert
        _sale.CreatedDate.Should().Be(createdDate);
    }

    [Fact]
    public void TestSetAndGetCustomer()
    {
        // arrange
        var customer = new Customer();
        
        // act
        _sale.Customer = customer;

        // assert
        _sale.Customer.Should().Be(customer);
    }

    [Fact]
    public void TestSetAndGetEmployee()
    {
        // arrange
        var employee = new Employee();
        
        // act
        _sale.Employee = employee;

        // assert
        _sale.Employee.Should().Be(employee);
    }

    [Fact]
    public void TestSetAndGetProduct()
    {
        // arrange
        var product1 = CreateProduct(quantity: 2, price: 2);
        var product2 = CreateProduct(quantity: 3, price: 3);
        
        // act
        _sale.SaleProducts = CreateSaleProducts(product1, product2);

        // assert
        _sale.SaleProducts.Should().NotBeEmpty()
            .And.HaveCount(2)
            .And.ContainInOrder(product1, product2);
    }

    [Fact]
    public void TestSetSaleProductsShouldRecomputeTotalPrice()
    {
        // arrange
        const int quantity1 = 2;
        const int price1 = 2;
        var product1 = CreateProduct(quantity1, price1);
        
        const int quantity2 = 2;
        const int price2 = 2;
        var product2 = CreateProduct(quantity2, price2);
        
        // act
        _sale.SaleProducts = CreateSaleProducts(product1, product2);

        // assert
        _sale.TotalPrice.Should().Be(quantity1 * price1 + quantity2 * price2);
    }

    [Fact]
    public void TestSetSaleProductsShouldRecomputeTotalItems()
    {
        // arrange
        const int quantity1 = 2;
        var product1 = CreateProduct(quantity1, price: 2);
        
        const int quantity2 = 3;
        var product2 = CreateProduct(quantity2, price: 3);
        
        // act
        _sale.SaleProducts = CreateSaleProducts(product1, product2);

        // assert
        _sale.TotalItems.Should().Be(quantity1 + quantity2);
    }
    
    private SaleProduct CreateProduct(int quantity, int price)
    {
        return new SaleProduct
        {
            Quantity = quantity,
            Product = new Product
            {
                Price = price
            }
        };
    }

    private List<SaleProduct> CreateSaleProducts(params SaleProduct[] list)
    {
        return list.ToList();
    }
}