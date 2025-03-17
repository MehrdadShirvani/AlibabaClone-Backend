using AlibabaClone.Domain.Aggregates.TransportationAggregates;
using AlibabaClone.Domain.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlibabaClone.Domain.Aggregates.VehicleAggregates
{
    public class Vehicle : Entity<int>
    {
        public required string Title { get; set; }
        public short VehicleTypeId { get; set; }
        public int Capacity { get; set; }
        public required string PlateNumber { get; set; }

        public virtual VehicleType VehicleType { get; set; }
        public virtual ICollection<Seat> Seats{ get; set; }
        public virtual ICollection<Transportation> Transportations{ get; set; }
    }
}
