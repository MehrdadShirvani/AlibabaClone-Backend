using AlibabaClone.Domain.Aggregates.TransactionAggregates;
using AlibabaClone.Domain.Aggregates.TransportationAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlibabaClone.Infrastructure.Configurations.TransactionAggregates
{
    public class TransactionTypeConfiguration : IEntityTypeConfiguration<TransactionType>
    {
        public void Configure(EntityTypeBuilder<TransactionType> builder)
        {
            builder.HasKey(g => g.Id);
            builder.Property(g => g.Id)
                .ValueGeneratedOnAdd();

            builder.Property(g => g.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(g => g.Title)
                .IsUnique();

            //Seed Data
            builder.HasData(
                new TransactionType { Id = 1, Title = "Deposit" },
                new TransactionType { Id = 2, Title = "Withdraw" }
            );
        }
    }
}
