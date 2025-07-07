using AlibabaClone.Domain.Framework.Base;

namespace AlibabaClone.Domain.Aggregates.VehicleAggregates
{
    public class VehicleType : Entity<short>
    {
        public required string Title { get; set; } 
        
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
