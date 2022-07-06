namespace Application.Sales.Commands.CreateSale;

public class CreateSaleModel
{
    public int CustomerId { get; set; }
    public int EmployeeId { get; set; }
    public List<ProductModel> Products { get; set; }
}

public sealed class ProductModel
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}