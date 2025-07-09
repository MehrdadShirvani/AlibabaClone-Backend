using AlibabaClone.Domain.Aggregates.TransportationAggregates;
using AlibabaClone.Domain.Framework.Base;

namespace AlibabaClone.Domain.Aggregates.VehicleAggregates
{
    public class Seat : Entity<long>
    {
        public int VehicleId { get; set; }
        public int Row {  get; set; }   
        public int Column { get; set; }
        public bool IsVIP { get; set; }
        public bool IsAvailable { get; set; }
        public string? Description { get; set; }

        public virtual Vehicle Vehicle { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }    
    }
}
