using Domain.Common;
using Domain.Products;
using Domain.Sales;

namespace Domain.SalesProducts;

public class SaleProduct : IEntity
{
    public int Id { get; set; }
    public int SaleId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { set; get; }
    
    public Sale Sale { get; set; }
    public Product Product { get; set; }
}