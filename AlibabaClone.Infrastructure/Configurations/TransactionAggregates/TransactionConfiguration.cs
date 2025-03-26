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

            builder.Property(t => t.TicketId)
                .IsRequired();

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

            // Relationships
            builder.HasOne(t => t.Ticket)
                .WithMany()
                .HasForeignKey(t => t.TicketId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
