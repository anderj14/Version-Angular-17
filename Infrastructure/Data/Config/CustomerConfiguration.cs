using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c => c.Id).IsRequired();
            builder.Property(c => c.CustomerName).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(70);
            builder.Property(c => c.Phone).IsRequired();
            builder.Property(c => c.DriverLicense).IsRequired();
            builder.Property(c => c.Address).IsRequired();

            builder.HasMany(i => i.Reservations).WithOne(c => c.Customer)
                .HasForeignKey(i => i.CustomerId);

            builder.HasMany(i => i.Invoices).WithOne(c => c.Customer)
                .HasForeignKey(i => i.CustomerId);
        }
    }
}