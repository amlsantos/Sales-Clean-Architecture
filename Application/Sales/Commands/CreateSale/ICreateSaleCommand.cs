namespace Application.Sales.Commands.CreateSale;

public interface ICreateSaleCommand
{
    Task Execute(CreateSaleModel model);
}