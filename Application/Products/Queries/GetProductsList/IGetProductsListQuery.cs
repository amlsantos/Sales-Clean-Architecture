namespace Application.Products.Queries.GetProductsList;

public interface IGetProductsListQuery
{
    List<ProductModel> Execute();
}