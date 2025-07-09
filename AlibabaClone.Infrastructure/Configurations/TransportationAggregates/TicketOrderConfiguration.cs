using AlibabaClone.Domain.Aggregates.TransportationAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlibabaClone.Infrastructure.Configurations.TransportationAggregates
{
    public class TicketOrderConfiguration : IEntityTypeConfiguration<TicketOrder>
    {
        public void Configure(EntityTypeBuilder<TicketOrder> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd();

            builder.Property(t => t.TransportationId)
                .IsRequired();


            builder.Property(t => t.BuyerId)
                .IsRequired();

            
            builder.Property(t => t.CreatedAt)
                .IsRequired();

            builder.Property(t => t.SerialNumber)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.HasIndex(t => t.Id).IsUnique();

            builder.Property(t => t.Description)
                .HasMaxLength(200)
                .IsUnicode(false);

            // Relationships
            builder.HasOne(t => t.Transportation)
                .WithMany(t => t.TicketOrders)
                .HasForeignKey(t => t.TransportationId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(t => t.Buyer)
                .WithMany(a => a.BoughtTicketOrders)
                .HasForeignKey(t => t.BuyerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
