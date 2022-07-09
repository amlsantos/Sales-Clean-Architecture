namespace Application.Customers.Queries.GetCustomerList;

public interface IGetCustomersListQuery
{
    Task<List<CustomerModel>> Execute();
}