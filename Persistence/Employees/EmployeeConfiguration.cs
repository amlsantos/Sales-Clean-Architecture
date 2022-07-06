using System.Data.Entity.ModelConfiguration;
using Domain.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Database;

namespace Persistence.Employees;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).IsRequired().HasMaxLength(50);

        builder.HasMany(e => e.Sales)
            .WithOne(s => s.Employee)
            .HasForeignKey(s => s.EmployeeId);
        
        builder.HasData(DatabaseInitializer.Employees);
    }
}