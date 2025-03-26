using AlibabaClone.Domain.Aggregates.TransportationAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlibabaClone.Infrastructure.Configurations.TransportationAggregates
{
    public class TransportationConfiguration : IEntityTypeConfiguration<Transportation>
    {
        public void Configure(EntityTypeBuilder<Transportation> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.FromLocationId)
                .IsRequired();

            builder.Property(t => t.ToLocationId)
                .IsRequired();

            builder.Property(t => t.CompanyId)
                .IsRequired();

            builder.Property(t => t.VehicleId)
                .IsRequired();

            builder.Property(t => t.StartDateTime)
                .IsRequired();

            builder.Property(t => t.EndDateTime)
                .IsRequired();

            builder.Property(t => t.SerialNumber)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(t => t.RemainingCapacity)
                .IsRequired();

            builder.Property(t => t.BasePrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(t => t.VIPPrice)
                .HasColumnType("decimal(18,2)");

            //Relationships
            builder.HasOne(t => t.FromLocation)
                .WithMany()
                .HasForeignKey(t => t.FromLocationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.ToLocation)
                .WithMany()
                .HasForeignKey(t => t.ToLocationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Company)
                .WithMany(c => c.Transportations)
                .HasForeignKey(t => t.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Vehicle)
                .WithMany(v => v.Transportations)
                .HasForeignKey(t => t.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
