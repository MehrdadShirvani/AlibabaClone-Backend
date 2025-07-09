using AlibabaClone.Domain.Aggregates.TransportationAggregates;
using AlibabaClone.Domain.Aggregates.VehicleAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace AlibabaClone.Infrastructure.Configurations.VehicleAggregates
{
    public class VehicleTypeConfiguration : IEntityTypeConfiguration<VehicleType>
    {
        public void Configure(EntityTypeBuilder<VehicleType> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(c => c.Title)
                .IsUnique();

        }
    }
}
