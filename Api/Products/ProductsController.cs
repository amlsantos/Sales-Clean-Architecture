using Application.Products.Queries.GetProductsList;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IGetProductsListQuery _query;

    public ProductsController(IGetProductsListQuery query) => _query = query;

    [HttpGet]
    public IEnumerable<ProductModel> Get()
    {
        return _query.Execute();
    }
}