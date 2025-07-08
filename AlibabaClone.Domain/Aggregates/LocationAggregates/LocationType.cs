using AlibabaClone.Domain.Framework.Base;

namespace AlibabaClone.Domain.Aggregates.LocationAggregates
{
    public class LocationType : Entity<short>
    {
        public required string Title { get; set; }

        public virtual ICollection<Location> Locations { get; set; }
    }
}
