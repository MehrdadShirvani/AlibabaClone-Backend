using AlibabaClone.Domain.Aggregates.TransportationAggregates;
using AlibabaClone.Domain.Framework.Base;

namespace AlibabaClone.Domain.Aggregates.LocationAggregates
{
    public class Location : Entity<int>
    {
        public required string Title { get; set; }
        public int CityId { get; set; } 
        public short LocationTypeId { get; set; }   

        public virtual City City { get; set; }
        public virtual LocationType LocationType { get; set; }

        public virtual ICollection<Transportation> DepartingTransportations { get; set; }
        public virtual ICollection<Transportation> ArrivingTransportations { get; set; }
    }
}
