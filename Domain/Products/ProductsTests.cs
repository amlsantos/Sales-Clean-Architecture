using FluentAssertions;
using Xunit;

namespace Domain.Products;

public class ProductsTests
{
    private readonly Product _product;
    private const int Id = 1;
    private const string Name = "Test";

    public ProductsTests()
    {
        _product = new Product();
    }

    [Fact]
    public void TestSetAndGetId()
    {
        _product.Id = Id;

        _product.Id.Should().Be(Id);
    }

    [Fact]
    public void TestSetAndGetName()
    {
        _product.Name = Name;

        _product.Name.Should().Be(Name);
    }
}