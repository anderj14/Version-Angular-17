
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class InsuranceConfiguration : IEntityTypeConfiguration<Insurance>
    {
        public void Configure(EntityTypeBuilder<Insurance> builder)
        {
            builder.Property(i => i.Id).IsRequired();
            builder.Property(i => i.InsuranceName).IsRequired();
            builder.Property(i => i.InsurancePrice).IsRequired().HasColumnType("decimal(18,2)");

            builder.HasMany(i => i.Reservations).WithOne(c => c.Insurance)
                .HasForeignKey(i => i.InsuranceId);
        }
    }
}