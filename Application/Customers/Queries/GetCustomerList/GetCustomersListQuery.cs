using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Customers.Queries.GetCustomerList;

public class GetCustomersListQuery : IGetCustomersListQuery
{
    private readonly IDatabaseService _database;

    public GetCustomersListQuery(IDatabaseService database)
    {
        _database = database;
    }

    public async Task<List<CustomerModel>> Execute()
    {
        var customers = _database
            .Customers
            .GetAll()
            .Select(p => new CustomerModel()
            {
                Id = p.Id, 
                Name = p.Name
            }
        );

        return await customers.ToListAsync();
    }
}