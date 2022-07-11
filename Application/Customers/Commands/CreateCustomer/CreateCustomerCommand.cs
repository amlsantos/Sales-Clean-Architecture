using Application.Interfaces.Persistence;
using Domain.Customers;

namespace Application.Customers.Commands.CreateCustomer;

public class CreateCustomerCommand : ICreateCustomerCommand
{
    private readonly ICustomerRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCustomerCommand(ICustomerRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(CreateCustomerModel model)
    {
        var customer = new Customer()
        {
            Name = model.Name
        };

        await _repository.AddAsync(customer);
        await _unitOfWork.SaveAsync();
    }
}