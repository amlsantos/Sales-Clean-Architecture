namespace Application.Sales.Queries.GetSalesList;

public interface IGetSalesListQuery
{
    Task<List<SalesListItemModel>> Execute();
}