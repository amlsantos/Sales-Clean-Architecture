using System.Data.Entity.ModelConfiguration;
using Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Database;

namespace Persistence.Products;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Price).IsRequired().HasPrecision(6, 3);
        // builder.Property(p => p.SaleId).IsRequired(false);

        // builder.HasOne(e => e.Sale)
        //     .WithOne(s => s.Product)
        //     .HasForeignKey<Product>(c => c.SaleId);

        builder.HasData(DatabaseInitializer.Products);
    }
}