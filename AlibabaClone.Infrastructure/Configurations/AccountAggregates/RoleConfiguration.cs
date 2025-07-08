using AlibabaClone.Domain.Aggregates.AccountAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlibabaClone.Infrastructure.Configurations.AccountAggregates
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id)
                .ValueGeneratedOnAdd();

            builder.Property(r => r.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(r => r.Title)
                .IsUnique();

            //Seed Data
            builder.HasData(
                new Role { Id = 1, Title = "User" },
                new Role { Id = 2, Title = "Admin" }
            );
        }
    }
}
