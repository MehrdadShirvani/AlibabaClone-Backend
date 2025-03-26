using AlibabaClone.Domain.Aggregates.VehicleAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlibabaClone.Infrastructure.Configurations.VehicleAggregates
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasKey(v => v.Id);
            builder.Property(v => v.Id)
                .ValueGeneratedOnAdd();

            builder.Property(v => v.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(v => v.VehicleTypeId)
                .IsRequired();

            builder.Property(v => v.Capacity)
                .IsRequired();

            builder.Property(v => v.PlateNumber)
                .IsRequired()
                .HasMaxLength(50);
            builder.HasIndex(v => v.PlateNumber).IsUnique();


            //Relationships
            builder.HasOne(v => v.VehicleType)
                .WithMany(vt => vt.Vehicles)
                .HasForeignKey(v => v.VehicleTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
