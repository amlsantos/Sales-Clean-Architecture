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
            .Include(s => s.Product)
            .Where(s => s.Id == id)
            .Select(s => new SaleDetailModel()
            {
                Id = s.Id,
                Date = s.Date,
                CustomerId = s.Customer.Id,
                CustomerName = s.Customer.Name,
                EmployeeId = s.Employee.Id,
                EmployeeName = s.Employee.Name,
                ProductId = s.Product.Id,
                ProductName = s.Product.Name,
                UnitPrice = s.UnitPrice,
                Quantity = s.Quantity,
                TotalPrice = s.TotalPrice
            })
            .Single();

        return sale;
    }
}