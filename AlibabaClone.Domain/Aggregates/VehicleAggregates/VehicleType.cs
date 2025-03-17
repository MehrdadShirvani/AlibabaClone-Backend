using AlibabaClone.Domain.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlibabaClone.Domain.Aggregates.VehicleAggregates
{
    public class VehicleType : Entity<short>
    {
        public required string Title { get; set; } 
        
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
