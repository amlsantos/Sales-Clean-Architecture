namespace Application.Sales.Queries.GetSalesList;

public class SalesListItemModel
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public string EmployeeName { get; set; }
    public List<string> Products { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime Date { get; set; }
}