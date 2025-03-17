using AlibabaClone.Domain.Aggregates.AccountAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlibabaClone.Infrastructure.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasColumnType("nvarchar(50)");

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasColumnType("nvarchar(50)");

            builder.Property(p => p.IdNumber)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");
            builder.HasIndex(p => p.IdNumber).IsUnique();

            builder.Property(p => p.PassportNumber)
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder.Property(p => p.EnglishFirstName)
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder.Property(p => p.EnglishLastName)
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Birthdate)
                .HasColumnType("date");

            // Relationships
            builder.HasOne(p => p.Gender)
                .WithMany()
                .HasForeignKey(p => p.GenderId)
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
    }
}
