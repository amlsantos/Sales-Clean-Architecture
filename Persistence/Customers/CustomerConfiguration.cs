using Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Database;

namespace Persistence.Customers;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.Name).IsRequired().HasMaxLength(50);
        // builder.Property(c => c.SaleId).IsRequired(false);

        // builder.HasOne(c => c.Sale)
        //     .WithOne(s => s.Customer)
        //     .HasForeignKey<Customer>(c => c.SaleId);
        
        builder.HasData(DatabaseInitializer.Customers);
    }
}