namespace Application.Sales.Queries.GetSalesDetail;

public interface IGetSaleDetailQuery
{
    SaleDetailModel Execute(int id);
}