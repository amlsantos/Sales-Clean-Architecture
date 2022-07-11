using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Sales.Queries.GetSalesDetail;

public class GetSaleDetailQuery : IGetSaleDetailQuery
{
    private readonly IDatabaseService _database;

    public GetSaleDetailQuery(IDatabaseService database)
    {
        _database = database;
    }

    public async Task<SaleDetailModel> Execute(int id)
    {
        // var sales = await _database.Sales.GetAll();
        //     var projectedSales = await sales.Include(s => s.Customer)
        //     .Include(s => s.Employee)
        //     .Include(s => s.SaleProducts)
        //     .ThenInclude(s => s.Product)
        //     .ToListAsync();
        var sale = await _database.Sales.Get(id);

        return new SaleDetailModel()
        {
            Id = sale.Id,
            Date = sale.CreatedDate,
            CustomerId = sale.Customer.Id,
            CustomerName = sale.Customer.Name,
            EmployeeId = sale.Employee.Id,
            EmployeeName = sale.Employee.Name,
            ProductDetails = sale.SaleProducts.Select(sp => new ProductDetailModel()
            {
                ProductId = sp.Product.Id,
                ProductName = sp.Product.Name,
                Quantity = sp.Quantity
            }).ToList(),
            TotalQuantity = sale.SaleProducts.Sum(sp => sp.Quantity),
            TotalPrice = sale.SaleProducts.Sum(sp => sp.Product.Price),
        };
    }
}