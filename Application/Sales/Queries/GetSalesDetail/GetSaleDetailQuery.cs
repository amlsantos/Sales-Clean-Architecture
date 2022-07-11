using Application.Interfaces.Persistence;

namespace Application.Sales.Queries.GetSalesDetail;

public class GetSaleDetailQuery : IGetSaleDetailQuery
{
    private readonly ISaleRepository _repository;

    public GetSaleDetailQuery(ISaleRepository repository) => _repository = repository;

    public async Task<SaleDetailModel> Execute(int id)
    {
        var sale = await _repository.Get(id);

        return new SaleDetailModel()
        {
            Id = sale.Id,
            Date = sale.CreatedDate,
            CustomerId = sale.Customer.Id,
            CustomerName = sale.Customer.Name,
            EmployeeId = sale.Employee.Id,
            EmployeeName = sale.Employee.Name,
            ProductDetails = sale.SaleProducts.Select(sp => new ProductDetailModel()
            {
                ProductId = sp.Product.Id,
                ProductName = sp.Product.Name,
                Quantity = sp.Quantity
            }).ToList(),
            TotalQuantity = sale.SaleProducts.Sum(sp => sp.Quantity),
            TotalPrice = sale.SaleProducts.Sum(sp => sp.Product.Price),
        };
    }
}