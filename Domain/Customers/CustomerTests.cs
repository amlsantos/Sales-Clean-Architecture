using FluentAssertions;
using Xunit;

namespace Domain.Customers;

public class CustomerTests
{
    private readonly Customer _customer;
    private const int Id = 1;
    private const string Name = "Test";
    
    public CustomerTests()
    {
        _customer = new Customer();
    }

    [Fact]
    public void TestSetAndGetId()
    {
        // arrange
        _customer.Id = Id;

        // assert
        _customer.Id.Should().Be(Id);
    }

    [Fact]
    public void TestSetAndGetName()
    {
        // arrange
        _customer.Name = Name;
        
        // assert
        _customer.Name.Should().Be(Name);
    }
}