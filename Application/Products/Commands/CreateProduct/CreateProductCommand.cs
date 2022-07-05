using Application.Interfaces;
using Domain.Products;

namespace Application.Products.Commands.CreateProduct;

public class CreateProductCommand : ICreateProductCommand
{
    private readonly IDatabaseService _database;

    public CreateProductCommand(IDatabaseService database) => _database = database;

    public async Task Execute(CreateProductModel model)
    {
        var product = new Product()
        {
            Name = model.Name,
            Price = model.Price
        };

        _database.Products.Add(product);
        await _database.Save();
    }
}