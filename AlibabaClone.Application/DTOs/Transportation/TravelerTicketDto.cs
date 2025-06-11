using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlibabaClone.Application.DTOs.Transportation
{
    public class TravelerTicketDto
    {
        public long Id { get; set; }
        public string SerialNumber { get; set; }
        public string TravelerName { get; set; }
        public DateTime BirthDate { get; set; }
        public string SeatNumber { get; set; }
        public string TicketStatus { get; set; }
        public string CompanionName { get; set; }
        public string Description { get; set; }

    }
}
