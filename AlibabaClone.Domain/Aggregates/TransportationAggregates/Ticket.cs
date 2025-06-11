using AlibabaClone.Domain.Aggregates.AccountAggregates;
using AlibabaClone.Domain.Aggregates.VehicleAggregates;
using AlibabaClone.Domain.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlibabaClone.Domain.Aggregates.TransportationAggregates
{
    public class Ticket : Entity<long>
    {
            
        public long TicketOrderId { get; set; }
        public long SeatId { get; set; }
        public long TravelerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CanceledAt { get; set; }
        public long? CompanionId { get; set; }   
        public short TicketStatusId { get; set; }
        public string SerialNumber { get; protected set; }
        public string? Description { get; set; }


        public virtual TicketOrder TicketOrder { get; set; }  
        public virtual Seat Seat { get; set; }
        public virtual Person Traveler { get; set; }
        public virtual Person? Companion { get; set; }
        public virtual TicketStatus TicketStatus { get; set; }
    }
}
