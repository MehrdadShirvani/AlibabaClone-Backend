using AlibabaClone.Domain.Aggregates.VehicleAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlibabaClone.Infrastructure.Configurations
{
    public class SeatConfiguration : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.VehicleId)
                .IsRequired();

            builder.Property(s => s.Row)
                .IsRequired();

            builder.Property(s => s.Column)
                .IsRequired();

            builder.Property(s => s.IsVIP)
                .IsRequired();

            builder.Property(s => s.IsAvailable)
                .IsRequired();

            builder.Property(s => s.Description)
                .HasMaxLength(200);

            builder.HasOne(s => s.Vehicle)
                .WithMany(v => v.Seats)
                .HasForeignKey(s => s.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}