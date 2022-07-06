using Domain.Common;
using Domain.Customers;
using Domain.Employees;
using Domain.Products;
using Domain.SalesProducts;

namespace Domain.Sales;

public class Sale : IEntity
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
    
    private List<SaleProduct> _saleProducts;
    public List<SaleProduct> SaleProducts
    {
        get => _saleProducts;
        set
        {
            _saleProducts = value;
            
            CalculateTotalPrice();
            CalculateTotalItems();
        }
    }
    
    public DateTime CreatedDate { get; set; }

    public int TotalItems { get; set; }
    public decimal TotalPrice { get; set; }

    private void CalculateTotalPrice()
    {
        TotalPrice = SaleProducts
            .Sum(saleProduct => saleProduct.Quantity * saleProduct.Product.Price); 
    }

    private void CalculateTotalItems()
    {
        TotalItems = SaleProducts.Sum(saleProducts => saleProducts.Quantity);
    }
    
    public List<Product> GetProducts()
    {
        return SaleProducts
            .Select(sp => sp.Product)
            .ToList();
    }
}