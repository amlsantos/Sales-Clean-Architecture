using Application.Interfaces;

namespace Application.Products.Queries.GetProductsList;

public class GetProductsListQuery : IGetProductsListQuery
{
    private readonly IDatabaseService _database;

    public GetProductsListQuery(IDatabaseService database)
    {
        _database = database;
    }

    public List<ProductListModel> Execute()
    {
        var products = _database.Products.Select(p => new ProductListModel
            {
                Id = p.Id, 
                Name = p.Name,
                UnitPrice = p.Price
            });

        return products.ToList();
    }
}