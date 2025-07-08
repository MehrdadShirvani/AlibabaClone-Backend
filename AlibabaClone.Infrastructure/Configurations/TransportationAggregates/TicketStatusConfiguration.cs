using AlibabaClone.Domain.Aggregates.TransportationAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlibabaClone.Infrastructure.Configurations.TransportationAggregates
{
    public class TicketStatusConfiguration : IEntityTypeConfiguration<TicketStatus>
    {
        public void Configure(EntityTypeBuilder<TicketStatus> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id)
                .ValueGeneratedNever();

            builder.Property(r => r.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(r => r.Title)
                .IsUnique();

            //Seed Data
            builder.HasData(
                new TicketStatus { Id = 1, Title = "Reserved"},
                new TicketStatus { Id = 2, Title = "Paid"},
                new TicketStatus { Id = 3, Title = "CancelledByUser"},
                new TicketStatus { Id = 4, Title = "CancelledBySystem"},
                new TicketStatus { Id = 5, Title = "Used"},
                new TicketStatus { Id = 6, Title = "Expired" }
            );
        }
    }
}
