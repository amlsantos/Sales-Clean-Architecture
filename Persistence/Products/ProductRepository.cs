using Application.Interfaces.Persistence;
using Domain.Products;
using Persistence.Database;

namespace Persistence.Products;

public class ProductRepository: Repository<Product>, IProductRepository
{
    public ProductRepository(IDatabaseContext context) : base(context.Products) { }
}