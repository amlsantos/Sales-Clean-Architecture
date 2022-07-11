using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Sales.Queries.GetSalesList;

public class GetSalesListQuery : IGetSalesListQuery
{
    private readonly IDatabaseService _database;

    public GetSalesListQuery(IDatabaseService database) => _database = database;

    public async Task<List<SalesListItemModel>> Execute()
    {
        var sales = await _database.Sales.GetAll();
        var projectedSales = await sales.Include(s => s.Customer)
            .Include(s => s.Employee)
            .Include(s => s.SaleProducts)
            .ThenInclude(s => s.Product)
            .ToListAsync();

        return (from sale in projectedSales
            let products = sale.SaleProducts.Select(s => s.Product.Name).ToList()
            let totalPrice = sale.SaleProducts.Sum(s => s.Product.Price)
            select new SalesListItemModel()
            {
                Id = sale.Id,
                Date = sale.CreatedDate,
                CustomerName = sale.Customer.Name,
                EmployeeName = sale.Employee.Name,
                Products = products,
                TotalPrice = totalPrice
            }).ToList();
    }
}