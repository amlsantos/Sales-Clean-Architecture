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
        
        builder.Property(s => s.CreatedDate).IsRequired();
        builder.Property(s => s.TotalPrice).IsRequired().HasPrecision(5, 2);
        builder.Property(s => s.CustomerId).IsRequired();
        builder.Property(s => s.EmployeeId).IsRequired();

        builder.HasOne(s => s.Customer)
            .WithMany(c => c.Sales)
            .HasForeignKey(s => s.CustomerId);
        
        builder.HasOne(s => s.Employee)
            .WithMany(c => c.Sales)
            .HasForeignKey(s => s.EmployeeId);
        
        builder.HasData(DatabaseInitializer.Sales);
    }
}