using Application.Interfaces;
using Application.Sales.Commands.CreateSale.Factory;
using Common.Dates;
using Domain.Customers;
using Domain.Employees;
using Domain.Products;
using Domain.Sales;
using Domain.SalesProducts;
using MockQueryable.Moq;
using Moq;
using Xunit;

namespace Application.Sales.Commands.CreateSale;

public class CreateSaleCommandTests
{
    private readonly Mock<IDatabaseService> _databaseServiceMock;
    private readonly Mock<IDateService> _dateServiceMock;
    private readonly Mock<ISaleFactory> _saleFactoryMock;
    private readonly Mock<IInventoryService> _inventoryServiceMock;
    private readonly CreateSaleCommand _command;

    public CreateSaleCommandTests()
    {
        _dateServiceMock = new Mock<IDateService>();
        _databaseServiceMock = new Mock<IDatabaseService>();
        _saleFactoryMock = new Mock<ISaleFactory>();
        _inventoryServiceMock = new Mock<IInventoryService>();
        _command = new CreateSaleCommand(_dateServiceMock.Object, _databaseServiceMock.Object, _saleFactoryMock.Object,
            _inventoryServiceMock.Object);
    }

    [Fact]
    public async Task TestExecuteShouldAddSaleToTheDatabase()
    {
        // arrange
        SetUpDateService();
        SetUpDbSets();
        SetUpSaleFactory();

        var model = new CreateSaleModel()
        {
            CustomerId = 1,
            EmployeeId = 1,
            Products = new()
            {
                new ProductModel()
                {
                    ProductId = 1,
                    Quantity = 2
                },
                new ProductModel()
                {
                    ProductId = 2,
                    Quantity = 3
                }
            }
        };

        // act
        await _command.Execute(model);

        // assert
        _dateServiceMock.Verify(x => x.GetDate(), Times.Once);
        _databaseServiceMock.Verify(x => x.Customers, Times.Once);
        _databaseServiceMock.Verify(x => x.Employees, Times.Once);
        _databaseServiceMock.Verify(x => x.Products, Times.Once);
        _saleFactoryMock.Verify(x =>
            x.Create(It.IsAny<DateTime>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<List<SaleProduct>>()), Times.Once);
        _databaseServiceMock.Verify(x => x.Sales, Times.Once);
        _databaseServiceMock.Verify(x => x.SaveAsync(), Times.Once);
        _inventoryServiceMock.Verify(x => x.NotifySaleOcurred(It.IsAny<int>(), It.IsAny<int>()), Times.Exactly(2));
    }

    private void SetUpDateService()
    {
        _dateServiceMock.Setup(x => x.GetDate()).Returns(new DateTime(2022, 07, 28));
    }

    private void SetUpDbSets()
    {
        var customersDbSet = GetCustomers().AsQueryable().BuildMockDbSet();
        var employeesDbSet = GetEmployees().AsQueryable().BuildMockDbSet();
        var productsDbSet = GetProducts().AsQueryable().BuildMockDbSet();
        var salesDbSet = GetSales().AsQueryable().BuildMockDbSet();

        _databaseServiceMock.Setup(x => x.Customers).Returns(customersDbSet.Object);
        _databaseServiceMock.Setup(x => x.Employees).Returns(employeesDbSet.Object);
        _databaseServiceMock.Setup(x => x.Products).Returns(productsDbSet.Object);
        _databaseServiceMock.Setup(x => x.Sales).Returns(salesDbSet.Object);
    }

    private void SetUpSaleFactory()
    {
        var sale = new Sale()
        {
            Id = 1,
            CustomerId = 1,
            EmployeeId = 1,
            SaleProducts = new List<SaleProduct>()
            {
                new()
                {
                    Id = 1,
                    Quantity = 2,
                    ProductId = 1,
                    Product = new Product()
                    {
                        Id = 1, 
                        Name = "Product 1", 
                        Price = 10m
                    }
                }, 
                new()
                {
                    Id = 2,
                    Quantity = 3,
                    ProductId = 2,
                    Product = new Product()
                    {
                        Id = 2, 
                        Name = "Product 2", 
                        Price = 10m
                    }
                }
            }
        };

        _saleFactoryMock.Setup(x => x.Create(
            It.IsAny<DateTime>(),
            It.IsAny<int>(),
            It.IsAny<int>(),
            It.IsAny<List<SaleProduct>>())).Returns(sale);
    }

    private IEnumerable<Customer> GetCustomers()
    {
        return new List<Customer>()
        {
            new()
            {
                Id = 1,
                Name = "Customer 1"
            }
        };
    }

    private IEnumerable<Employee> GetEmployees()
    {
        return new List<Employee>()
        {
            new()
            {
                Id = 1,
                Name = "Employee 1"
            }
        };
    }

    private IEnumerable<Product> GetProducts()
    {
        return new List<Product>()
        {
            new()
            {
                Id = 1,
                Name = "Product 1",
                Price = 10m
            },
            new ()
            {
                Id = 2, 
                Name = "Product 2", 
                Price = 10m
            }
        };
    }

    private IEnumerable<Sale> GetSales()
    {
        return new List<Sale>()
        {
            new()
            {
                Id = 1,
                Customer = new()
                {
                    Name = "Customer 1"
                },
                Employee = new()
                {
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