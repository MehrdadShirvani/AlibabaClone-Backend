using AlibabaClone.Domain.Aggregates.TransportationAggregates;
using AlibabaClone.Domain.Framework.Base;

namespace AlibabaClone.Domain.Aggregates.CompanyAggregates
{
    public class Company : Entity<int>
    {
        public required string Title { get; set; }

        public virtual ICollection<Transportation> Transportations { get; set; }
    }
}
