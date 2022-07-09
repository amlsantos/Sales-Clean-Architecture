namespace Application.Sales.Queries.GetSalesDetail;

public interface IGetSaleDetailQuery
{
    Task<SaleDetailModel> Execute(int id);
}