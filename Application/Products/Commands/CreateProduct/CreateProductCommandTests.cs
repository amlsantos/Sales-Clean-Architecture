using Application.Employees.Commands.CreateEmployee;
using Application.Interfaces;
using Domain.Products;
using MockQueryable.Moq;
using Moq;
using Xunit;

namespace Application.Products.Commands.CreateProduct;

public class CreateProductCommandTests
{
    private readonly Mock<IDatabaseService> _databaseServiceMock;
    private readonly CreateProductCommand  _command;

    public CreateProductCommandTests()
    {
        _databaseServiceMock = new Mock<IDatabaseService>();
        _command = new CreateProductCommand(_databaseServiceMock.Object);
    }
    
    [Fact]
    public async Task TestExecuteShouldAddProductToTheDatabase()
    {
        // arrange
        var products = GetProducts();
        var dbSet = products.AsQueryable().BuildMockDbSet();
        _databaseServiceMock.Setup(x => x.Products).Returns(dbSet.Object);
        var createProductModel = new CreateProductModel() { Name = "Product 2" };
        
        // act
        await _command.Execute(createProductModel);

        // assert
        _databaseServiceMock.Verify(x => x.Products, Times.Once);
        _databaseServiceMock.Verify(x => x.SaveAsync(), Times.Once);
    }
    
    private IEnumerable<Product> GetProducts()
    {
        return new List<Product>()
        {
            new()
            {
                Id = 1,
                Name = "Product 1",
                Price = 1m
            }
        };
    }
}