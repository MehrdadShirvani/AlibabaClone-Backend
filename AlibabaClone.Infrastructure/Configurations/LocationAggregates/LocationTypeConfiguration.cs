using AlibabaClone.Domain.Aggregates.LocationAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlibabaClone.Infrastructure.Configurations.LocationAggregates
{
    public class LocationTypeConfiguration : IEntityTypeConfiguration<LocationType>
    {
        public void Configure(EntityTypeBuilder<LocationType> builder)
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
