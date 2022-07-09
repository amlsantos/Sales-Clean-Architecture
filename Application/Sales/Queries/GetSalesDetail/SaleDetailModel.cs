namespace Application.Sales.Queries.GetSalesDetail;

public class SaleDetailModel
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; }
    public List<ProductDetailModel> ProductDetails { get; set; }
    public int TotalQuantity { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime Date { get; set; }
}

public class ProductDetailModel
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
}