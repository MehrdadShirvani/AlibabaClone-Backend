using AlibabaClone.Domain.Aggregates.TransportationAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlibabaClone.Infrastructure.Configurations.TransportationAggregates
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.TransportationId)
                .IsRequired();

            builder.Property(t => t.SeatId)
                .IsRequired();

            builder.Property(t => t.BuyerId)
                .IsRequired();

            builder.Property(t => t.TravelerId)
                .IsRequired();

            builder.Property(t => t.CreatedAt)
                .IsRequired();

            builder.Property(t => t.CompanionId)
                .IsRequired(false);

            builder.Property(t => t.TicketStatusId)
                .IsRequired();

            builder.Property(t => t.SerialNumber)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(t => t.Description)
                .HasMaxLength(200)
                .IsUnicode(false);

            // Relationships
            builder.HasOne(t => t.Transportation)
                .WithMany(t => t.Tickets)
                .HasForeignKey(t => t.TransportationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Seat)
                .WithMany(s => s.Tickets)
                .HasForeignKey(t => t.SeatId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Buyer)
                .WithMany(a => a.BoughtTickets)
                .HasForeignKey(t => t.BuyerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Traveler)
                .WithMany(p => p.TraveledTickets)
                .HasForeignKey(t => t.TravelerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Companion)
                .WithMany()
                .HasForeignKey(t => t.CompanionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.TicketStatus)
                .WithMany()
                .HasForeignKey(t => t.TicketStatusId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}