using Application.Interfaces;
using Application.Interfaces.Persistence;
using Domain.Products;

namespace Application.Products.Commands.CreateProduct;

public class CreateProductCommand : ICreateProductCommand
{
    private readonly IProductRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductCommand(IProductRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(CreateProductModel model)
    {
        var product = new Product()
        {
            Name = model.Name,
            Price = model.Price
        };

        await _repository.AddAsync(product);
        await _unitOfWork.SaveAsync();
    }
}