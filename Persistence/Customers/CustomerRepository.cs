using Application.Interfaces.Persistence;
using Domain.Customers;
using Persistence.Database;

namespace Persistence.Customers;

public class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    public CustomerRepository(IDatabaseContext context) : base(context.Customers) { }
}