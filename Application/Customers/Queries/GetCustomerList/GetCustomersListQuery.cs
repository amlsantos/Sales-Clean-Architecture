using Application.Interfaces;
using Application.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Customers.Queries.GetCustomerList;

public class GetCustomersListQuery : IGetCustomersListQuery
{
    private readonly ICustomerRepository _repository;

    public GetCustomersListQuery(ICustomerRepository repository) => _repository = repository;

    public async Task<List<CustomerModel>> Execute()
    {
        var customers = await _repository.GetAll();

        return customers.Select(p => new CustomerModel()
                {
                    Id = p.Id,
                    Name = p.Name
                }
            ).ToList();
    }
}