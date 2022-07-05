using System.Net;
using Application.Products.Commands.CreateProduct;
using Application.Products.Queries.GetProductsList;
using Microsoft.AspNetCore.Mvc;

namespace Api.Products;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IGetProductsListQuery _query;
    private readonly ICreateProductCommand _command;

    public ProductsController(IGetProductsListQuery query, ICreateProductCommand command)
    {
        _query = query;
        _command = command;
    }

    [HttpGet]
    public IEnumerable<ProductModel> Get()
    {
        return _query.Execute();
    }

    [HttpPost]
    public async Task<HttpResponseMessage> Create(CreateProductModel model)
    {
        await _command.Execute(model);
        
        return new HttpResponseMessage(HttpStatusCode.Created);
    }
}