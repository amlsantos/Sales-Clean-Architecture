using Domain.Common;
using Domain.Sales;

namespace Domain.Customers;

public class Customer : IEntity
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    public Sale Sale { get; set; }
}