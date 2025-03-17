using AlibabaClone.Domain.Aggregates.AccountAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlibabaClone.Infrastructure.Configurations
{
    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.HasKey(g => g.Id);
            builder.Property(g => g.Id)
                .ValueGeneratedOnAdd();

            builder.Property(g => g.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(g => g.Title)
                .IsUnique();
        }
    }
}
