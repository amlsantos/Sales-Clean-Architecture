using Application.Interfaces;
using Application.Interfaces.Persistence;
using Domain.Employees;

namespace Application.Employees.Commands.CreateEmployee;

public class CreateEmployeeCommand : ICreateEmployeeCommand
{
    private readonly IEmployeeRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateEmployeeCommand(IEmployeeRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(CreateEmployeeModel model)
    {
        var employee = new Employee()
        {
            Name = model.Name
        };

        await _repository.AddAsync(employee);
        await _unitOfWork.SaveAsync();
    }
}