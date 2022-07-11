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
        var customers = await _database.Customers.GetAll();

        return customers.Select(p => new CustomerModel()
                {
                    Id = p.Id,
                    Name = p.Name
                }
            ).ToList();
    }
}