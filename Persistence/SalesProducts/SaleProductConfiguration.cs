using Domain.SalesProducts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Database;

namespace Persistence.SalesProducts;

public class SaleProductConfiguration : IEntityTypeConfiguration<SaleProduct>
{
    public void Configure(EntityTypeBuilder<SaleProduct> builder)
    {
        builder.HasKey(s => new { s.SaleId, s.ProductId });

        builder.HasOne(sp => sp.Product)
            .WithMany(p => p.SaleProducts)
            .HasForeignKey(p => p.ProductId);
        
        builder.HasOne(sp => sp.Sale)
            .WithMany(p => p.SaleProducts)
            .HasForeignKey(p => p.SaleId);
        
        builder.HasData(DatabaseInitializer.SalesProducts);
    }
}