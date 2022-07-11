using Application.Interfaces.Persistence;

namespace Application.Products.Queries.GetProductsList;

public class GetProductsListQuery : IGetProductsListQuery
{
    private readonly IProductRepository _repository;

    public GetProductsListQuery(IProductRepository repository) => _repository = repository;

    public async Task<List<ProductListModel>> Execute()
    {
        var products = await _repository.GetAll();

        return products.Select(p => new ProductListModel
        {
            Id = p.Id, 
            Name = p.Name,
            UnitPrice = p.Price
        }).ToList();
    }
}