
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.Property(s => s.Id).IsRequired();
            builder.Property(s => s.StatusName).IsRequired().HasMaxLength(50);

            builder.HasMany(i => i.Vehicles).WithOne(c => c.Status)
                .HasForeignKey(i => i.StatusId);
        }
    }
}