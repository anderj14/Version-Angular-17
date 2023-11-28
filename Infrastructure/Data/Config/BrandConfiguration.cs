

using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(b => b.Id).IsRequired();
            builder.Property(b => b.BrandName).IsRequired().HasMaxLength(100);

            builder.HasMany(i => i.Models).WithOne(c => c.Brand)
                .HasForeignKey(i => i.BrandId);

            builder.HasMany(i => i.Vehicles).WithOne(c => c.Brand)
                .HasForeignKey(i => i.BrandId);
        }
    }
}