namespace Application.Products.Commands.CreateProduct;

public interface ICreateProductCommand
{
    Task Execute(CreateProductModel model);
}