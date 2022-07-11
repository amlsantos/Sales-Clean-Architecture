using Application.Interfaces.Persistence;
using Domain.Sales;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;

namespace Persistence.Sales;

public class SaleRepository : Repository<Sale>, ISaleRepository
{
    public SaleRepository(IDatabaseContext context) : base(context.Sales) { }
}