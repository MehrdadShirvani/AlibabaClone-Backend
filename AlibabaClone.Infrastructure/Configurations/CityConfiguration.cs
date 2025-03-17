using AlibabaClone.Domain.Aggregates.LocationAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlibabaClone.Infrastructure.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(c => c.Title)
                .IsUnique();
        }
    }
}
