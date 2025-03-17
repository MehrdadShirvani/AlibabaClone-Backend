using AlibabaClone.Domain.Aggregates.AccountAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlibabaClone.Infrastructure.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd();

            builder.Property(a => a.PhoneNumber)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(a => a.Password)
                .IsRequired()
                .HasColumnType("char(64)");

            builder.Property(a => a.Email)
                .HasColumnType("varchar(255)");

            // Relationships
            builder.HasOne(a => a.Person)
                .WithMany(p => p.Accounts)
                .HasForeignKey(a => a.PersonId)
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}