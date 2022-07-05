using Domain.Common;
using Domain.Customers;
using Domain.Employees;
using Domain.Products;

namespace Domain.Sales;

public class Sale : IEntity
{
    private int _quantity;
    private decimal _totalPrice;
    private decimal _unitPrice;

    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int EmployeeId { get; set; }
    public int ProductId { get; set; }

    public Customer Customer { get; set; }
    public Employee Employee { get; set; }
    public Product Product { get; set; }
    public DateTime Date { get; set; }

    public decimal UnitPrice
    {
        get => _unitPrice;
        set
        {
            _unitPrice = value;
            UpdateTotalPrice();
        }
    }

    public int Quantity
    {
        get => _quantity;
        set
        {
            _quantity = value;
            UpdateTotalPrice();
        }
    }

    public decimal TotalPrice
    {
        get => _totalPrice;
        private set => _totalPrice = value;
    }

    private void UpdateTotalPrice()
    {
        _totalPrice = _unitPrice * _quantity;
    }
}