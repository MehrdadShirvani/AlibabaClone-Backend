using AlibabaClone.Domain.Aggregates.AccountAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlibabaClone.Infrastructure.Configurations.AccountAggregates
{
    public class AccountRoleConfiguration : IEntityTypeConfiguration<AccountRole>
    {
        public void Configure(EntityTypeBuilder<AccountRole> builder)
        {
            builder.HasKey(ar => new { ar.RoleId, ar.AccountId });

            // Relationships
            builder.HasOne<Account>(ar => ar.Account)
                .WithMany(a => a.AccountRoles)
                .HasForeignKey(ar => ar.AccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Role>(ar => ar.Role)
                .WithMany()
                .HasForeignKey(ar => ar.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
