namespace Application.Customers.Commands.CreateCustomer;

public interface ICreateCustomerCommand
{
    Task Execute(CreateCustomerModel model);
}