using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Sales.Queries.GetSalesList;

public class GetSalesListQuery : IGetSalesListQuery
{
    private readonly IDatabaseService _database;

    public GetSalesListQuery(IDatabaseService database) => _database = database;

    public async Task<List<SalesListItemModel>> Execute()
    {
        var sales = _database
            .Sales
            .GetAll()
            .Include(s => s.Customer)
            .Include(s => s.Employee)
            .Include(s => s.SaleProducts)
            .Select(s => new SalesListItemModel()
            {
                Id = s.Id,
                Date = s.CreatedDate,
                CustomerName = s.Customer.Name,
                EmployeeName = s.Employee.Name,
                Products = s.SaleProducts.Select(s => s.Product.Name).ToList(),
                TotalPrice = s.SaleProducts.Sum(s => s.Product.Price)
            });

        return await sales.ToListAsync();
    }
}