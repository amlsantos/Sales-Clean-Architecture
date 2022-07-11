using Application.Interfaces.Persistence;
using Domain.Sales;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;

namespace Persistence.Sales;

public class SaleRepository : Repository<Sale>, ISaleRepository
{
    public SaleRepository(IDatabaseContext context) : base(context.Sales) { }

    public override async Task<Sale> Get(int id)
    {
        return await DbSet
            .Include(s => s.Customer)
            .Include(s => s.Employee)
            .Include(s => s.SaleProducts)
            .ThenInclude(sp => sp.Product)
            .FirstOrDefaultAsync(s => s.Id == id);
    }
}