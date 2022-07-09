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

        await _database.Products.AddAsync(product);
        await _database.SaveAsync();
    }
}