using Application.Interfaces;
using Domain.Customers;

namespace Application.Customers.Commands.CreateCustomer;

public class CreateCustomerCommand : ICreateCustomerCommand
{
    private readonly IDatabaseService _database;

    public CreateCustomerCommand(IDatabaseService database) => _database = database;

    public async Task Execute(CreateCustomerModel model)
    {
        var customer = new Customer()
        {
            Name = model.Name
        };

        await _database.Customers.Add(customer);
        await _database.Save();
    }
}