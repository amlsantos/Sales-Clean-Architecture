using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Products.Queries.GetProductsList;

public class GetProductsListQuery : IGetProductsListQuery
{
    private readonly IDatabaseService _database;

    public GetProductsListQuery(IDatabaseService database)
    {
        _database = database;
    }

    public async Task<List<ProductListModel>> Execute()
    {
        var products = _database.Products.Select(p => new ProductListModel
            {
                Id = p.Id, 
                Name = p.Name,
                UnitPrice = p.Price
            });

        return await products.ToListAsync();
    }
}