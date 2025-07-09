using AlibabaClone.Domain.Aggregates.AccountAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlibabaClone.Infrastructure.Configurations.AccountAggregates
{
    public class BankAccountDetailConfiguration : IEntityTypeConfiguration<BankAccountDetail>
    {
        public void Configure(EntityTypeBuilder<BankAccountDetail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.BankName).IsRequired(false).IsUnicode(false).HasMaxLength(50);
            builder.Property(x => x.CardNumber).IsRequired(false).IsUnicode(false).HasMaxLength(16);
            builder.Property(x => x.IBAN).IsRequired(false).IsUnicode(false).HasMaxLength(24);
            builder.Property(x => x.BankAccountNumber).IsRequired(false).IsUnicode(false).HasMaxLength(50);

            builder.HasIndex(x => x.AccountId).IsUnique();
            
            // Relationships
            builder.HasOne(x => x.Account)
                   .WithOne(x=> x.BankAccountDetail)
                   .HasForeignKey<BankAccountDetail>(x => x.AccountId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
