using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class VehicleTypeConfiguration : IEntityTypeConfiguration<VehicleType>
    {
        public void Configure(EntityTypeBuilder<VehicleType> builder)
        {
            builder.Property(vt => vt.Id).IsRequired();
            builder.Property(vt => vt.VehicleTypeName).IsRequired().HasMaxLength(50);

            builder.HasMany(i => i.Vehicles).WithOne(c => c.VehicleType)
                .HasForeignKey(i => i.VehicleTypeId);
        }
    }
}