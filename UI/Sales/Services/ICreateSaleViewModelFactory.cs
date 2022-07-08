using UI.Sales.Models;

namespace UI.Sales.Services;

public interface ICreateSaleViewModelFactory
{
    CreateSaleViewModel Create();
}