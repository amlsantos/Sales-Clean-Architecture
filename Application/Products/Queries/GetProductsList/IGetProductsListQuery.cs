namespace Application.Products.Queries.GetProductsList;

public interface IGetProductsListQuery
{
    Task<List<ProductListModel>> Execute();
}