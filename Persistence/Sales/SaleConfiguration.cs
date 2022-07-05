using Domain.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Database;

namespace Persistence.Sales;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.HasKey(s => s.Id);
        
        builder.Property(s => s.Date).IsRequired();
        builder.Property(s => s.TotalPrice).IsRequired().HasPrecision(5, 2);
        builder.Property(s => s.CustomerId).IsRequired();
        builder.Property(s => s.EmployeeId).IsRequired();
        builder.Property(s => s.ProductId).IsRequired();

        builder.HasOne(s => s.Customer)
            .WithOne(c => c.Sale)
            .HasForeignKey<Sale>(s => s.CustomerId);
        
        builder.HasOne(s => s.Employee)
            .WithOne(e => e.Sale)
            .HasForeignKey<Sale>(e => e.EmployeeId);

        builder.HasOne(s => s.Product)
            .WithOne(e => e.Sale)
            .HasForeignKey<Sale>(e => e.ProductId);
        
        builder.HasData(DatabaseInitializer.Sales);
    }
}