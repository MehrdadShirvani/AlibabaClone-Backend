using AlibabaClone.Domain.Aggregates.AccountAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlibabaClone.Infrastructure.Configurations.AccountAggregates
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
                .HasMaxLength(50);

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(50);


            builder.Property(p => p.IdNumber)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
            builder.HasIndex(p => p.IdNumber).IsUnique();

            builder.Property(p => p.PassportNumber)
                .HasMaxLength(20)
                .IsUnicode(false);


            builder.Property(a => a.PhoneNumber)
                 .IsRequired(false)
                 .IsUnicode(false)
                 .HasMaxLength(20);

            builder.Property(p => p.EnglishFirstName)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(p => p.EnglishLastName)
                .HasMaxLength(50)
                .IsUnicode(false);


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