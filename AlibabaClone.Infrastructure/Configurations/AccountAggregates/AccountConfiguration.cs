using AlibabaClone.Domain.Aggregates.AccountAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlibabaClone.Infrastructure.Configurations.AccountAggregates
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
                .IsUnicode(false)
                .HasMaxLength(20);

            builder.Property(a => a.Password)
                .IsRequired()
                .IsUnicode(false)
                .IsFixedLength(true)
                .HasMaxLength(64);

            builder.Property(a => a.Email)
                .IsUnicode(false)
                .HasMaxLength(255);

            // Relationships
            builder.HasOne(a => a.Person)
                .WithMany(p => p.Accounts)
                .HasForeignKey(a => a.PersonId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}