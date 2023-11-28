using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.Property(v => v.Id).IsRequired();
            builder.Property(v => v.VehicleName).IsRequired().HasMaxLength(100);
            builder.Property(v => v.Year).IsRequired();
            builder.Property(v => v.Vin).IsRequired();
            builder.Property(v => v.Color).IsRequired();
            builder.Property(v => v.Passengers).IsRequired();
            builder.Property(v => v.Doors).IsRequired();
            builder.Property(v => v.FuelConsumption).IsRequired();
            builder.Property(v => v.RentalPrice).IsRequired().HasColumnType("decimal(18,2)");;

            builder.HasOne(i => i.Brand).WithMany(c => c.Vehicles)
                .HasForeignKey(i => i.BrandId);
            builder.HasOne(i => i.Model).WithMany(c => c.Vehicles)
                .HasForeignKey(i => i.ModelId);
            builder.HasOne(i => i.Status).WithMany(c => c.Vehicles)
                .HasForeignKey(i => i.StatusId);
            
            builder.HasOne(i => i.VehicleType).WithMany(c => c.Vehicles)
                .HasForeignKey(i => i.VehicleTypeId);

            builder.HasMany(i => i.Reservations).WithOne(c => c.Vehicle)
                .HasForeignKey(r => r.VehicleId);
        }
    }
}