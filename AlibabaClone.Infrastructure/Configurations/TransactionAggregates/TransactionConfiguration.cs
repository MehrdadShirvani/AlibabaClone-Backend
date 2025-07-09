using AlibabaClone.Domain.Aggregates.TransactionAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlibabaClone.Infrastructure.Configurations.TransactionAggregates
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd();

            builder.Property(t => t.TransactionTypeId)
                .IsRequired(true);

            builder.Property(t => t.AccountId)
                .IsRequired(true);

            builder.Property(t => t.TicketOrderId)
                .IsRequired(false);

            builder.Property(t => t.BaseAmount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(t => t.FinalAmount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(t => t.SerialNumber)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(t => t.CreatedAt)
                .IsRequired();

            builder.Property(t => t.CouponId)
                .IsRequired(false);

            builder.Property(s => s.Description)
                .IsRequired(false)
                .HasMaxLength(200);

            // Relationships
            builder.HasOne(t => t.TicketOrder)
                .WithOne(t => t.Transaction)
                .HasForeignKey<Transaction>(t => t.TicketOrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Account)
               .WithMany(a => a.Transactions)
               .HasForeignKey(t => t.AccountId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Coupon)
                .WithMany(c => c.Transactions)
                .HasForeignKey(t => t.CouponId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.TransactionType)
                .WithMany()
                .HasForeignKey(t => t.TransactionTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
