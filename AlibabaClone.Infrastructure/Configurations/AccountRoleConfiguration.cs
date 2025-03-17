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
    public class AccountRoleConfiguration : IEntityTypeConfiguration<AccountRole>
    {
        public void Configure(EntityTypeBuilder<AccountRole> builder)
        {
            builder.HasKey(ar => new { ar.RoleId, ar.AccountId });

            
            builder.HasOne<Account>()
                .WithMany()
                .HasForeignKey(ar => ar.AccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Role>()
                .WithMany()
                .HasForeignKey(ar => ar.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
