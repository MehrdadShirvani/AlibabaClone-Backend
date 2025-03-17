using AlibabaClone.Domain.Aggregates.AccountAggregates;
using AlibabaClone.Domain.Aggregates.LocationAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlibabaClone.Infrastructure.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Id)
                .ValueGeneratedOnAdd();

            builder.Property(l => l.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(l => l.CityId)
                .IsRequired();

            builder.Property(l => l.LocationTypeId)
                .IsRequired();

            //Relationships
            builder.HasOne(l => l.City)
                .WithMany(c => c.Locations)
                .HasForeignKey(l => l.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(l => l.LocationType)
                .WithMany(lt => lt.Locations)
                .HasForeignKey(l => l.LocationTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
