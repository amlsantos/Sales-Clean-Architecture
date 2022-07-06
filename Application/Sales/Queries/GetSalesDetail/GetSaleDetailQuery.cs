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

    public SaleDetailModel Execute(int id)
    {
        var sale = _database.Sales
            .Include(s => s.Customer)
            .Include(s => s.Employee)
            .Include(s => s.SaleProducts)
            .Where(s => s.Id == id)
            .Select(s => new SaleDetailModel()
            {
                Id = s.Id,
                Date = s.CreatedDate,
                CustomerId = s.Customer.Id,
                CustomerName = s.Customer.Name,
                EmployeeId = s.Employee.Id,
                EmployeeName = s.Employee.Name,
                ProductDetails = s.SaleProducts.Select(sp => new ProductDetailModel()
                    { ProductId = sp.Product.Id, ProductName = sp.Product.Name, Quantity = sp.Quantity }).ToList(),
                TotalQuantity = s.SaleProducts.Sum(sp => sp.Quantity),
                TotalPrice = s.SaleProducts.Sum(sp => sp.Product.Price),
            })
            .Single();

        return sale;
    }
}