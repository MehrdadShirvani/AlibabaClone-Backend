using AlibabaClone.Domain.Aggregates.TransactionAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlibabaClone.Infrastructure.Configurations.TransactionAggregates
{
    public class CouponConfiguration : IEntityTypeConfiguration<Coupon>
    {
        /*
         * public string Code { get; set; } 
        public decimal MaxDiscountAmount { get; set; }           
        public decimal? DiscountPercentage { get; set; }      // percentage-based
        public DateTime ExpiryDate { get; set; }
        public int MaxUsages { get; set; } = 1;               
        public int MaxUsagesPerAccount { get; set; } = 1;        
        public bool IsActive { get; set; } = true;
         */
        public void Configure(EntityTypeBuilder<Coupon> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd();
            
            
            builder.Property(t => t.Code)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.MaxDiscountAmount)
                .HasColumnType("decimal(18,2)")
                .IsRequired(true);

            builder.Property(t => t.DiscountPercentage)
                .HasColumnType("decimal(18,2)")
                .IsRequired(false);

            builder.Property(t => t.ExpiryDate)
                .IsRequired(true);

            builder.Property(t => t.MaxUsages)
                .IsRequired(true);

            builder.Property(t => t.MaxUsagesPerAccount)
                .IsRequired(true);


            builder.Property(t => t.IsActive)
                .IsRequired(true);

        }

    }
}
