
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class FuelConfiguration : IEntityTypeConfiguration<Fuel>
    {
        public void Configure(EntityTypeBuilder<Fuel> builder)
        {
            builder.Property(i => i.Id).IsRequired();
            builder.Property(i => i.FuelName).IsRequired().HasMaxLength(50);

            builder.HasMany(i => i.Vehicles).WithOne(c => c.Fuel)
                .HasForeignKey(i => i.FuelId);
        }
    }
}