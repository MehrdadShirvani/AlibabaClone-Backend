using AlibabaClone.Domain.Aggregates.CompanyAggregates;
using AlibabaClone.Domain.Aggregates.LocationAggregates;
using AlibabaClone.Domain.Aggregates.VehicleAggregates;
using AlibabaClone.Domain.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlibabaClone.Domain.Aggregates.TransportationAggregates
{
    public class Transportation : Entity<long>
    {
        public int FromLocationId { get; set; }
        public int ToLocationId { get; set; }
        public int CompanyId { get; set; }
        public int VehicleId { get; set; }  
        public DateTime StartDateTime { get; set; } 
        public DateTime? EndDateTime { get; set; }
        public string SerialNumber { get; protected set; }
        public int RemainingCapacity =>
            Vehicle.Capacity - TicketOrders?
            .SelectMany(to => to.Tickets)
            .Count(t => t.TicketStatusId == 1) ?? 0;

        public decimal BasePrice { get; set; }
        public decimal? VIPPrice { get; set; }  

        public virtual Location FromLocation { get; set; }
        public virtual Location ToLocation { get; set; }
        public virtual Company Company { get; set; }  
        public virtual Vehicle Vehicle { get; set; }
        public virtual ICollection<TicketOrder> TicketOrders { get; set; }

    }
}
