namespace Application.Sales.Queries.GetSalesList;

public interface IGetSalesListQuery
{
    List<SalesListItemModel> Execute();
}