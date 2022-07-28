using FluentAssertions;
using Xunit;

namespace Domain.SalesProducts;

public class SaleProductTests
{
    private readonly SaleProduct _saleProduct;
    private const int Id = 1;
    private const int SaleId = 2;
    private const int ProductId = 3;
    private const int Quantity = 4;

    public SaleProductTests()
    {
        _saleProduct = new SaleProduct();
    }

    [Fact]
    public void TestSetAndGetId()
    {
        _saleProduct.Id = Id;

        _saleProduct.Id.Should().Be(Id);
    }
    
    [Fact]
    public void TestSetAndGetSaleId()
    {
        _saleProduct.SaleId = SaleId;

        _saleProduct.SaleId.Should().Be(SaleId);
    }
    
    [Fact]
    public void TestSetAndGetProductId()
    {
        _saleProduct.ProductId = ProductId;

        _saleProduct.ProductId.Should().Be(ProductId);
    }
    
    [Fact]
    public void TestSetAndGetQuantity()
    {
        _saleProduct.Quantity = Quantity;

        _saleProduct.Quantity.Should().Be(Quantity);
    }
}