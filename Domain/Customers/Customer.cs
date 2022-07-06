using Domain.Common;
using Domain.Sales;

namespace Domain.Customers;

public class Customer : IEntity
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    public List<Sale> Sales { get; set; }
}